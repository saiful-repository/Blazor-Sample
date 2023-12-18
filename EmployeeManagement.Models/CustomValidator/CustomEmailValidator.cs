using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Models.CustomValidator
{
    internal class CustomEmailValidator:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] emails = value.ToString().Split('@');
            if (emails[1] == "gmail.com")
            {
                return null;
            }
            return new ValidationResult("Email must be with gmail.com", new[] { validationContext.MemberName });
        }
    }
}
