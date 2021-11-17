using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.FrontEnd.Controllers
{
    public class FeedingController : BaseController
    {
        public FeedingController(ILogger<FeedingController> logger) : base(logger)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Feed(FeedingDto feedingDto)
        {
            await PostAsync("/api/feeding", feedingDto);
            return RedirectToAction("Index");
        }
    }
}