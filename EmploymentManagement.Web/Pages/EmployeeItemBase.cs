using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;

namespace EmploymentManagement.Web.Pages
{
    public class EmployeeItemBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public EventCallback<bool> onCheckSelection { get; set; }

        [Parameter]
        public EventCallback<int> onEmployeeDelete { get; set; }
        public async Task CheckBoxChanged(ChangeEventArgs e)
        {
           await onCheckSelection.InvokeAsync((bool)e.Value);
        }
        public async Task DeleteEmployee(int id)
        {
            await onEmployeeDelete.InvokeAsync(id);
        }
    }
}
