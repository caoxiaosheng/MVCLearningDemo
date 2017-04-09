using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModel
{
    public class FileUploadViewModel:BaseViewModel
    {
        public HttpPostedFileBase FileUpload { get; set; }
    }
}
