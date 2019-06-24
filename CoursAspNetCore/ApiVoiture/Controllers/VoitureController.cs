using ApiVoiture.Models;
using ApiVoiture.Tools;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ApiVoiture.Controllers
{
    [Route("[controller]")]
    [EnableCors("AllAccessPolicy")]
    public class VoitureController : Controller
    {
        [HttpGet]
        public IActionResult Get([FromHeader] string token)
        {
            if (Models.User.TestToken(token))
            {
                List<dynamic> l = new List<dynamic>();
                foreach(Voiture v in DataBaseContext.Instance.Voitures.ToList())
                {
                    l.Add(new { voiture = v, Edit = "http://localhost/edit/"+v.Id, Get = "http://localhost/get/"+v.Id});
                }
                return new JsonResult(l);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
