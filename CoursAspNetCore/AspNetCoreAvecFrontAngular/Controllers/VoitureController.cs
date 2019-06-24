using AspNetCoreAvecFrontAngular.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAvecFrontAngular.Controllers
{
    [Route("[controller]")]
    public class VoitureController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(DataBaseContext.Instance.Voitures.ToList());
        }
    }
}
