using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using mvc.Extensions;

namespace mvc.ProgramConfig
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddCustomDependences(this IServiceCollection service, WebApplicationBuilder builder)
        {

            service.AddIdentityDependences(builder);

            service.AddCustomClaims();

            MyAllSingleton(service);
            MyScoped(service);

            return service;
        }

        private static IServiceCollection MyScoped(IServiceCollection service)
        {
            service.AddScoped<CustonActionFilterExtensions>();
            return service;
        }

        private static IServiceCollection MyAllSingleton(IServiceCollection service)
        {
            service.AddSingleton<IAuthorizationHandler, PermissionRequiredHandler>();
            return service;
        }

    }
}
