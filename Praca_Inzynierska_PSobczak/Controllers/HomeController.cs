using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Praca_Inzynierska_PSobczak.Models;
using Praca_Inzynierska_PSobczak.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VisitsService visttsService;

        public HomeController(ILogger<HomeController> logger, VisitsService visttsService)
        {
            _logger = logger;
            this.visttsService = visttsService;
        }

        public IActionResult Index()
        {
            var vm = visttsService.GetAllVisitsById(User.Identity.Name);

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
