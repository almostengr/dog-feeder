using System;
using System.Collections.Generic;
using System.Linq;
using Almostengr.PetFeeder.Api.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Controllers
{
    public class ListsController : BaseController
    {
        public ListsController(ILogger<BaseController> logger) : base(logger)
        {
        }

        [HttpGet("dayfrequency")]
        public ActionResult<IList<DayFrequency>> DayFrequency()
        {
            return Enum.GetValues(typeof(DayFrequency)).Cast<DayFrequency>().ToList();
        }
    }
}