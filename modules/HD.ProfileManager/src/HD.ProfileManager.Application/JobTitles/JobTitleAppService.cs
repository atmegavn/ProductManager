using HD.ProfileManager.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace HD.ProfileManager.JobTitles
{
    public class JobTitleAppService : ProfileManagerAppService, IJobTitleAppService
    {
        private readonly IRepository<JobTitle, Guid> _jobTitleRepository;

        public JobTitleAppService(IRepository<JobTitle, Guid> jobTitleRepository) { 
            _jobTitleRepository = jobTitleRepository;   
        }
        public async Task<JobTitleDto> CreateAsync(CreateJobTitleDto input)
        {
            var title = new JobTitle();
            title.Name = input.Name;
            title.Description = input.Description;
            await _jobTitleRepository.InsertAsync(title);

            return ObjectMapper.Map<JobTitle, JobTitleDto>(title);
        }

        public Task<JobTitleDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<JobTitleDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _jobTitleRepository.GetQueryableAsync();
                queryable = queryable.Skip(input.SkipCount).Take(input.MaxResultCount).OrderBy(e => e.Name);
            var data = await AsyncExecuter.ToListAsync(queryable);

            var count = await _jobTitleRepository.CountAsync();
            return new PagedResultDto<JobTitleDto>(count, ObjectMapper.Map<List<JobTitle>, List<JobTitleDto>>(data));
        }

        public async Task<ListResultDto<JobTitleLookupDto>> GetlookupAsync()
        {
            var titles = await _jobTitleRepository.GetListAsync();
            return new ListResultDto<JobTitleLookupDto>(ObjectMapper.Map<List<JobTitle>, List<JobTitleLookupDto>>(titles));
        }

        public Task<JobTitleDto> UpdateAsync(Guid id, UpdateJobTitleDto input)
        {
            throw new NotImplementedException();
        }
    }
}
