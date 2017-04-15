using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLearningDemo.Logger;

namespace MVCLearningDemo.Filter
{
    public class EmployeeExceptionFilter:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            FileLogger fileLogger=new FileLogger();
            fileLogger.LogException(filterContext.Exception);
            //base.OnException(filterContext);
            filterContext.ExceptionHandled = true;
            filterContext.Result=new ContentResult()
            {
                Content = "对不起！喵"
            };
        }
    }
}