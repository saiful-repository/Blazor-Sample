using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Models.CustomValidator
{
    internal class CustomEmailValidator:ValidationAttribute
    {
        public string AllowDomain { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            string[] emails = value.ToString().Split('@');
            if (emails[1].ToUpper() == AllowDomain.ToUpper())
            {
                return null;
            }
            return new ValidationResult($"Email must be with {AllowDomain}", new[] { validationContext.MemberName });
        }
    }
}
