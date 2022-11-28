using HD.ProfileManager.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Volo.Abp.Domain.Repositories;

namespace HD.ProfileManager.Web.Pages.Employees
{
    public class CreateModel : ProfileManagerPageModel
    {
        public CreateEmployeeDto Employee { get; set; }
        public string BackUrl { get; set; }
        private readonly IEmployeeAppService _employeeAppService;
        public CreateModel(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        public void OnGet(string backUrl)
        {
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
            Employee = new CreateEmployeeDto();
            Employee.DateOfOnboard = DateTime.Today;
        }

    }
}
