using Microsoft.AspNetCore.Mvc.Razor;

namespace mvc.Extensions
{
    public static class RazorExtensions
    {
        public static bool IfClaim(this RazorPage page, string claiName, string claimValue)
        {
            return CustomAuthorization.ValidUserClaims(page.Context, claiName, claimValue);
        }
    }
}
