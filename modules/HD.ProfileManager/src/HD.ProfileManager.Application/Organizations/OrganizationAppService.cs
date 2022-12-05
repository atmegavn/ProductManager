using HD.ProfileManager.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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
            //var org = ObjectMapper.Map<CreateOrganizationDto, Organization>(input);
            var org = new Organization();
            org.Code = input.Code;
            org.Name = input.Name;
            org.Phone = input.Phone;
            org.Email = input.Email;
            org.Level = input.Level;
            org.ParentId = input.ParentId;
            org.Description = input.Description;
            await _organizationRepository.InsertAsync(org);

            return ObjectMapper.Map<Organization, OrganizationDto>(org);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<OrganizationDto> GetAsync(Guid id)
        {
            var queryable = await _organizationRepository.WithDetailsAsync(o => o.Positions);
            queryable = queryable.Where(o => o.Id == id);
            var data = await AsyncExecuter.FirstOrDefaultAsync(queryable);
            var result = ObjectMapper.Map<Organization, OrganizationDto>(data);
            return result;
        }

        public async Task<List<OrganizationDto>> GetListSubOrganizationAsync(Guid id)
        {
            var queryable = await _organizationRepository.WithDetailsAsync(o => o.Positions);
            queryable = queryable.Where(o => o.ParentId == id).OrderByDescending(o => o.Name);
            var data = await AsyncExecuter.ToListAsync(queryable);

            var result = ObjectMapper.Map<List<Organization>, List<OrganizationDto>>(data);
            return result;
        }

        public async Task<PagedResultDto<OrganizationDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _organizationRepository.WithDetailsAsync(o => o.Positions);
            queryable = queryable.Where(o => !o.ParentId.HasValue).Skip(input.SkipCount).Take(input.MaxResultCount).OrderByDescending(e => e.Name);

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
