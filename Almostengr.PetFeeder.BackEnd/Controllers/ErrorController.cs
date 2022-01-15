using System;
using System.Net;
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

        // https://www.c-sharpcorner.com/article/global-error-handling-in-asp-net-core-5/

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult HandleError()
        {
            var contextException = HttpContext.Features.Get<IExceptionHandlerFeature>();

            HttpStatusCode responseStatusCode;
            
            switch (contextException.Error.GetType().Name)
            {
                case nameof(NullReferenceException):
                case nameof(ArgumentNullException):
                    responseStatusCode = HttpStatusCode.BadRequest;
                    break;
                
                default:
                    responseStatusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            _logger.LogError(contextException.Error, contextException.Error.Message);

            return Problem(detail: contextException.Error.Message, statusCode: (int)responseStatusCode);
        }

    }
}