using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObjects;
using Almostengr.PetFeeder.BackEnd.Relays;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace Almostengr.PetFeeder.BackEnd.Controllers.Api
{
    public class NightLightsController : BaseApiController
    {
        private readonly INightLightRelay _nightLightRelay;
        private readonly ILogger<NightLightsController> _logger;

        public NightLightsController(ILogger<NightLightsController> logger, INightLightRelay nightLightRelay) : base(logger)
        {
            _nightLightRelay = nightLightRelay;
            _logger = logger;
        }

        // POST /api/nightlights
        [HttpPost]
        public async Task<ActionResult> CreateNightLightAsync([FromBody] NightLightDto nightLightDto)
        {
            if (nightLightDto.LightOn)
            {
                await _nightLightRelay.NightLightOnAsync();
            }
            else {
                await _nightLightRelay.NightLightOffAsync();
            }

            var entityJson =  new StringContent(JsonConvert.SerializeObject(nightLightDto), Encoding.UTF8, "application/json");
            _logger.LogInformation($"NightLight: {entityJson}");

            return Ok();
        }
        
    }
}