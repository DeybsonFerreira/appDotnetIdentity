using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace mvc.ProgramConfig
{
    public static class CustomAuthorizationConfig
    {

        public static bool ValidUserClaims(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                    context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }
    }

    public class RequiredClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;
        public RequiredClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!CustomAuthorizationConfig.ValidUserClaims(context.HttpContext, _claim.Type, _claim.Value))
            {
                //context.Result = new ForbidResult();
                context.Result = new StatusCodeResult(403);//Customizado
            }
        }
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string clainName, string claimValue) : base(typeof(RequiredClaimFilter))
        {
            Arguments = new object[]
            {
                new Claim(clainName, claimValue)
            };
        }
    }

}
