using Microsoft.AspNetCore.Components;
using PieShop.Application.Services;
using PieShop.ComponentsLibrary.Map;
using PieShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PieShop.Application.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public List<Marker> MapMarkers { get; set; } = new List<Marker>();

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));

            MapMarkers = new List<Marker>
            {
                new Marker {
                    Description = $"{Employee.FirstName} {Employee.LastName}",
                    ShowPopup = false,
                    X = Employee.Longitude,
                    Y = Employee.Latitude
                }
            };
        }
    }
}
