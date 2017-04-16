using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLayer;
using MVCLearningDemo.Filter;
using ViewModel;

namespace MVCLearningDemo.Controllers
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return CustomerName + "|" + Address;
        }
    }

    [Authorize]
    public class EmployeeController : Controller
    {
        //// GET: Test
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public string GetString()
        {
            return "Hello World is old now. It’s time for wassup bro ;)";
        }

        [NonAction]
        public string SimpleMethod()
        {
            return "Hi, I am not action method";
        }

        public Customer GetCustomer()
        {
            Customer c = new Customer();
            c.CustomerName = "Customer 1";
            c.Address = "Address1";
            return c;
        }

        [HeaderFooterFilter]
        [Route("Employee/List")]
        public ActionResult Index()
        {
            //Employee employee = new Employee()
            //{
            //    FirstName = "Sukesh",
            //    LastName = "Marla",
            //    Salary = 20000
            //};
            //ViewData["Employee"] = employee;
            //ViewBag.Employee = employee;
            //EmployeeViewModel employeeViewModel=new EmployeeViewModel()
            //{
            //    EmployeeName = employee.FirstName+" "+employee.LastName,
            //    Salary = employee.Salary.ToString("C"),
            //    SalaryColor = employee.Salary>15000?"yellow":"green",
            //    UserName = "Admin"
            //};

            EmployeeListViewModel employeeListViewModel=new EmployeeListViewModel();
            EmployeeBusinessLayer employeeBusinessLayer=new EmployeeBusinessLayer();
            var employees = employeeBusinessLayer.GetEmployees();
            var employeeViews=new List<EmployeeViewModel>();
            foreach (var employee in employees)
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel()
                {
                    EmployeeName = employee.FirstName + " " + employee.LastName,
                    Salary = employee.Salary.HasValue? employee.Salary.Value.ToString("C"):"0",
                    SalaryColor = employee.Salary > 15000 ? "yellow" : "green",
                };
                employeeViews.Add(employeeViewModel);
            }
            employeeListViewModel.EmployeeViewModels = employeeViews;
            //employeeListViewModel.UserName = User.Identity.Name;
            //FooterViewModel footerViewModel=new FooterViewModel()
            //{
            //    CompanyName = "喵喵喵",
            //    Year = DateTime.Now.Year.ToString()
            //};
            //employeeListViewModel.FooterViewModel = footerViewModel;
            return View("Index", employeeListViewModel);
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew()
        {
            var createEmployeeViewModel = new CreateEmployeeViewModel();
            //{
            //    UserName = User.Identity.Name,
            //    FooterViewModel = new FooterViewModel()
            //    {
            //        CompanyName = "喵喵喵",
            //        Year = DateTime.Now.Year.ToString()
            //    }
            //};
            return View("CreateEmployee", createEmployeeViewModel);
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult SaveEmployee(Employee employee, string btnSubmit)
        {
            switch (btnSubmit)
            {
                case "Save Employee":
                    //return Content(employee.FirstName + "|" + employee.LastName + "|" + employee.Salary);
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                        employeeBusinessLayer.SavEmployee(employee);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel createEmployeeViewModel = new CreateEmployeeViewModel();
                        //{
                        //    FirstName = employee.FirstName,
                        //    LastName = employee.LastName,
                        //    Salary = employee.Salary.HasValue?employee.Salary.ToString():ModelState["Salary"].Value.AttemptedValue
                        //};
                        return View("CreateEmployee", createEmployeeViewModel);
                    }
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
        //public ActionResult SaveEmployee( )
        //{
        //    Employee employee=new Employee()
        //    {
        //        FirstName = Request.Form["FirstName"],
        //        LastName = Request.Form["LastName"],
        //        Salary = int.Parse(Request.Form["Salary"])
        //    };
        //    string btnSubmit = Request.Form["BtnSubmit"];
        //    switch (btnSubmit)
        //    {
        //        case "Save Employee":
        //            return Content(employee.FirstName + "|" + employee.LastName + "|" + employee.Salary);
        //        case "Cancel":
        //            return RedirectToAction("Index");
        //    }
        //    return new EmptyResult();
        //}

        //public ActionResult SaveEmployee([ModelBinder(typeof(MyEmployeeModelBinder))]Employee employee, string btnSubmit)
        //{

        //    switch (btnSubmit)
        //    {
        //        case "Save Employee":
        //            return Content(employee.FirstName + "|" + employee.LastName + "|" + employee.Salary);
        //        case "Cancel":
        //            return RedirectToAction("Index");
        //    }
        //    return new EmptyResult();
        //}

        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }
    }

    //public class MyEmployeeModelBinder : DefaultModelBinder
    //{
    //    protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
    //    {
    //        Employee e = new Employee();
    //        e.FirstName = controllerContext.RequestContext.HttpContext.Request.Form["FirstName"];
    //        e.LastName = controllerContext.RequestContext.HttpContext.Request.Form["LastName"];
    //        e.Salary = int.Parse(controllerContext.RequestContext.HttpContext.Request.Form["Salary"]);
    //        return e;
    //    }
    //}
}