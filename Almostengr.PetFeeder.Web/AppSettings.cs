using System;

namespace Almostengr.PetFeeder.Web
{
    public class AppSettings
    {
        private Uri _appBaseUrl;
        public Uri ApiBaseUrl { 
            get { return _appBaseUrl; }
            set { _appBaseUrl = new Uri(value.ToString()); }
        }
    }
}