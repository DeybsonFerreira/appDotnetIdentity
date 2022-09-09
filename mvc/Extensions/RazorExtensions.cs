using Microsoft.AspNetCore.Mvc.Razor;
using mvc.ProgramConfig;

namespace mvc.Extensions
{
    public static class RazorExtensions
    {
        public static bool IfClaim(this RazorPage page, string claiName, string claimValue)
        {
            return CustomAuthorizationConfig.ValidUserClaims(page.Context, claiName, claimValue);
        }
    }
}
