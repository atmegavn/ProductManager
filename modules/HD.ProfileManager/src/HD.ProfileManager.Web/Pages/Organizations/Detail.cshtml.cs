using HD.ProfileManager.OrganizationPositions;
using HD.ProfileManager.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HD.ProfileManager.Web.Pages.Organizations
{
    public class DetailModel : ProfileManagerPageModel
    {
        public OrganizationDto Form { get; set; }
        public List<OrganizationDto> Organizations { get; set; }
        public List<OrganizationPositionDto> Positions { get; set; }
        public string BackUrl { get; set; }
        private readonly IOrganizationAppService _organizationAppService;
        public DetailModel(IOrganizationAppService organizationAppService)
        {
            _organizationAppService = organizationAppService;
        }

        public async Task OnGetAsync(Guid id, string backUrl, OrganizationLevel level)
        {
            Form = await _organizationAppService.GetAsync(id);
            Organizations = await _organizationAppService.GetListSubOrganizationAsync(id);
            Positions = await _organizationAppService.GetPositionsOfOrganization(id);
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
        }
    }
}
