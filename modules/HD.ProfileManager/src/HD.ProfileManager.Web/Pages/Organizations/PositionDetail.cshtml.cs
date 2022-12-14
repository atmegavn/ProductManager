using HD.ProfileManager.JobPositions;
using HD.ProfileManager.OrganizationPositions;
using HD.ProfileManager.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HD.ProfileManager.Web.Pages.Organizations
{
    public class PositionDetailModel : ProfileManagerPageModel
    {
        public JobPositionDto Form { get; set; }
        public List<OrganizationPositionDto> Positions { get; set; }
        public string BackUrl { get; set; }
        private readonly IOrganizationAppService _organizationAppService;
        private readonly IJobPositionAppService _jobPositionAppService;

        public PositionDetailModel(IOrganizationAppService organizationAppService, IJobPositionAppService jobPositionAppService)
        {
            _organizationAppService = organizationAppService;
            _jobPositionAppService = jobPositionAppService;
        }
        public async Task OnGetAsync(Guid id, Guid orgId, string backUrl)
        {
            Form = await _jobPositionAppService.GetAsync(id);
            Positions = await _organizationAppService.GetPositionsOfOrganization(orgId, id);
            BackUrl = backUrl;
        }
    }
}
