using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPSlack.Models;
using TPSlack.Tools;

namespace TPSlack.Controllers
{
    [Route("[controller]")]
    [Authorize("slackPolicy")]
    public class MessageController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(new { messages = DatabaseContext.Instance.Messages.Include("user").Select(x => new { content = x.Content, DateAdded = x.DateAdded, user = x.user.UserName, id=x.Id }).ToList() });
        }

        [HttpPost]
        public IActionResult Post([FromBody]Message message, [FromHeader] string token)
        {
            //string token = Request.Headers["token"].ToString();
            message.user = UserSlack.GetUserByToken(token);
            return new JsonResult(new { Status = message.Add()});
        }
    }
}