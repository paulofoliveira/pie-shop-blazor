using Microsoft.AspNetCore.Components;
using PieShop.App.Services;
using PieShop.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.App.Pages
{
    public partial class EmployeeDetail
    {
        private readonly IEmployeeDataService _employeeDataService;
        private readonly IJobCategoryDataService _jobCategoryDataService;
        private readonly ICountryDataService _countryDataService;

        public EmployeeDetail(IEmployeeDataService employeeDataService, IJobCategoryDataService jobCategoryDataService, ICountryDataService countryDataService)
        {
            _employeeDataService = employeeDataService;
            _jobCategoryDataService = jobCategoryDataService;
            _countryDataService = countryDataService;
        }

        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();

        protected override async Task OnInitializedAsync()
        {
            Employees = (await _employeeDataService.GetAllEmployees()).ToList();
            Countries = (await _countryDataService.GetAllCountries()).ToList();
            JobCategories = (await _jobCategoryDataService.GetAllJobCategories()).ToList();

            Employee = Employees.FirstOrDefault(x => x.EmployeeId == int.Parse(EmployeeId));
        }

        public IEnumerable<Employee> Employees { get; set; }

        private List<Country> Countries { get; set; }

        private List<JobCategory> JobCategories { get; set; }
    }
}
