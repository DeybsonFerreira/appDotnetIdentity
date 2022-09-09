using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace mvc.Extensions
{
    public static class CookieExtensions
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
