using Microsoft.AspNetCore.Components;
using PieShop.App.Components;
using PieShop.App.Services;
using PieShop.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.App.Pages
{
    public partial class EmployeeOverview
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
        }

        protected AddEmployeeDialog AddEmployeeDialog { get; set; }

        protected void QuickAddEmployee()
        {
            AddEmployeeDialog.Show();
        }

        public async void AddEmployeeDialog_OnDialogClose()
        {
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
            StateHasChanged();
        }
    }
}
