using SimpleTwitterApp.UI.Constants;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleTwitterApp.UI.Filters
{
    public class CustomExceptionFilter : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                var exception = filterContext.Exception as HttpException;
                var message = string.Empty;
                if (exception != null)
                {
                    var httpCode = (HttpStatusCode)exception.GetHttpCode();
                    switch (httpCode)
                    {
                        case HttpStatusCode.BadRequest:
                            message = "Problem with your input data! Please try again.";
                            break;
                        case HttpStatusCode.Unauthorized:
                            message = "You are not authorized to do this operation. Please login and try agian.";
                            break;
                        case HttpStatusCode.Forbidden:
                            message = "You don't access to do this operation, please contact your system administrator.";
                            break;
                        case HttpStatusCode.NotFound:
                            message = "The page your are looking for is not found.";
                            break;
                        case HttpStatusCode.InternalServerError:
                            message = "Server error! Please try after sometime";
                            break;
                        default:
                            message = "Sorry! Something is not working, please try agian after sometime.";
                            break;
                    }
                }
                var baseUri = new Uri(filterContext.HttpContext.Request.Url.AbsoluteUri);
                var currentController = filterContext.Controller as Controller;
                currentController.TempData[AppConstants.ERROR_MESSAGE] = message;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
                {
                    { "controller", "error" },
                    { "action", "index" }
                });
                filterContext.ExceptionHandled = true;
            }
        }
    }
}