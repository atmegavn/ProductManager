using HD.ProfileManager.Employees;
using HD.ProfileManager.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace HD.ProfileManager.Web.Pages.Organizations
{
    public class IndexModel : ProfileManagerPageModel
    {
        private readonly IOrganizationAppService _organizationAppService;
        public PagedResultDto<OrganizationDto> Result { get; set; }
        public PagedAndSortedResultRequestDto Params = new PagedAndSortedResultRequestDto();

        public IndexModel(IOrganizationAppService organizationAppService)
        {
            _organizationAppService = organizationAppService;
        }
        public async Task OnGetAsync(PagedAndSortedResultRequestDto input)
        {
            Params = input;
            Result = await _organizationAppService.GetListAsync(input);
        }
    }
}
