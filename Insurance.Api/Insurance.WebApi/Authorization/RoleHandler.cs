using InsuranceEngine.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Insurance.WebApi.Authorization
{
    public class RoleHandler : AuthorizationHandler<RolesAuthorizationRequirement>
    {
        private readonly IUserEngine _userEngine;

        public RoleHandler(IUserEngine userEngine)
        {
            _userEngine = userEngine;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Fail();
            }
            else
            {
                var currentUserId = int.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var roles = await _userEngine.GetRolesByUserIdAsync(currentUserId);

                var isValidRole = roles.Intersect(requirement.AllowedRoles).Any();
                if (isValidRole)
                {
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
