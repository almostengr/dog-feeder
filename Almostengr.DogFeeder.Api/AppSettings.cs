using System;
using System.Collections.Generic;

namespace Almostengr.DogFeeder
{
    public class AppSettings
    {
        public IList<TimeSpan> FeedTimes { get; set; }
        public HomeAssistant HomeAssistant { get; set; }
        public string ConnectionString { get; set; }
    }

    public class HomeAssistant
    {
        public string Url { get; set; }
        public string Token { get; set; }
    }
}