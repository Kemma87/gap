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
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContext;
        public RoleHandler(IConfiguration config, IHttpContextAccessor httpContext)
        {
            _config = config;
            _httpContext = httpContext;
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
                var token = _httpContext.HttpContext.Session.GetString("token");
                var currentUserId = int.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                using var httpClient = new HttpClient();          
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using var response = await httpClient.GetAsync($"{_config.GetSection("AppSettings:BaseUrl").Value}/api/auth/{currentUserId}/roles");
                string apiResponse = await response.Content.ReadAsStringAsync();

                var roles = JsonConvert.DeserializeObject<List<string>>(apiResponse);

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
