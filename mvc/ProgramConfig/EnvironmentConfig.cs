using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace mvc.ProgramConfig
{
    public static class EnvironmentConfig
    {
        public static WebApplicationBuilder AddCustomEnvironment(this WebApplicationBuilder builder)
        {
            builder.Configuration
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();

            return builder;
        }
    }
}
