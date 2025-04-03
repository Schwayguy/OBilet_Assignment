using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OBilet_Assignment.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OBilet_Assignment.Services;
using System.Net.Http.Headers;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using static OBilet_Assignment.Models.LocationsModel;
using static OBilet_Assignment.Models.JourneysModel;
using System.Diagnostics.Eventing.Reader;
namespace OBilet_Assignment.Controllers;

public class HomeController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly SessionManager _sessionManager;
    public List<Location> Locations { get; set; } = new List<Location>();
    public List<Location> OriginLocations { get; set; } = new List<Location>();
    public List<Location> DestinationLocations { get; set; } = new List<Location>();
    public static LocationsForView LocationsForView { get; set; } = new LocationsForView();
    public static JourneyInfo JourneyInfo { get; set; } = new JourneyInfo();
    public static JourneysForView JourneysForView { get; set; } = new JourneysForView();
    public HomeController(SessionManager sessionManager)
    {
        _sessionManager = sessionManager;
        _httpClient = new HttpClient();
    }

    public IActionResult Index()
    {
        // Check if session key is already set in the session manager
        // If not, call GetSession() to create a new session
        if (string.IsNullOrEmpty(_sessionManager.GetSessionKey()))
        {
            GetSession().Wait();
        }

        ViewBag.SessionKey = _sessionManager.GetSessionKey();

        if (Locations.Count == 0)
        {
            GetLocations().Wait();
        }
        if (JourneysForView.OriginLocation != null)
        {
            LocationsForView.JourneysForView = JourneysForView;
        }
        else
        {
            LocationsForView.JourneysForView = new JourneysForView();
        }

        LocationsForView.OriginLocations = Locations;
        LocationsForView.DestinationLocations = Locations;
        return View(LocationsForView);
    }

    public async Task<ActionResult> GetSession()
    {

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", OBiletRestApiInfo.ApiClientToken);
        // Get browser information from the request headers
        // This is a simplified example; in a real application, you might want to use a library to parse the User-Agent string
        // and extract more detailed information about the browser and version.
        var browserInfo = Request.Headers["User-Agent"].ToString().Split(' ').LastOrDefault();
        var sessionData = new SessionDataRequest()
        {
            type = 1,
            browser = new Browser() { name = browserInfo.Split('/')[0], version = browserInfo.Split('/')[1] },
            connection = new Connection() { ipaddress = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(), port = Request.HttpContext.Connection.RemotePort.ToString() }
        };
        HttpContent content = new StringContent(JsonConvert.SerializeObject(sessionData), System.Text.Encoding.UTF8, "application/json");
        // Get the session key from the API
        HttpResponseMessage response = await _httpClient.PostAsync(OBiletRestApiInfo.GetSessionUrl, content);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var sessionDataModelResponse = JsonConvert.DeserializeObject<SessionDataResponse>(jsonString);

            if (sessionDataModelResponse.usermessage != null)
            {
                ViewData["ErrorMessage"] = sessionDataModelResponse.usermessage;
                return View();
            }
            else if (sessionDataModelResponse.data == null)
            {
                ViewData["ErrorMessage"] = "No data found";
                return View();
            }
            else
            {
                ViewData["ErrorMessage"] = null;
                _sessionManager.SetSessionKey(sessionDataModelResponse.data.sessionid);
                _sessionManager.SetDeviceId(sessionDataModelResponse.data.deviceid);
            }
        }
        else
        {
            ViewData["ErrorMessage"] = "Error occured trying to contact API, please try again later";
        }

        return RedirectToAction("Index");
    }

    public async Task<ActionResult> GetLocations()
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", OBiletRestApiInfo.ApiClientToken);
        // Get the locations(all)
        var locationRequest = new LocationsRequest()
        {
            data = "[]",
            devicesession = new DeviceSession() { sessionid = _sessionManager.GetSessionKey(), deviceid = _sessionManager.GetDeviceId() },
            date = DateTime.UtcNow,
            language = "tr-TR"
        };

        HttpContent content = new StringContent(JsonConvert.SerializeObject(locationRequest), System.Text.Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync(OBiletRestApiInfo.GetLocationsUrl, content);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var locationsResponse = JsonConvert.DeserializeObject<LocationsResponse>(jsonString);
            if (locationsResponse.usermessage != null)
            {
                ViewData["ErrorMessage"] = locationsResponse.usermessage;
                return View();
            }
            else if (locationsResponse.data == null || locationsResponse.data.Count == 0)
            {
                ViewData["ErrorMessage"] = "No data found";
                return View();
            }
            else
            {
                ViewData["ErrorMessage"] = null;
                Locations = locationsResponse.data;
            }
        }
        else
        {
            ViewData["ErrorMessage"] = "Error occured trying to contact API, please try again later";
            return View();
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<JsonResult> ComboChanged(string searchText)
    {
        var locations = new List<Location>();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", OBiletRestApiInfo.ApiClientToken);
        var locationRequest = new LocationsRequest()
        {
            data = searchText,
            devicesession = new DeviceSession() { sessionid = _sessionManager.GetSessionKey(), deviceid = _sessionManager.GetDeviceId() },
            date = DateTime.UtcNow,
            language = "tr-TR"
        };

        HttpContent content = new StringContent(JsonConvert.SerializeObject(locationRequest), System.Text.Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync(OBiletRestApiInfo.GetLocationsUrl, content);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var locationsResponse = JsonConvert.DeserializeObject<LocationsResponse>(jsonString);

            if (locationsResponse.usermessage != null)
            {
                ViewData["ErrorMessage"] = locationsResponse.usermessage;
            }
            else if (locationsResponse.data == null || locationsResponse.data.Count == 0)
            {
                ViewData["ErrorMessage"] = "No data found";
            }
            else
            {
                ViewData["ErrorMessage"] = null;
                locations = locationsResponse.data;
            }
        }
        else
        {
            ViewData["ErrorMessage"] = "Error occured trying to contact API, please try again later";
        }
        return Json(locations);
    }


    [HttpPost]
    public ActionResult GoToJourney(string origin, string destination, string departuredate, int originId, int destinationId)
    {
        //this works as a global variable to be used in the Index and Journey pages
        JourneyInfo.origin = origin;
        JourneyInfo.destination = destination;
        JourneyInfo.departuredate = departuredate;
        JourneyInfo.originId = originId;
        JourneyInfo.destinationId = destinationId;

        return Json(JourneyInfo);
    }

    public IActionResult Journey()
    {
        GetJourneys().Wait();

        return View(JourneysForView);
    }

    public async Task<IActionResult> GetJourneys()
    {
        //set the values for the view model to be used in Index page
        JourneysForView.OriginLocation = JourneyInfo.origin;
        JourneysForView.DestinationLocation = JourneyInfo.destination;
        JourneysForView.DepartureDate = JourneyInfo.departuredate;
        JourneysForView.OriginId = JourneyInfo.originId;
        JourneysForView.DestinationId = JourneyInfo.destinationId;
        var journeys = new List<Journey>();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", OBiletRestApiInfo.ApiClientToken);
        var locationRequest = new JourneysRequest()
        {
            data = new JourneyData()
            { departuredate = JourneyInfo.departuredate, originid = JourneyInfo.originId, destinationid = JourneyInfo.destinationId },

            devicesession = new DeviceSession() { sessionid = _sessionManager.GetSessionKey(), deviceid = _sessionManager.GetDeviceId() },
            date = DateTime.UtcNow.ToString("yyyy-MM-dd"),
            language = "tr-TR"
        };

        HttpContent content = new StringContent(JsonConvert.SerializeObject(locationRequest), System.Text.Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync(OBiletRestApiInfo.GetBusJourneysUrl, content);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var journeysResponse = JsonConvert.DeserializeObject<JourneysResponse>(jsonString);
            if (journeysResponse.usermessage != null)
            {
                ViewData["ErrorMessage"] = journeysResponse.usermessage;
                return View();
            }
            else if (journeysResponse.data == null || journeysResponse.data.Count == 0)
            {
                ViewData["ErrorMessage"] = "No data found";
                return View();
            }
            else
            {
                ViewData["ErrorMessage"] = null;
                foreach (var data in journeysResponse.data)
                {
                    journeys.Add(data.journey);
                }
                JourneysForView.Journeys = journeys.OrderBy(x => x.departure).ToList();
            }
        }
        else
        {
            ViewData["ErrorMessage"] = "Error occured trying to contact API, please try again later";
        }
        return RedirectToAction("Journey");
    }
}