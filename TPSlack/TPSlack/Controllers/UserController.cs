using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPSlack.Models;

namespace TPSlack.Controllers
{
    [Route("[controller]")]
    [EnableCors("AllAccess")]
    public class UserController : Controller
    {
        [HttpPost]
        [Route("Register")]
        public IActionResult Post([FromBody] UserSlack user)
        {
            //Response.StatusCode = 201;
            //on retourne un objet json qui contient le type de retour envoyé par la méthode Add de l'utilisateur
            return new JsonResult(new { Status = user.Add() });
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult PostLogin([FromBody] UserSlack user)
        {
            return new JsonResult(new { token = user.Login() });
        }


    }
}
