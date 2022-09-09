using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mvc.Areas.Identity.Data;
using System;

namespace mvc.ProgramConfig
{
    public static class RegisterIdentityConfig
    {
        public static IServiceCollection AddIdentityDependences(this IServiceCollection service, WebApplicationBuilder builder)
        {
            //conectionString do appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("AppDotnetIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDotnetIdentityContextConnection' not found.");

            service.AddDbContext<AppDotnetIdentityContext>(options =>
            options.UseSqlServer(connectionString));

            service.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()//parte visual do identity
                .AddRoles<IdentityRole>()  // habilitar suporte roles.
                .AddEntityFrameworkStores<AppDotnetIdentityContext>(); //usando com entity framework
            return service;
        }
    }
}
