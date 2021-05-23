# Pet Feeder

Automatic pet feeder powered by a Raspberry PI and .NET Core C#

## References 

* https://developer.okta.com/blog/2020/07/29/entity-framework-core-api
* https://developingsoftware.com/how-to-store-application-settings-in-aspnet-mvc-using-entity-framework/
* https://stackoverflow.com/questions/38741119/asp-mvc-5-ef-saving-application-settings
* https://www.yogihosting.com/aspnet-core-consume-api/#create
* https://www.codeproject.com/Articles/5291291/Interface-with-Raspberry-Pi-I2C-Sensors-Using-NET
* https://docs.microsoft.com/en-us/ef/core/cli/dotnet#update-the-tools


## EF CLI Commands

* dotnet ef migrations add -p Almostengr.PetFeeder.Api/ "initialMigration"
* dotnet ef database update -p Almostengr.PetFeeder.Api/