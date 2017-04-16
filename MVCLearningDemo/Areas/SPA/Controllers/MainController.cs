using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLayer;
using ViewModel;
using ViewModel.SPA;
using EmployeeListViewModel = ViewModel.SPA.EmployeeListViewModel;
using EmployeeViewModel=ViewModel.SPA.EmployeeViewModel;

namespace MVCLearningDemo.Areas.SPA.Controllers
{
    public class MainController : Controller
    {
        // GET: SPA/Main
        public ActionResult Index()
        {
            MainViewModel mainViewModel=new MainViewModel();
            mainViewModel.UserName = User.Identity.Name;
            mainViewModel.FooterViewModel=new FooterViewModel()
            {
                CompanyName = "喵喵喵",
                Year = DateTime.Now.Year.ToString()
            };
            return View("Index",mainViewModel);
        }

        public ActionResult EmployeeList()
        {
            EmployeeListViewModel employeeListViewModel=new EmployeeListViewModel();
            EmployeeBusinessLayer employeeBusinessLayer=new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.GetEmployees();
            List<EmployeeViewModel> employViewModels = new List<EmployeeViewModel>();
            foreach (var employee in employees)
            {
                EmployeeViewModel employeeViewModel=new EmployeeViewModel();
                employeeViewModel.EmployeeName = employee.FirstName + " " + employee.LastName;
                employeeViewModel.Salary = employee.Salary.Value.ToString("C");
                if (employee.Salary > 15000)
                {
                    employeeViewModel.SalaryColor = "yellow";
                }
                else
                {
                    employeeViewModel.SalaryColor = "green";
                }
                employViewModels.Add(employeeViewModel);
            }
            employeeListViewModel.Employees = employViewModels;
            return View("EmployeeList", employeeListViewModel);
        }

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
}