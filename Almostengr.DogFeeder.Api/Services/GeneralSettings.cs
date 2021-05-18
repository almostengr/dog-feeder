namespace Almostengr.DogFeeder.Api.Services
{

    public class GeneralSettings : SettingsBase
    {
        public string SiteName { get; set; }
        public string AdminEmail { get; set; }
    }

    public class SeoSettings : SettingsBase
    {
        public string HomeMetaTitle { get; set; }
        public string HomeMetaDescription { get; set; }
    }

}