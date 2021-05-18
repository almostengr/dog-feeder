namespace Almostengr.DogFeeder.Api.Models
{
    // reference 
    // https://developingsoftware.com/how-to-store-application-settings-in-aspnet-mvc-using-entity-framework/

    public class Setting
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}