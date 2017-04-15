using System.Web.Mvc;
using MVCLearningDemo.Filter;

namespace MVCLearningDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new EmployeeExceptionFilter());
        }
    }
}
