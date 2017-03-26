using System.Collections.Generic;

namespace ViewModel
{
    public class EmployeeListViewModel
    {
        public List<EmployeeViewModel> EmployeeViewModels { get; set; }
        
        public string UserName { get; set; }

        public FooterViewModel FooterViewModel { get; set; }
    }
}
