using HD.ProfileManager.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
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

        public async Task OnGetAsync(string backUrl)
        {
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
            Employee = new CreateEmployeeDto();
            Employee.DateOfOnboard = DateTime.Today;
        }

        public async Task<ActionResult> OnPostAsync(CreateEmployeeDto employee)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result =  _employeeAppService.CreateAsync(employee);
            if (result.IsCompleted)
            {
                return Redirect("Index");
            }
            else
            {
                return Page();
            }
        }

    }
}
