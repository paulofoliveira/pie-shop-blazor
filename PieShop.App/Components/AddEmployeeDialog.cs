﻿using Microsoft.AspNetCore.Components;
using PieShop.App.Services;
using PieShop.Shared;
using System;
using System.Threading.Tasks;

namespace PieShop.App.Components
{
    public partial class AddEmployeeDialog
    {
        public Employee Employee { get; set; } = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        public bool ShowDialog { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
        }

        protected async Task HandleValidSubmit()
        {
            await EmployeeDataService.AddEmployee(Employee);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}


