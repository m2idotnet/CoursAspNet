using ApiVoiture.Models;
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
    public class UserController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] User u)
        {
            string token = Models.User.Login(u.UserName, u.Password);
            if(token != null)
            {
                return new JsonResult(new { error = false, token = token });
            }
            else
            {
                return new JsonResult(new { error = true });
            }
        }
    }
}
