using Microsoft.AspNetCore.Builder;

namespace mvc.ProgramConfig
{
    public static class RoutesConfig
    {
        public static WebApplication AddCustomRoutes(this WebApplication app)
        {
            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }

    }
}
