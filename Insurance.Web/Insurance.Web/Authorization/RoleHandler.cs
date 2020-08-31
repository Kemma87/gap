using Insurance.Web.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Insurance.Web.Authorization
{
    public class RoleHandler : AuthorizationHandler<RolesAuthorizationRequirement>
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IAppClient _client;
        public RoleHandler(IHttpContextAccessor httpContext, IAppClient client)
        {
            _httpContext = httpContext;
            _client = client;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        {
            _httpContext.HttpContext.Session.Remove("roles");

            if (!context.User.Identity.IsAuthenticated)
            {
                context.Fail();
            }
            else
            {
                var currentUserId = int.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                var roles = await _client.GetRolesByUserIdAsync(currentUserId);
                var isValidRole = roles.Intersect(requirement.AllowedRoles).Any();
                if (isValidRole)
                {
                    _httpContext.HttpContext.Session.SetString("roles", string.Join(",", roles));
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
        }
    }
}
