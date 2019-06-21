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
                return new JsonResult(DataBaseContext.Instance.Voitures.ToList());
            }
            else
            {
                return NotFound();
            }
        }
    }
}
