using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessEntities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [FirstNameValidation]
        public string FirstName { get; set; }

        [StringLength(5,ErrorMessage = "LastName不能超过5个字符")]
        public string LastName { get; set; }

        public int Salary { get; set; } 
    }

    public class FirstNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("请提供FirstName");
            }
            else
            {
                if (value.ToString().Contains("@"))
                {
                    return new ValidationResult("FirstName不能包含@");
                }
            }
            return ValidationResult.Success;
        }
    }
}
