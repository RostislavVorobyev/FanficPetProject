using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FictionUILayer.Models;
using FictionLogicLayer;

namespace FictionUILayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFanficService _fanficService;
        private readonly ILogger<HomeController> _logger;


        public HomeController(IFanficService fanficService)
        { 
            _fanficService = fanficService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel()
            {
                MostRated = _fanficService.GetMostRated(10),
                RecentlyUpdated = _fanficService.GetRecentlyUpdated()
            };
            return View(model);
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
