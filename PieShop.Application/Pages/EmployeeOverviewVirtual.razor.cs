using Microsoft.AspNetCore.Components;
using PieShop.Application.Services;
using PieShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.Application.Pages
{
    public partial class EmployeeOverviewVirtual
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employees = (await EmployeeDataService.GetLongEmployeeList()).ToList();
        }
    }
}
