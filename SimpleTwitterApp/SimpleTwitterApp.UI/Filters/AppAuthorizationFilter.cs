using System;
using System.Web;
using System.Web.Mvc;

namespace SimpleTwitterApp.UI.Filters
{
    public class AppAuthorizationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        const string USER_SESSION = "UserSession";

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!IsUserAuthenticated(filterContext.HttpContext))
            {
                var baseUri = new Uri(filterContext.HttpContext.Request.Url.AbsoluteUri);
                filterContext.Result = new RedirectResult(baseUri + "account");
            }   
        }

        private bool IsUserAuthenticated(HttpContextBase httpContext)
        {
            try
            {
                if (httpContext != null &&
                    httpContext.Session != null &&
                    httpContext.Session[USER_SESSION] != null )
                {
                    return true;
                }
            }
            catch
            {
                // nom the errors...
            }

            return false;
        }
    }
}