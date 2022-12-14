using HD.ProfileManager.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace HD.ProfileManager.Web.Pages.Employees
{
    public class DetailModel : ProfileManagerPageModel
    {
        public readonly IEmployeeAppService _employeeAppService;
        public EmployeeDto Employee { get; set; }
        public string BackUrl { get; set; }

        public DetailModel(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }
        public async Task OnGetAsync(Guid id, string backUrl)
        {
            Employee = await _employeeAppService.GetAsync(id);
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
        }
    }
}
