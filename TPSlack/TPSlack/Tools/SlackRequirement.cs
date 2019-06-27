using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using TPSlack.Models;

namespace TPSlack.Tools
{
    public class SlackRequirement : AuthorizationHandler<SlackRequirement>, IAuthorizationRequirement
    {
        private IHttpContextAccessor accessor;

        public SlackRequirement(IHttpContextAccessor a)
        {
            accessor = a;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SlackRequirement requirement)
        {
            string token = accessor.HttpContext.Request.Headers["token"].ToString();
            if(UserSlack.GetUserByToken(token) == null)
            {
                AuthorizationFilterContext filtre = context.Resource as AuthorizationFilterContext;
                filtre.Result = new JsonResult(new { HttpStatusCode.Unauthorized });
            }

            return Task.Run(() => context.Succeed(requirement));
        }
    }
}
