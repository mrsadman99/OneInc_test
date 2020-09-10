using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneInc_test.Web.Models.Validation
{
    public class EndDateAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var endDate = (DateTime?)value;
            var startDate=((PolicyDtoCreate)validationContext
                .ObjectInstance).StartDate;
            if (endDate == null)
                return new ValidationResult(string.Empty);
            if ( endDate>startDate)
                return ValidationResult.Success;
            return new ValidationResult("End date must be more than start date");
        }
    }
}