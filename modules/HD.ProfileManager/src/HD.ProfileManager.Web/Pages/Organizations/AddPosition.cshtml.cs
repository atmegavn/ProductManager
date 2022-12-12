using HD.ProfileManager.Employees;
using HD.ProfileManager.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace HD.ProfileManager.Web.Pages.Organizations
{
    public class AddPositionModel : PageModel
    {
        public AddPositionDto Form { get; set; }
        public List<SelectListItem> Positions { get; set; }
        private readonly IOrganizationAppService _organizationAppService;

        public AddPositionModel(IOrganizationAppService organizationAppService)
        {
            _organizationAppService = organizationAppService;
        }

        public async Task OnGetAsync(Guid id, string backUrl)
        {
            var positionLookUp = await _organizationAppService.GetJobPositionsAsync();
            Positions = positionLookUp.Items.Select(p => new SelectListItem(p.Name, p.Id.ToString())).ToList();

            var org = await _organizationAppService.GetAsync(id);
            var form = new AddPositionDto();
            form.OrganizationId = org.Id;
            form.BackUrl = WebUtility.UrlDecode(backUrl);
            Form = form;
        }

        public async Task<ActionResult> OnPostAsync(AddPositionDto form)
        {
            if (!ModelState.IsValid)
            {
                Form = form;
                ViewData["Exception"] = "Form Invalid";
                return Page();
            }

            await _organizationAppService.AddPositionAsync(form);
            return Redirect(form.BackUrl);
        }
    }
}
