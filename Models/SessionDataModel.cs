using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OBilet_Assignment.Models
{
    public class Browser
    {
        public string? name { get; set; }
        public string? version { get; set; }
    }

    public class Connection
    {
        [JsonProperty("ip-address")]
        public string? ipaddress { get; set; }
        public string? port { get; set; }
    }

    public class SessionDataRequest
    {
        public int type { get; set; }
        public Connection? connection { get; set; }
        public Browser? browser { get; set; }
    }

    public class Data
    {
        [JsonProperty("session-id")]
        public string? sessionid { get; set; }

        [JsonProperty("device-id")]
        public string? deviceid { get; set; }
        public object? affiliate { get; set; }

        [JsonProperty("device-type")]
        public int devicetype { get; set; }
        public object? device { get; set; }

        [JsonProperty("ip-country")]
        public string? ipcountry { get; set; }

        [JsonProperty("clean-session-id")]
        public int cleansessionid { get; set; }

        [JsonProperty("clean-device-id")]
        public int cleandeviceid { get; set; }

        [JsonProperty("ip-address")]
        public object? ipaddress { get; set; }
    }

    public class SessionDataResponse
    {
        public string? status { get; set; }
        public Data? data { get; set; }
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

    public class DeviceSession
    {
        [JsonProperty("session-id")]
        public string? sessionid { get; set; }

        [JsonProperty("device-id")]
        public string? deviceid { get; set; }
    }
}