using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneInc_test.Web.Models.Validation
{
    public class DateOfBirthAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var birthDate = (DateTime?)value;
            var now = DateTime.Now;
            if(birthDate==null)
                return new ValidationResult("Value is not defined");
            if ((now - birthDate.Value).TotalDays / 365 >= 18)
                return ValidationResult.Success;
            return new ValidationResult("Age must be greater than 18");
        }
    }
}
