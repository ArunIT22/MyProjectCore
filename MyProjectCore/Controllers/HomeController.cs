using Microsoft.AspNetCore.Mvc;
using MyProjectCore.Models;
using System.Diagnostics;

namespace MyProjectCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client, VaryByHeader = "user-agent")]
        public IActionResult Index()
        {
            ViewBag.Today = $"Response was generated at {DateTime.Now}";
            return View();
        }

        //VaryByParameter
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] { "id" })]
        public IActionResult Privacy(int id)
        {
            ViewBag.Today = $"Response was generated for {id} at {DateTime.Now}";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}