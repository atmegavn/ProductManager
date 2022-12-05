using HD.ProfileManager.Employees;
using HD.ProfileManager.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;

namespace HD.ProfileManager.Web.Pages.Organizations
{
    public class CreateModel : ProfileManagerPageModel
    {
        public CreateOrganizationDto Form { get; set; }
        public string BackUrl { get; set; }
        private readonly IOrganizationAppService _organizationAppService;
        public CreateModel(IOrganizationAppService organizationAppService)
        {
            _organizationAppService = organizationAppService;
        }
        public async Task OnGetAsync(string backUrl, OrganizationLevel level, Guid? parentId)
        {
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
            Form = new CreateOrganizationDto();
            Form.Level = level;
            Form.ParentId = parentId;   
        }

        public async Task<ActionResult> OnPostAsync(CreateOrganizationDto form)
        {
            if (!ModelState.IsValid)
            {
                Form = form;
                ViewData["Exception"] = "Form Invalid";
                return Page();
            }

            var result = _organizationAppService.CreateAsync(form);
            if (result.IsCompletedSuccessfully)
            {
                if (form.ParentId.HasValue)
                {
                    return RedirectToPage("Detail", new {id=form.ParentId });
                }
                
                return RedirectToPage("Detail", new { id = result.Id});
            }
            else
            {
                Form = form;
                ViewData["Exception"] = result.Exception.ToString();
                return Page();
            }
        }
    }
}
