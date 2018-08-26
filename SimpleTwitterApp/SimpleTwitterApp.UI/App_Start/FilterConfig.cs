using SimpleTwitterApp.UI.Filters;
using System.Web.Mvc;

namespace SimpleTwitterApp.UI.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomExceptionFilter());
        }
    }
}