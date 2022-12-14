using HD.ProfileManager.Organizations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HD.ProfileManager.JobTitles
{
    public interface IJobTitleAppService: IApplicationService
    {
        Task<JobTitleDto> GetAsync(Guid id);
        Task<PagedResultDto<JobTitleDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<JobTitleDto> CreateAsync(CreateJobTitleDto input);
        Task<JobTitleDto> UpdateAsync(Guid id, UpdateJobTitleDto input);

        Task<ListResultDto<JobTitleLookupDto>> GetlookupAsync();
    }
}
