using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CreateEmployeeViewModel:BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salary { get; set; }
    }
}
