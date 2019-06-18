using Microsoft.AspNetCore.Mvc;
using PanierAspNetCore.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PanierAspNetCore.Models;

namespace PanierAspNetCore.Controllers
{
    public class ProduitController : Controller
    {
        public IActionResult Index()
        {
            
            return View(DataBaseContext.Instance.Produits.ToList());
        }


        public IActionResult AddProduit(Produit p)
        {
            if (HttpContext.Session == null)
            {
                return RedirectToAction("")
            }

            return View();
        }

    }
}
