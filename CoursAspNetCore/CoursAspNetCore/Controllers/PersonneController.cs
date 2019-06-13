using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNetCore.Controllers
{
    public class PersonneController : Controller
    {
        public IActionResult Accueil()
        {
            //ViewData
            //ViewData["nom"] = "abadi";
            //ViewData["prenom"] = "Ihab";
            //ViewData["ListeString"] = new List<string> { "toto", "tata", "titi" };
            //ViewBag
            ViewBag.nom = "abadi";
            ViewBag.prenom = "Ihab";
            ViewBag.ListeString = new List<string> { "toto", "tata", "titi" };

            ViewBag.ListePersonnes = new List<Personne>
            {
                new Personne {Nom = "toto", Prenom = "tata"},
                new Personne {Nom = "titi", Prenom = "minet"},
            };
            
            return View();
        }

        //Methode de redirection

        public IActionResult Operation()
        {
            //redirection vers une action à l'interieur du même controller
            //return RedirectToAction("Accueil");

            //redirection vers une action d'un autre controller
            //return RedirectToAction("Index", "Home");

            //Autre methode de redirection
            //redirection de type 301 <=> permanente
            //return RedirectPermanent("Lien de redirection");

            //redirect to route
            //return RedirectToRoute(new { controller = "Home", action = "Index" });

            //redirect to route en utilisant le nom de la route
            return RedirectToRoute("RoutePersonne");
        }
    }
}