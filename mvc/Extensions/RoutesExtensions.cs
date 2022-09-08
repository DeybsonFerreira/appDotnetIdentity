using Microsoft.AspNetCore.Builder;

namespace mvc.Extensions
{
    public static class RoutesExtensions
    {
        public static WebApplication AddCustomRoutes(this WebApplication app)
        {
            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }

    }
}
