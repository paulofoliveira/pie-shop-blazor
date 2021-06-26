using PieShop.App.Services;
using PieShop.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.App.Pages
{
    public partial class EmployeeOverview
    {
        private readonly IEmployeeDataService _employeeDataService;
        private readonly IJobCategoryDataService _jobCategoryDataService;
        private readonly ICountryDataService _countryDataService;

        public EmployeeOverview(IEmployeeDataService employeeDataService, IJobCategoryDataService jobCategoryDataService, ICountryDataService countryDataService)
        {
            _employeeDataService = employeeDataService;
            _jobCategoryDataService = jobCategoryDataService;
            _countryDataService = countryDataService;
        }

        public IEnumerable<Employee> Employees { get; set; }

        private List<Country> Countries { get; set; }

        private List<JobCategory> JobCategories { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = (await _employeeDataService.GetAllEmployees()).ToList();
            Countries = (await _countryDataService.GetAllCountries()).ToList();
            JobCategories = (await _jobCategoryDataService.GetAllJobCategories()).ToList();
        }
    }
}
