using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;
using mvc.ProgramConfig;
using System;
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

    public JsonResult PageWithError()
    {
        throw new Exception("Erro proposital");
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

    [Route("Error/{statusCode:length(3,3)}")] //3 caracteres ex: 000
    public IActionResult Error(int statusCode)
    {
        ErrorViewModel errorView = new() { RequestId = Activity.Current?.Id };

        if (statusCode == StatusCodes.Status500InternalServerError)
        {
            errorView.Title = "InternalServerError";
            errorView.Message = "Ocorreu um erro 500";
        }
        else if (statusCode == StatusCodes.Status400BadRequest)
        {
            errorView.Title = "BadRequest";
            errorView.Message = "A Página que está procurando não existe! <br/> Em caso de dúvidas entre em contato com nosso suporte";
        }
        else if (statusCode == StatusCodes.Status403Forbidden)
        {
            errorView.Title = "Forbidden";
            errorView.Message = "Você nao tem permissão para este recurso";
        }
        else if (statusCode == StatusCodes.Status404NotFound)
        {
            errorView.Title = "NotFound";
            errorView.Message = "A Página que está procurando não existe! <br/> Em caso de dúvidas entre em contato com nosso suporte";
        }
        else
        {
            errorView.Title = "ERRO";
            errorView.Message = $"Ocorreu um erro {statusCode}";
        }

        return View("Error", errorView);
    }
}
