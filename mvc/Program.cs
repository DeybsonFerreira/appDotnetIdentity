using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mvc.ProgramConfig;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.AddCustomEnvironment();

builder.Services.AddCustomDependences(builder);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.SetCustomCookies();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error/500");
    app.UseStatusCodePagesWithRedirects("/Error/{0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

// Mapeando componentes Razor Pages (ex: Identity)
app.MapRazorPages();

app.AddCustomRoutes();
app.Run();