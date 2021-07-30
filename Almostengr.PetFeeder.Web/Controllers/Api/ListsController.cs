using System;
using System.Collections.Generic;
using System.Linq;
using Almostengr.PetFeeder.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers.Api
{
    public class ListsController : BaseApiController
    {
        public ListsController(ILogger<ListsController> logger) : base(logger)
        {
        }

        // GET /api/lists/dayfrequency
        [HttpGet("dayfrequency")]
        public ActionResult<IList<DayFrequency>> DayFrequency()
        {
            return Enum.GetValues(typeof(DayFrequency)).Cast<DayFrequency>().ToList();
        }
    }
}