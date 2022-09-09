using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mvc.Areas.Identity.Data;
using System;

namespace mvc.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddCustomDependences(this IServiceCollection service, WebApplicationBuilder builder)
        {

            RegisterIdentityExtensions.AddIdentityDependences(service, builder);

            RegisterClaimsExtensions.AddCustomClaims(service);

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
