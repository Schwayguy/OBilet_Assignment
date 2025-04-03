using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBilet_Assignment.Services
{
    public class SessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetSessionKey()
        {
            return _httpContextAccessor.HttpContext?.Session.GetString("SessionKey");
        }

        public void SetSessionKey(string value)
        {
            _httpContextAccessor.HttpContext?.Session.SetString("SessionKey", value);
        }

        public string? GetDeviceId()
        {
            return _httpContextAccessor.HttpContext?.Session.GetString("DeviceId");
        }

        public void SetDeviceId(string value)
        {
            _httpContextAccessor.HttpContext?.Session.SetString("DeviceId", value);
        }
    }
}