using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorrectionAjaxFormulaire.Models;
using System.Text.RegularExpressions;
using System.Threading;

namespace CorrectionAjaxFormulaire.Controllers
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

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {

            }
            Thread.Sleep(3000);

            return new JsonResult(new { error = false, message = "User added" });
        }


        public IActionResult TestChamp(string nomChamp, string valueChamp)
        {
            bool error = true;
            string message = "";
            if(nomChamp == "Nom" || nomChamp == "Prenom")
            {
                if(valueChamp != null && valueChamp.Length > 3)
                {
                    error = false;
                }
                else
                {
                    message = "Merci de saisir min 4 caractères dans votre : " + nomChamp;
                }
            }
            else if(nomChamp == "Email")
            {
                Regex r = new Regex(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$");
                if (valueChamp != null && r.IsMatch(valueChamp))
                {
                    error = false;
                }
                else
                {
                    message = "Merci de saisir un email correct";
                }
            }
            else if(nomChamp == "Tel")
            {
                Regex r = new Regex(@"^0([1-9]{1})([-.\]?[0-9]{2}){4}");
                if (valueChamp != null && r.IsMatch(valueChamp))
                {
                    error = false;
                }
                else
                {
                    message = "Merci de saisir un tel correct";
                }
            }

            return new JsonResult(new { error = error, message = message });
        } 
    }
}
