using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace mvc.Extensions
{
    public class PermissionRequiredExtensions : IAuthorizationRequirement
    {
        public string PermissionName { get; set; }
        public PermissionRequiredExtensions(string permissionName)
        {
            PermissionName = permissionName;
        }
    }
    public class PermissionRequiredHandler : AuthorizationHandler<PermissionRequiredExtensions>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequiredExtensions requirement)
        {
            if (context.User.HasClaim(c => c.Type == "Permission" && c.Value.Contains(requirement.PermissionName)))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
