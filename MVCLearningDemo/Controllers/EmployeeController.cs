using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLayer;
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
                    Salary = employee.Salary.ToString("C"),
                    SalaryColor = employee.Salary > 15000 ? "yellow" : "green",
                };
                employeeViews.Add(employeeViewModel);
            }
            employeeListViewModel.EmployeeViewModels = employeeViews;
            employeeListViewModel.UserName = "Admin";
            return View("Index", employeeListViewModel);
        }

        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }


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
                        return View("CreateEmployee");
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