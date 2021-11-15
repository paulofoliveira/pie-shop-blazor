using PieShop.Shared;
using System.Collections.Generic;

namespace PieShop.Api.Infrastructure.Data
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int employeeId);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        IEnumerable<Employee> GetLongEmployeeList();
        IEnumerable<Employee> GetTakeLongEmployeeList(int request, int count);
    }
}
