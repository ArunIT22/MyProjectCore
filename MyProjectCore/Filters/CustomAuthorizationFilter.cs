using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace MyProjectCore.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public class AdminOnlyAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool checkUserRole(ClaimsPrincipal user, string roleName)
            {
                var admin = user.FindFirstValue(ClaimTypes.Role);
                return admin == roleName;
            }

            bool isAdmin = checkUserRole(context.HttpContext.User, "admin");
            if (!isAdmin)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class HttpsOnlyAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.IsHttps)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
        }
    }
}
