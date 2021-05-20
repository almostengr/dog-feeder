using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers
{
    public class ScheduleController : BaseController
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly AppSettings _appSettings;

        public ScheduleController(ILogger<ScheduleController> logger, AppSettings appSettings)
         : base(logger, appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task<IActionResult> Index()
        {
            var schedules = await GetAsync<List<ScheduleViewModel>>("schedules");
            return View(schedules);
        }
    }
}