using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    public class ErrorController : BaseApiController
    {
        private readonly ILogger<BaseApiController> _logger;

        public ErrorController(ILogger<BaseApiController> logger) : base(logger)
        {
            _logger = logger;
        }


        // references
        // https://medium.com/@marcin_smach/handling-exceptions-in-c-web-api-core-2-d252b1f7a7b3
        // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-3.1

        [Route("/error")]
        public async Task<IActionResult> Error()
        {
            // Retrieve error information in case of internal errors
            var error = HttpContext.Features.Get<IExceptionHandlerFeature>();

            _logger.LogError(error.Error.Message);

            switch (error.Error)
            {
                case ArgumentNullException:
                    return BadRequest(error.Error.Message);
                    
                default:
                    return StatusCode(500, error.Error.Message);
            }
        }


    }
}