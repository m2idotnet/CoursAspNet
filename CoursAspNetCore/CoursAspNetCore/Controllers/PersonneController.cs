using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNetCore.Controllers
{
    public class PersonneController : Controller
    {
        public IActionResult Accueil()
        {
            return View();
        }
    }
}