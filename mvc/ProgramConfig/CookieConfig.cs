using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace mvc.ProgramConfig
{
    public static class CookieConfig
    {
        public static IServiceCollection SetCustomCookies(this IServiceCollection service)
        {

            // Politica de cookies (LGPD)
            service.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            return service;
        }
    }
}
