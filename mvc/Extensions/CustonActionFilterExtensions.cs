using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace mvc.Extensions
{
    public class CustonActionFilterExtensions : IActionFilter
    {
        private readonly ILogger<CustonActionFilterExtensions> _logger;

        public CustonActionFilterExtensions(ILogger<CustonActionFilterExtensions> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //somente de usuário autenticado
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = context.HttpContext.User.Identity.Name;
                var urlAcess = context.HttpContext.Request.GetDisplayUrl();

                _logger.LogInformation($"O usuário :{username}, entrou em {urlAcess}");
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
