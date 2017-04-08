using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace MVCLearningDemo.Filter
{
    public class HeaderFooterFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewResult viewResult=filterContext.Result as  ViewResult;
            if (viewResult != null)
            {
                BaseViewModel baseViewModel=viewResult.Model as BaseViewModel;
                if (baseViewModel != null)
                {
                    baseViewModel.UserName = HttpContext.Current.User.Identity.Name;
                    baseViewModel.FooterViewModel=new FooterViewModel()
                    {
                        CompanyName = "喵喵喵",
                        Year = DateTime.Now.Year.ToString()
                    };
                }
            }
        }
    }
}