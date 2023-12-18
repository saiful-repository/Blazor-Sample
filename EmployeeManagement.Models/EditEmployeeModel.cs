using EmployeeManagement.Models.CustomValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [CustomEmailValidator(AllowDomain = "gmail.com")]
        public string Email { get; set; }
        [Compare("Email", ErrorMessage = "Email doesn't match")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PhotoPath { get; set; }
        public int DepartmentId { get; set; }
        [ValidateComplexType]
        public Department Department { get; set; } = new Department();
    }
}
