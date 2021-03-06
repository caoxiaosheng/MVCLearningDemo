﻿using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using DataAccessLayer;
namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            //List<Employee> employees = new List<Employee>();
            //Employee emp = new Employee();
            //emp.FirstName = "johnson";
            //emp.LastName = " fernandes";
            //emp.Salary = 14000;
            //employees.Add(emp);

            //emp = new Employee();
            //emp.FirstName = "michael";
            //emp.LastName = "jackson";
            //emp.Salary = 16000;
            //employees.Add(emp);

            //emp = new Employee();
            //emp.FirstName = "robert";
            //emp.LastName = " pattinson";
            //emp.Salary = 20000;
            //employees.Add(emp);

            //return employees;
            SalesERPDAL salesErpdal=new SalesERPDAL();
            return salesErpdal.Employees.ToList();
        }

        public Employee SavEmployee(Employee employee)
        {
            SalesERPDAL salesErpdal=new SalesERPDAL();
            salesErpdal.Employees.Add(employee);
            salesErpdal.SaveChanges();
            return employee;
        }

        public void UploadEmployees(List<Employee> employees)
        {
            SalesERPDAL salesErpdal=new SalesERPDAL();
            salesErpdal.Employees.AddRange(employees);
            salesErpdal.SaveChanges();
        }

        //public bool IsValidUser(UserDetails userDetails)
        //{
        //    if (userDetails.UserName == "Admin" && userDetails.Password == "Admin")
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public UserStatus GetUserValidity(UserDetails userDetails)
        {
            if (userDetails.UserName == "Admin" && userDetails.UserName == "Admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            if (userDetails.UserName == "miao" && userDetails.Password == "miao")
            {
                return UserStatus.AuthenticatedUser;
            }
            return UserStatus.NonAuthenticatedUser;
        }
    }
}
