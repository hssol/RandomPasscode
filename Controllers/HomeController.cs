using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            RandomNumberGenerator random = new RandomNumberGenerator();
            ViewBag.Randompass = random.RandomPassword();
            if(HttpContext.Session.GetInt32("count") == null)
            {
                int counter = 1;
                HttpContext.Session.SetInt32("count", counter);
            }
            else
            {
                int? counter = HttpContext.Session.GetInt32("count");
                int newcounter = (int)counter;
                newcounter++;
                HttpContext.Session.SetInt32("count", newcounter);
            }
            
            ViewBag.Count = HttpContext.Session.GetInt32("count");
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
