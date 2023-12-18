using EmployeeManagement.Models;
using EmploymentManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmploymentManagement.Web.Pages
{
    public class EmployeeListBase:ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees  = (await EmployeeService.GetEmployees()).ToList();
        }

        protected int totalCount { get; set; } = 0;
        public void ShowCountSelection(bool isSelected)
        {
            if (isSelected)
            {
                totalCount++;
            }
            else
            {
                totalCount--;
            }
        }
    }
}
