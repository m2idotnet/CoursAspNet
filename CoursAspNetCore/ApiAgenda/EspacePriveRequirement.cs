using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiAgenda
{
    public class EspacePriveRequirement : AuthorizationHandler<EspacePriveRequirement>, IAuthorizationRequirement
    {
        public bool access { get; set; }

        private IHttpContextAccessor accessor;
        public EspacePriveRequirement()
        {

        }
        public EspacePriveRequirement(IHttpContextAccessor h)
        {
            accessor = h;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EspacePriveRequirement requirement)
        {
            //access  au donnée dans des sessions
            //if(accessor.HttpContext.Request.Headers["token"] != default(StringValues))
            //{
            //    return Task.Run(() => context.Succeed(requirement));
            //}
            //else
            //{
            //    return Task.Run(() => context.Fail());
            //}
            if (access)
            {
                return Task.Run(() => context.Succeed(requirement));
            }
            else
            {
                AuthorizationFilterContext filtre = context.Resource as AuthorizationFilterContext;
                //reponse avec une redirection vers
                filtre.Result = new RedirectToActionResult("Get", "Contact", null);
                //Reponse pour une api avec resultat json non autorisé
                //filtre.Result = new JsonResult(new { HttpStatusCode.Unauthorized});
                return Task.Run(() => context.Succeed(requirement));
            }
        }
    }
}
