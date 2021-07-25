using System.Net.Http.Headers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController(ILogger<BaseController> logger)
        {
        }

    }
}