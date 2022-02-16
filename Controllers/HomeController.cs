using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using random_passcode.Models;
using Microsoft.AspNetCore.Http;

namespace random_passcode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string[] passwordChars = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string password = "";
            Random rand = new Random();
            for (int i = 0; i <= 13; i++)
            {
                password = password + passwordChars[rand.Next(35)];
            }
            ViewBag.password = password;

            if (HttpContext.Session.GetInt32("counter") == null)
            {
                HttpContext.Session.SetInt32("counter", 0);
            }
            int? counter = HttpContext.Session.GetInt32("counter");
            HttpContext.Session.SetInt32("counter", (int)++counter);
            ViewBag.counter = counter;

            return View();
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
