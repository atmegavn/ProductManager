using HD.ProfileManager.Employees;
using HD.ProfileManager.JobTitles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace HD.ProfileManager.Web.Pages.Employees
{
    public class CreateModel : ProfileManagerPageModel
    {
        public List<SelectListItem> JobTitles { get; set; }
        public CreateEmployeeDto Form { get; set; }
        public string BackUrl { get; set; }

        private readonly IEmployeeAppService _employeeAppService;
        private readonly IJobTitleAppService _jobTitleAppService;
        public CreateModel(IEmployeeAppService employeeAppService, IJobTitleAppService jobTitleAppService)
        {
            _employeeAppService = employeeAppService;
            _jobTitleAppService = jobTitleAppService;
        }

        public async Task OnGetAsync(string backUrl)
        {
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
            Form = new CreateEmployeeDto();
            Form.BackUrl = backUrl;
            Form.DateOfOnboard = DateTime.Today;
            //var orgLookUp = await _employeeAppService.GetOrganizationAsync(null);
            //Organizations = orgLookUp.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            var titleLookup = await _jobTitleAppService.GetlookupAsync();
            JobTitles = titleLookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
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

            await _employeeAppService.CreateAsync(form);
            return Redirect("Index");
        }

    }
}
