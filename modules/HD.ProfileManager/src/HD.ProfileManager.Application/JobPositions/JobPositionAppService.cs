using HD.ProfileManager.Employees;
using HD.ProfileManager.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace HD.ProfileManager.JobPositions
{
    public class JobPositionAppService: ProfileManagerAppService, IJobPositionAppService
    {
        private readonly IRepository<JobPosition, Guid> _jobPositionRepository;
        private readonly IRepository<JobFamily, Guid> _jobFamilyRepository;

        public JobPositionAppService(IRepository<JobPosition, Guid> jobPositionRepository, IRepository<JobFamily, Guid> jobFamilyRepository) {
            _jobPositionRepository = jobPositionRepository;
            _jobFamilyRepository = jobFamilyRepository;
        }

        public async Task<JobPositionDto> CreateAsync(CreateJobPositionDto form)
        {
            var job = new JobPosition();
            job.Name = form.Name;
            job.Description = form.Description;
            job.JobFamilyId = form.JobFamilyId;
            job.Level = form.JobLevel;
            job.Requirement = form.Requirement;
            await _jobPositionRepository.InsertAsync(job);

            return ObjectMapper.Map<JobPosition, JobPositionDto>(job);
        }

        public async Task<JobPositionDto> GetAsync(Guid id)
        {
            var data = await _jobPositionRepository.GetAsync(id);
            return ObjectMapper.Map<JobPosition, JobPositionDto>(data);
        }

        public async Task<PagedResultDto<JobPositionDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _jobPositionRepository.WithDetailsAsync(j => j.JobFamily);
            queryable = queryable.Skip(input.SkipCount).Take(input.MaxResultCount);

            var data = await AsyncExecuter.ToListAsync(queryable);
            var count = await _jobPositionRepository.GetCountAsync();

            var result = new PagedResultDto<JobPositionDto>(count, ObjectMapper.Map<List<JobPosition>, List<JobPositionDto>>(data));
            return result;
        }

        public async Task<ListResultDto<JobFamiliesLookupDto>> GetJobFamiliesLookupAsync()
        {
            var jobFamilies = await _jobFamilyRepository.GetListAsync();
            return new ListResultDto<JobFamiliesLookupDto>(ObjectMapper.Map<List<JobFamily>, List<JobFamiliesLookupDto>>(jobFamilies));
        }

        public async Task<PagedResultDto<JobFamilyDto>> GetListJobFamiliesAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _jobFamilyRepository.GetQueryableAsync();
            queryable = queryable.Skip(input.SkipCount).Take(input.MaxResultCount);

            var data = await AsyncExecuter.ToListAsync(queryable);
            var count = await _jobPositionRepository.GetCountAsync();

            var result = new PagedResultDto<JobFamilyDto>(count, ObjectMapper.Map<List<JobFamily>, List<JobFamilyDto>>(data));
            return result;
        }
    }
}
