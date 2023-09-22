using System.Diagnostics;
using GameZone.Models;
using GameZone.Srvices;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGamesService _gamesService;
        public HomeController(ILogger<HomeController> logger ,
            IGamesService gamesService)
        {
            _logger = logger;
            _gamesService = gamesService;
        }

        public IActionResult Index()
        {
            var data = _gamesService.Disply();
           return View(data);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}