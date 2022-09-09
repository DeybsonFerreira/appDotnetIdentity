using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using mvc.Extensions;

namespace mvc.ProgramConfig
{
    public static class RegisterClaimsConfig
    {
        public static IServiceCollection AddCustomClaims(this IServiceCollection service)
        {
            //add policy
            service.AddAuthorization(options =>
            {
                //options.AddPolicy("Delete", policy => policy.RequireClaim("Delete"));

                options.AddPolicy("Create", policy => policy.Requirements.Add(new PermissionRequiredExtensions("Create")));
                options.AddPolicy("Read", policy => policy.Requirements.Add(new PermissionRequiredExtensions("Read")));
                options.AddPolicy("Update", policy => policy.Requirements.Add(new PermissionRequiredExtensions("Update")));
                options.AddPolicy("Delete", policy => policy.Requirements.Add(new PermissionRequiredExtensions("Delete")));

            });
            return service;
        }

    }
}
