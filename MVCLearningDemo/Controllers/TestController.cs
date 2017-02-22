using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

    public class TestController : Controller
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

        public ActionResult GetView()
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
            return View("MyView", employeeListViewModel);
        }
    }
}