using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mvc.Areas.Identity.Data;
using mvc.Extensions;
using System;

namespace mvc.ProgramConfig
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddCustomDependences(this IServiceCollection service, WebApplicationBuilder builder)
        {

            service.AddIdentityDependences(builder);

            service.AddCustomClaims();

            AddAllSingleton(service);

            return service;
        }

        private static IServiceCollection AddAllSingleton(IServiceCollection service)
        {
            service.AddSingleton<IAuthorizationHandler, PermissionRequiredHandler>();
            return service;
        }

    }
}
