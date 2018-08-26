using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SimpleTwitterApp.UI.Filters
{
    public class CustomExceptionFilter : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                var exception = filterContext.Exception as HttpException;
                if (exception != null)
                {
                    var httpCode = (HttpStatusCode)exception.GetHttpCode();
                    switch (httpCode)
                    {
                        case HttpStatusCode.BadRequest:
                            break;
                        case HttpStatusCode.Unauthorized:
                            break;
                        case HttpStatusCode.Forbidden:
                            break;
                        case HttpStatusCode.NotFound:
                            break;
                        case HttpStatusCode.InternalServerError:
                            break;
                    }
                }
                var baseUri = new Uri(filterContext.HttpContext.Request.Url.AbsoluteUri);
                filterContext.Result = new RedirectResult(baseUri + "error");
            }
        }
    }
}