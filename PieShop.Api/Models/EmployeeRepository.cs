﻿using System;
using System.Collections.Generic;
using System.Linq;
using PieShop.Shared;

namespace PieShop.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PieShopContext _appDbContext;

        public EmployeeRepository(PieShopContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _appDbContext.Employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _appDbContext.Employees.FirstOrDefault(c => c.EmployeeId == employeeId);
        }

        public Employee AddEmployee(Employee employee)
        {
            var addedEntity = _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

            if (foundEmployee != null)
            {
                foundEmployee.CountryId = employee.CountryId;
                foundEmployee.MaritalStatus = employee.MaritalStatus;
                foundEmployee.BirthDate = employee.BirthDate;
                foundEmployee.City = employee.City;
                foundEmployee.Email = employee.Email;
                foundEmployee.FirstName = employee.FirstName;
                foundEmployee.LastName = employee.LastName;
                foundEmployee.Gender = employee.Gender;
                foundEmployee.PhoneNumber = employee.PhoneNumber;
                foundEmployee.Smoker = employee.Smoker;
                foundEmployee.Street = employee.Street;
                foundEmployee.Zip = employee.Zip;
                foundEmployee.JobCategoryId = employee.JobCategoryId;
                foundEmployee.Comment = employee.Comment;
                foundEmployee.ExitDate = employee.ExitDate;
                foundEmployee.JoinedDate = employee.JoinedDate;

                _appDbContext.SaveChanges();

                return foundEmployee;
            }

            return null;
        }

        public void DeleteEmployee(int employeeId)
        {
            var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (foundEmployee == null) return;

            _appDbContext.Employees.Remove(foundEmployee);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetLongEmployeeList()
        {
            var Employees = new List<Employee>();
            for (int i = 0; i < 1000; i++)
            {
                var employee = new Employee()
                {
                    EmployeeId = i,
                    FirstName = RandomString(10),
                    LastName = RandomString(18)
                };
                Employees.Add(employee);
            }
            return Employees;
        }
        public IEnumerable<Employee> GetTakeLongEmployeeList(int request, int count)
        {
            var Employees = new List<Employee>();
            for (int i = 0; i < count; i++)
            {
                var employee = new Employee()
                {
                    EmployeeId = i,
                    FirstName = RandomString(10),
                    LastName = RandomString(18)
                };
                Employees.Add(employee);
            }
            return Employees;
        }

        private readonly Random random = new();
        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}