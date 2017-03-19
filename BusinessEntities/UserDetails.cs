using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class UserDetails
    {
        [StringLength(7,MinimumLength = 2,ErrorMessage = "用户名必须在2个字符到7个字符之间呦~~o(=•ェ•=)m")]
        public string UserName { get; set; }
        
        public string Password { get; set; }
    }
}
