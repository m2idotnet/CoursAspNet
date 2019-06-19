using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoursAspNetCoreAjax.Models;
using System.Threading;

namespace CoursAspNetCoreAjax.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TestAjax(string toto, string tata, bool dataPlus)
        {
            Thread.Sleep(3000);
            ViewBag.toto = toto;
            ViewBag.tata = tata;
            ViewBag.dataPlus = dataPlus;
            return PartialView();
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(string Nom, string Prenom)
        {
            return new ContentResult { Content = "Ajouté : "+Nom+" "+Prenom };
        }

        public IActionResult TestChamp(string valueChamp)
        {
            if(valueChamp != null && valueChamp.Length > 3)
            {
                return new JsonResult(new { error = false });
            }
            else
            {
                return new JsonResult(new { error = true });
            }
        }
    }
}
