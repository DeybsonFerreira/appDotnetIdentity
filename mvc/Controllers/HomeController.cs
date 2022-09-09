using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;
using mvc.ProgramConfig;
using System.Diagnostics;

namespace mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    public IActionResult Authenticated()
    {
        return View();
    }

    [Authorize(Roles = "Admin,User")]
    public IActionResult Admin()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Authorize(Policy = "Delete")]
    public IActionResult Delete()
    {
        return View();
    }

    //adicionar no aspnetUserClaims on Table database
    [ClaimsAuthorize("Home", "Delete")]
    public IActionResult ClaimsAuthorize()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
