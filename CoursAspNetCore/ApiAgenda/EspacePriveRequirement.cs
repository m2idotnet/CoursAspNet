using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda
{
    public class EspacePriveRequirement : AuthorizationHandler<EspacePriveRequirement>, IAuthorizationRequirement
    {
        public bool access { get; set; }

        private IHttpContextAccessor accessor;

        public EspacePriveRequirement(IHttpContextAccessor h)
        {
            accessor = h;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EspacePriveRequirement requirement)
        {
            if(accessor.HttpContext.Request.Headers["token"] != default(StringValues))
            {
                return Task.Run(() => context.Succeed(requirement));
            }
            else
            {
                return Task.Run(() => context.Fail());
            }
           //if(access)
           // {
           //     return Task.Run(() => context.Succeed(requirement));
           // }
           //else
           // {
           //     return Task.Run(() => context.Fail());
           // }
        }
    }
}
