// using Almostengr.PetFeeder.Api.Models;
// using Almostengr.PetFeeder.Api.Services;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;

// namespace Almostengr.PetFeeder.Api.Controllers
// {
//     public class SettingsController : ControllerBase
//     {
//         // reference
//         // https://developingsoftware.com/how-to-store-application-settings-in-aspnet-mvc-using-entity-framework/

//         private readonly ILogger<SettingsController> _logger;

//         public SettingsController(ILogger<SettingsController> logger)
//         {
//             _logger = logger;
//         }

//         public ActionResult Save()
//         {
//             using (var uow = new UnitOfWork())
//             {
//                 var settings = new Settings(uow);
//                 settings.General.SiteName = "Talk Sharp";
//                 settings.Seo.HomeMetaDescription = "Welcome to Talk Sharp";
//                 settings.Save();

//                 var settings2 = new Settings(uow, null);
//                 string output = string.Format("SiteName: {0} HomeMetaDescription: {1}",
//                                                 settings2.General.SiteName,
//                                                 settings2.Seo.HomeMetaDescription
//                                                 );
//                 return Content(output);
//             }
//         }

//     }
// }