using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected BaseApiController(ILogger<BaseApiController> logger)
        {
        }
    }
}