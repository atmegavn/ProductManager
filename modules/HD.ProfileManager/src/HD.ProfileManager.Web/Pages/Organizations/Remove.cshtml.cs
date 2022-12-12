using HD.ProfileManager.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace HD.ProfileManager.Web.Pages.Organizations
{
    public class RemoveModel : ProfileManagerPageModel
    {
        public DeleteOrganizaionDto Form { get; set; }

        private readonly IOrganizationAppService _organizationAppService;
        public RemoveModel(IOrganizationAppService organizationAppService)
        {
            _organizationAppService = organizationAppService;
        }

        public async Task OnGetAsync(Guid id, string backUrl)
        {
            Form = new DeleteOrganizaionDto();
            var org = await _organizationAppService.GetAsync(id);
            Form.Id = org.Id;
            Form.Name = org.Name;
            Form.BackUrl = backUrl;
        }

        public async Task<ActionResult> OnPostAsync(DeleteOrganizaionDto form)
        {
            if (!ModelState.IsValid)
            {
                Form = form;
                ViewData["Exception"] = "Form Invalid";
                return Page();
            }

            var result = _organizationAppService.DeleteAsync(form.Id);
            if (result.IsCompletedSuccessfully)
            {
                return new JsonResult(new { Result = "OK", Message = "Approved OK" });
            }
            else
            {
                Form = form;
                ViewData["Exception"] = result.Exception?.Message.ToString();
                return Page();
            }
        }
    }
}
