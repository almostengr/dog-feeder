using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Almostengr.PetFeeder.Web.Models;
using Almostengr.PetFeeder.Web.Relays;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers.Api
{
    public class NightLightsController : BaseApiController
    {
        private readonly INightLightRelay _nightLightRelay;

        public NightLightsController(ILogger<BaseApiController> logger, INightLightRelay nightLightRelay) : base(logger)
        {
            _nightLightRelay = nightLightRelay;
        }

        [HttpPost]
        public async Task<ActionResult<NightLight>> CreateNightLightAsync([FromBody] NightLightDto nightLightDto)
        {
            if (nightLightDto.LightOn)
            {
                await _nightLightRelay.NightLightOnAsync();
            }
            else {
                await _nightLightRelay.NightLightOffAsync();
            }

            return Ok();
        }
        
    }
}