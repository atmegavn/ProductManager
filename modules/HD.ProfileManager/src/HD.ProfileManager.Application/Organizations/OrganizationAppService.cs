using HD.ProfileManager.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HD.ProfileManager.Organizations
{
    public class OrganizationAppService : ProfileManagerAppService, IOrganizationAppService
    {
        //private readonly IOrganizationRepository _organizationRepository;
        private readonly IRepository<Organization,Guid> _organizationRepository;

        public OrganizationAppService(IRepository<Organization,Guid> organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<OrganizationDto> CreateAsync(CreateOrganizationDto input)
        {
            //var org = ObjectMapper.Map<OrganizationDto, Employee>(input);
            var org = new Organization();
            org.Code = input.Code;
            org.Name = input.Name;
            org.Level = input.Level;
            org.ParentId = input.ParentId;
            
            await _organizationRepository.InsertAsync(org);

            return ObjectMapper.Map<Organization, OrganizationDto>(org);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<OrganizationDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<OrganizationDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _organizationRepository.WithDetailsAsync(o => o.Positions);
            queryable = queryable.Skip(input.SkipCount).Take(input.MaxResultCount).OrderByDescending(e => e.CreationTime);

            var data = await AsyncExecuter.ToListAsync(queryable);
            var count = await _organizationRepository.GetCountAsync();
            return new PagedResultDto<OrganizationDto>(count, ObjectMapper.Map<List<Organization>, List<OrganizationDto>>(data));
        }

        public Task UpdateAsync(Guid id, OrganizationDto input)
        {
            throw new NotImplementedException();
        }
    }
}
