using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLearningDemo.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [AllowAnonymous]
        public ActionResult Index()
        {
            Exception exception=new Exception("非法控制器和（或）行为");
            // ReSharper disable once Mvc.ControllerNotResolved
            // ReSharper disable once Mvc.ActionNotResolved
            HandleErrorInfo handleErrorInfo=new HandleErrorInfo(exception,"UnKnown", "UnKnown");
            return View("Error",handleErrorInfo);
        }
    }
}