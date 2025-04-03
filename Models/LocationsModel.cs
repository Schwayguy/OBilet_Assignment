using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using static OBilet_Assignment.Models.JourneysModel;

namespace OBilet_Assignment.Models
{
    public class LocationsModel
    {

        public class LocationsRequest
        {
            public string? data { get; set; }

            [JsonProperty("device-session")]
            public DeviceSession? devicesession { get; set; }
            public DateTime date { get; set; }
            public string? language { get; set; }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Location
        {
            public int id { get; set; }

            [JsonProperty("parent-id")]
            public int parentid { get; set; }
            public string? type { get; set; }
            public string? name { get; set; }

            [JsonProperty("geo-location")]
            public GeoLocation? geolocation { get; set; }
            public int zoom { get; set; }

            [JsonProperty("tz-code")]
            public string? tzcode { get; set; }

            [JsonProperty("weather-code")]
            public object? weathercode { get; set; }
            public int rank { get; set; }

            [JsonProperty("reference-code")]
            public string? referencecode { get; set; }

            [JsonProperty("city-id")]
            public int cityid { get; set; }

            [JsonProperty("reference-country")]
            public object? referencecountry { get; set; }

            [JsonProperty("country-id")]
            public int countryid { get; set; }
            public string? keywords { get; set; }

            [JsonProperty("city-name")]
            public string? cityname { get; set; }
            public object? languages { get; set; }

            [JsonProperty("country-name")]
            public string? countryname { get; set; }
            public object? code { get; set; }

            [JsonProperty("show-country")]
            public bool showcountry { get; set; }

            [JsonProperty("area-code")]
            public object? areacode { get; set; }

            [JsonProperty("long-name")]
            public string? longname { get; set; }

            [JsonProperty("is-city-center")]
            public bool iscitycenter { get; set; }
        }

        public class GeoLocation
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
            public int zoom { get; set; }
        }

        public class LocationsResponse
        {
            public string? status { get; set; }
            public List<Location>? data { get; set; }
            public object? message { get; set; }

            [JsonProperty("user-message")]
            public object? usermessage { get; set; }

            [JsonProperty("api-request-id")]
            public object? apirequestid { get; set; }
            public string? controller { get; set; }

            [JsonProperty("client-request-id")]
            public object? clientrequestid { get; set; }

            [JsonProperty("web-correlation-id")]
            public object? webcorrelationid { get; set; }

            [JsonProperty("correlation-id")]
            public string? correlationid { get; set; }
            public object? parameters { get; set; }
        }

        public class LocationsForView
        {
            public List<Location>? OriginLocations { get; set; }
            public List<Location>? DestinationLocations { get; set; }
            public JourneysForView? JourneysForView { get; set; }

        }
    }
}