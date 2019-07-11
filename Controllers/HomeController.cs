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
        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Count")==null)
            {
                HttpContext.Session.SetInt32("Count", 0);
            }
            else
            {
            HttpContext.Session.GetString("RandString");
            int? Count = HttpContext.Session.GetInt32("Count");
            ViewBag.Count = HttpContext.Session.GetInt32("Count");
            ViewBag.RandString = HttpContext.Session.GetString("RandString");
            }
            return View("Index");
        }

        [HttpPost("process")]
        public IActionResult Process()
        {
            int Count = (int)HttpContext.Session.GetInt32("Count");
            Count += 1;
            HttpContext.Session.SetInt32("Count", Count);
            char [] Letters ="qwertyuiopasdfghjklzxcvbnm1234567890".ToCharArray();
            Random rand = new Random();
            string RandString = "";
            for(int i = 0; i < 14; i++)
            {
                RandString += Letters[rand.Next(0,36)].ToString();
            }
            HttpContext.Session.SetString("RandString", RandString);
            Console.WriteLine(RandString);
            Console.WriteLine(Count);
            return RedirectToAction("Index");
        }

    }
}
