using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class EmployeeListViewModel
    {
        public List<EmployeeViewModel> EmployeeViewModels { get; set; }
        
        public string UserName { get; set; }
    }
}
