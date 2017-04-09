using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BusinessEntities;
using BusinessLayer;
using MVCLearningDemo.Filter;
using ViewModel;

namespace MVCLearningDemo.Controllers
{
    public class BulkUploadController:AsyncController
    {
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        public async Task<ActionResult> Upload(FileUploadViewModel fileUploadViewModel)
        {
            int t1 = Thread.CurrentThread.ManagedThreadId;
            //var employees = GetEmployees(fileUploadViewModel);
            var employees = await Task.Factory.StartNew<List<Employee>>(() =>
            {
                return GetEmployees(fileUploadViewModel);
            });
            int t2 = Thread.CurrentThread.ManagedThreadId;
            EmployeeBusinessLayer employeeBusinessLayer=new EmployeeBusinessLayer();
            employeeBusinessLayer.UploadEmployees(employees);
            return RedirectToAction("Index","Employee");
        }

        private List<Employee> GetEmployees(FileUploadViewModel fileUploadViewModel)
        {
            List<Employee> employees=new List<Employee>();
            using (StreamReader streamReader=new StreamReader(fileUploadViewModel.FileUpload.InputStream))
            {
                streamReader.ReadLine();
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    var values = line.Split(',');
                    Employee employee=new Employee()
                    {
                        FirstName = values[0],
                        LastName = values[1],
                        Salary = int.Parse(values[2])
                    };
                    employees.Add(employee);
                }
            }
            return employees;
        }
    }
}