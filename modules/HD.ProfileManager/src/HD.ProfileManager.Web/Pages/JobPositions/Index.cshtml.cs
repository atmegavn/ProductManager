using HD.ProfileManager.JobPositions;
using HD.ProfileManager.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace HD.ProfileManager.Web.Pages.JobPositions
{
    public class IndexModel : ProfileManagerPageModel
    {
        private readonly IJobPositionAppService _jobPositionAppService;
        public PagedResultDto<JobPositionDto> Result { get; set; }
        public PagedAndSortedResultRequestDto Params = new PagedAndSortedResultRequestDto();
        public IndexModel(IJobPositionAppService jobPositionAppService)
        {
            _jobPositionAppService = jobPositionAppService;
        }
        public async Task OnGetAsync(PagedAndSortedResultRequestDto input)
        {
            Params = input;
            Result = await _jobPositionAppService.GetListAsync(input);
        }
    }
}
