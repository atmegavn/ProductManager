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
        public CreateEmployeeDto Form { get; set; }
        public string BackUrl { get; set; }
        private readonly IEmployeeAppService _employeeAppService;
        public CreateModel(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        public async Task OnGetAsync(string backUrl)
        {
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
            Form = new CreateEmployeeDto();
            Form.BackUrl = backUrl;
            Form.DateOfOnboard = DateTime.Today;
        }

        public async Task<ActionResult> OnPostAsync(CreateEmployeeDto form)
        {
            if (!ModelState.IsValid)
            {
                Form = form;
                BackUrl = form.BackUrl;
                ViewData["Exception"] = "Form Invalid";
                return Page();
            }

            var result = _employeeAppService.CreateAsync(form);
            if (result.IsCompletedSuccessfully)
            {
                return Redirect("Index");
            }
            else
            {
                Form = form;
                BackUrl = form.BackUrl;
                ViewData["Exception"] = result.Exception.ToString();
                return Page();
            }
        }

    }
}
