using System.Diagnostics;
using Beauty_tochka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Beauty_tochka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.ApiUrl = _configuration["ApiUrl"];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Services()
        {
            ViewBag.ApiUrl = _configuration["ApiUrl"];
            return View();
        }

        public IActionResult Masters()
        {
            ViewBag.ApiUrl = _configuration["ApiUrl"];
            return View();
        }

        public IActionResult Record()
        {
            ViewBag.ApiUrl = _configuration["ApiUrl"];
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Cookies()
        {
            ViewBag.ApiUrl = _configuration["ApiUrl"];
            return View();
        }

        public IActionResult ServiceDetails(string service)
        {
            ViewBag.ApiUrl = _configuration["ApiUrl"];
            ViewData["ServiceName"] = service;
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.ApiUrl = _configuration["ApiUrl"];
            return View();
        }

        public IActionResult Register()
        {
            ViewBag.ApiUrl = _configuration["ApiUrl"];
            return View();
        }

        public IActionResult Reviews()
        {
            ViewBag.ApiUrl = _configuration["ApiUrl"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
