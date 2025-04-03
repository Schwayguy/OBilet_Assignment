using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OBilet_Assignment.Models
{
    public class JourneysModel
    {
        public class JourneyData
        {
            [JsonProperty("origin-id")]
            public int? originid { get; set; }

            [JsonProperty("destination-id")]
            public int? destinationid { get; set; }

            [JsonProperty("departure-date")]
            public string? departuredate { get; set; }
        }

        public class JourneysRequest

        {
            [JsonProperty("device-session")]
            public DeviceSession? devicesession { get; set; }
            public string? date { get; set; }
            public string? language { get; set; }
            public JourneyData? data { get; set; }
        }

        public class Datum
        {
            public int? id { get; set; }

            [JsonProperty("partner-id")]
            public int? partnerid { get; set; }

            [JsonProperty("partner-name")]
            public string? partnername { get; set; }

            [JsonProperty("route-id")]
            public int? routeid { get; set; }

            [JsonProperty("bus-type")]
            public string? bustype { get; set; }

            [JsonProperty("bus-type-name")]
            public string? bustypename { get; set; }

            [JsonProperty("total-seats")]
            public int? totalseats { get; set; }

            [JsonProperty("available-seats")]
            public int? availableseats { get; set; }
            public Journey? journey { get; set; }
            public List<Feature>? features { get; set; }

            [JsonProperty("origin-location")]
            public string? originlocation { get; set; }

            [JsonProperty("destination-location")]
            public string? destinationlocation { get; set; }

            [JsonProperty("is-active")]
            public bool? isactive { get; set; }

            [JsonProperty("origin-location-id")]
            public int? originlocationid { get; set; }

            [JsonProperty("destination-location-id")]
            public int? destinationlocationid { get; set; }

            [JsonProperty("is-promoted")]
            public bool? ispromoted { get; set; }

            [JsonProperty("cancellation-offset")]
            public int? cancellationoffset { get; set; }

            [JsonProperty("has-bus-shuttle")]
            public bool? hasbusshuttle { get; set; }

            [JsonProperty("disable-sales-without-gov-id")]
            public bool? disablesaleswithoutgovid { get; set; }

            [JsonProperty("display-offset")]
            public string? displayoffset { get; set; }

            [JsonProperty("partner-rating")]
            public double? partnerrating { get; set; }

            [JsonProperty("has-dynamic-pricing")]
            public bool? hasdynamicpricing { get; set; }

            [JsonProperty("disable-sales-without-hes-code")]
            public bool? disablesaleswithouthescode { get; set; }

            [JsonProperty("disable-single-seat-selection")]
            public bool? disablesingleseatselection { get; set; }

            [JsonProperty("change-offset")]
            public int? changeoffset { get; set; }
            public int? rank { get; set; }

            [JsonProperty("display-coupon-code-input")]
            public bool? displaycouponcodeinput { get; set; }

            [JsonProperty("disable-sales-without-date-of-birth")]
            public bool? disablesaleswithoutdateofbirth { get; set; }

            [JsonProperty("open-offset")]
            public int? openoffset { get; set; }

            [JsonProperty("display-buffer")]
            public object? displaybuffer { get; set; }

            [JsonProperty("allow-sales-foreign-passenger")]
            public bool? allowsalesforeignpassenger { get; set; }

            [JsonProperty("has-seat-selection")]
            public bool? hasseatselection { get; set; }

            [JsonProperty("branded-fares")]
            public List<object>? brandedfares { get; set; }

            [JsonProperty("has-gender-selection")]
            public bool? hasgenderselection { get; set; }

            [JsonProperty("has-dynamic-cancellation")]
            public bool? hasdynamiccancellation { get; set; }

            [JsonProperty("partner-terms-and-conditions")]
            public object? partnertermsandconditions { get; set; }

            [JsonProperty("partner-available-alphabets")]
            public string? partneravailablealphabets { get; set; }

            [JsonProperty("provider-id")]
            public int? providerid { get; set; }

            [JsonProperty("partner-code")]
            public string? partnercode { get; set; }

            [JsonProperty("enable-full-journey-display")]
            public bool? enablefulljourneydisplay { get; set; }

            [JsonProperty("provider-name")]
            public string? providername { get; set; }

            [JsonProperty("enable-all-stops-display")]
            public bool? enableallstopsdisplay { get; set; }

            [JsonProperty("is-destination-domestic")]
            public bool? isdestinationdomestic { get; set; }

            [JsonProperty("min-len-gov-id")]
            public object? minlengovid { get; set; }

            [JsonProperty("max-len-gov-id")]
            public object? maxlengovid { get; set; }

            [JsonProperty("require-foreign-gov-id")]
            public bool? requireforeigngovid { get; set; }

            [JsonProperty("is-cancellation-info-text")]
            public bool? iscancellationinfotext { get; set; }

            [JsonProperty("cancellation-offset-info-text")]
            public object? cancellationoffsetinfotext { get; set; }

            [JsonProperty("is-time-zone-not-equal")]
            public bool? istimezonenotequal { get; set; }

            [JsonProperty("markup-rate")]
            public double? markuprate { get; set; }

            [JsonProperty("is-print?-ticket-before-journey")]
            public bool? isprintticketbeforejourney { get; set; }

            [JsonProperty("is-extended-journey-detail")]
            public bool? isextendedjourneydetail { get; set; }

            [JsonProperty("is-payment-select-gender")]
            public bool? ispaymentselectgender { get; set; }

            [JsonProperty("should-turkey-on-the-nationality-list")]
            public bool? shouldturkeyonthenationalitylist { get; set; }

            [JsonProperty("markup-fee")]
            public double? markupfee { get; set; }

            [JsonProperty("partner-nationality")]
            public object? partnernationality { get; set; }

            [JsonProperty("generate-barcode")]
            public bool? generatebarcode { get; set; }

            [JsonProperty("is-print?-ticket-before-journey-badge")]
            public bool? isprintticketbeforejourneybadge { get; set; }

            [JsonProperty("is-print?-ticket-before-journey-mail")]
            public bool? isprintticketbeforejourneymail { get; set; }

            [JsonProperty("is-show-fare-rules")]
            public bool? isshowfarerules { get; set; }

            [JsonProperty("is-different-seat-price")]
            public bool? isdifferentseatprice { get; set; }

            [JsonProperty("redirect-to-checkout")]
            public bool? redirecttocheckout { get; set; }

            [JsonProperty("is-show-rating-avarage")]
            public bool? isshowratingavarage { get; set; }

            [JsonProperty("partner-route-rating")]
            public double? partnerrouterating { get; set; }

            [JsonProperty("partner-route-rating-vote-count")]
            public int? partnerrouteratingvotecount { get; set; }

            [JsonProperty("partner-rating-vote-count")]
            public int? partnerratingvotecount { get; set; }

            [JsonProperty("included-station-fee")]
            public bool? includedstationfee { get; set; }

            [JsonProperty("is-domestic-route")]
            public bool? isdomesticroute { get; set; }

            [JsonProperty("is-abroad-route")]
            public bool? isabroadroute { get; set; }

            [JsonProperty("disable-sales-without-passport-expiration-date")]
            public bool? disablesaleswithoutpassportexpirationdate { get; set; }

            [JsonProperty("transfer-count")]
            public int? transfercount { get; set; }

            [JsonProperty("is-national-identity-number-validator")]
            public bool? isnationalidentitynumbervalidator { get; set; }

            [JsonProperty("national-identity-validation-rules")]
            public object? nationalidentityvalidationrules { get; set; }

            [JsonProperty("int?ernet-price-rate")]
            public object? internetpricerate { get; set; }

            [JsonProperty("journey-detail-carrier-base")]
            public object? journeydetailcarrierbase { get; set; }

            [JsonProperty("has-shuttle-selection")]
            public bool? hasshuttleselection { get; set; }

            [JsonProperty("origin-station-id")]
            public int? originstationid { get; set; }

            [JsonProperty("destination-station-id")]
            public int? destinationstationid { get; set; }

            [JsonProperty("has-available-seat-info")]
            public bool? hasavailableseatinfo { get; set; }

            [JsonProperty("has-seat-selection-method")]
            public bool? hasseatselectionmethod { get; set; }

            [JsonProperty("has-journey-shuttle")]
            public bool? hasjourneyshuttle { get; set; }

            [JsonProperty("is-full-address")]
            public bool? isfulladdress { get; set; }

            [JsonProperty("display-offset-started")]
            public string? displayoffsetstarted { get; set; }

            [JsonProperty("display-offset-after-min")]
            public object? displayoffsetaftermin { get; set; }

            [JsonProperty("is-send-order-completion-pdf")]
            public bool? issendordercompletionpdf { get; set; }
        }

        public class Feature
        {
            public int? id { get; set; }
            public int? priority { get; set; }
            public string? name { get; set; }
            public string? description { get; set; }

            [JsonProperty("is-promoted")]
            public bool? ispromoted { get; set; }

            [JsonProperty("back-color")]
            public string? backcolor { get; set; }

            [JsonProperty("fore-color")]
            public string? forecolor { get; set; }

            [JsonProperty("partner-notes")]
            public object? partnernotes { get; set; }
        }

        public class Journey
        {
            public string? kind { get; set; }
            public string? code { get; set; }
            public List<Stop>? stops { get; set; }
            public string? origin { get; set; }
            public string? destination { get; set; }
            public DateTime departure { get; set; }
            public DateTime arrival { get; set; }
            public string? currency { get; set; }
            public string? duration { get; set; }

            [JsonProperty("original-price")]
            public decimal? originalprice { get; set; }

            [JsonProperty("int?ernet-price")]
            public decimal? internetprice { get; set; }

            [JsonProperty("provider-int?ernet-price")]
            public decimal? providerinternetprice { get; set; }
            public object? booking { get; set; }

            [JsonProperty("bus-name")]
            public string? busname { get; set; }
            public Policy? policy { get; set; }
            public List<string?>? features { get; set; }

            [JsonProperty("features-description")]
            public object? featuresdescription { get; set; }
            public string? description { get; set; }
            public object? available { get; set; }

            [JsonProperty("partner-provider-code")]
            public object? partnerprovidercode { get; set; }

            [JsonProperty("peron-no")]
            public object? peronno { get; set; }

            [JsonProperty("partner-provider-id")]
            public object? partnerproviderid { get; set; }

            [JsonProperty("is-segmented")]
            public bool? issegmented { get; set; }

            [JsonProperty("partner-name")]
            public object? partnername { get; set; }

            [JsonProperty("provider-code")]
            public object? providercode { get; set; }

            [JsonProperty("sorting-price")]
            public decimal? sortingprice { get; set; }

            [JsonProperty("has-multiple-brandedfare-selection")]
            public bool? hasmultiplebrandedfareselection { get; set; }

            [JsonProperty("has-available-seat-info")]
            public bool? hasavailableseatinfo { get; set; }
        }

        public class Policy
        {
            [JsonProperty("max-seats")]
            public object? maxseats { get; set; }

            [JsonProperty("max-single")]
            public int? maxsingle { get; set; }

            [JsonProperty("max-single-males")]
            public int? maxsinglemales { get; set; }

            [JsonProperty("max-single-females")]
            public int? maxsinglefemales { get; set; }

            [JsonProperty("mixed-genders")]
            public bool? mixedgenders { get; set; }

            [JsonProperty("gov-id")]
            public bool? govid { get; set; }
            public bool? lht { get; set; }
        }

        public class JourneysResponse
        {
            public string? status { get; set; }
            public List<Datum?>? data { get; set; }
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

        public class Stop
        {
            public int? id { get; set; }
            public int? kolayCarLocationId { get; set; }
            public string? name { get; set; }
            public string? station { get; set; }
            public DateTime? time { get; set; }

            [JsonProperty("is-origin")]
            public bool? isorigin { get; set; }

            [JsonProperty("is-destination")]
            public bool? isdestination { get; set; }

            [JsonProperty("is-segment-stop")]
            public bool? issegmentstop { get; set; }
            public int? index { get; set; }

            [JsonProperty("obilet-station-id")]
            public object? obiletstationid { get; set; }

            [JsonProperty("map-url")]
            public object? mapurl { get; set; }

            [JsonProperty("station-phone")]
            public object? stationphone { get; set; }

            [JsonProperty("station-address")]
            public object? stationaddress { get; set; }
        }

        public class JourneysForView
        {
            public List<Journey>? Journeys { get; set; }
            public string? OriginLocation { get; set; }
            public string? DestinationLocation { get; set; }
            public string? DepartureDate { get; set; }
            public int? OriginId { get; set; }
            public int? DestinationId { get; set; }
        }
        public class JourneyInfo
        {
            public string? origin { get; set; }
            public string? destination { get; set; }
            public string? departuredate { get; set; }
            public int? originId { get; set; }
            public int? destinationId { get; set; }
        }
    }
}