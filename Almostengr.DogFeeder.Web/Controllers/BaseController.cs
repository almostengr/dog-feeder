using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.DogFeeder.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly ILogger<BaseController> _logger;
        private readonly HttpClient _httpClient;

        public BaseController(ILogger<BaseController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }


    }
}