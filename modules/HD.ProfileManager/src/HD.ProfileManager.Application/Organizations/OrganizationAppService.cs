using HD.ProfileManager.JobPositions;
using HD.ProfileManager.OrganizationPositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HD.ProfileManager.Organizations
{
    public class OrganizationAppService : ProfileManagerAppService, IOrganizationAppService
    {
        //private readonly IOrganizationRepository _organizationRepository;
        private readonly IRepository<Organization,Guid> _organizationRepository;
        private readonly IRepository<JobPosition,Guid> _jobPositionRepository;
        private readonly IRepository<OrganizationPosition,Guid> _organizationPositionRepository;

        public OrganizationAppService(
            IRepository<Organization,Guid> organizationRepository, 
            IRepository<JobPosition, Guid> jobPositionRepository, 
            IRepository<OrganizationPosition, Guid> organizationPositionRepository)
        {
            _organizationRepository = organizationRepository;
            _jobPositionRepository = jobPositionRepository;
            _organizationPositionRepository = organizationPositionRepository;   
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
            org.Location = input.Location;
            org.CreatedDate = input.CreatedDate;
            await _organizationRepository.InsertAsync(org);

            return ObjectMapper.Map<Organization, OrganizationDto>(org);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _organizationRepository.DeleteAsync(id);
        }

        public async Task<OrganizationDto> GetAsync(Guid id)
        {
            var queryable = await _organizationRepository.WithDetailsAsync(o => o.Positions.Where(p => p.Position.JobFamily.Name == "Management"));
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
            var paged = queryable.Where(o => !o.ParentId.HasValue).Skip(input.SkipCount).Take(input.MaxResultCount).OrderByDescending(e => e.Name);
            var data = await AsyncExecuter.ToListAsync(paged);

            var count = await _organizationRepository.CountAsync(p => p.ParentId == null) ;
            return new PagedResultDto<OrganizationDto>(count, ObjectMapper.Map<List<Organization>, List<OrganizationDto>>(data));
        }

        public async Task<OrganizationDto> UpdateAsync(Guid id, OrganizationDto input)
        {
            var org = await _organizationRepository.GetAsync(id);
            org.Code = input.Code;
            org.Name = input.Name;
            org.Phone = input.Phone;
            org.Email = input.Email;
            org.Description = input.Description;
            org.Location = input.Location;
            org.CreatedDate = input.CreatedDate;

            var updatedOrg = await _organizationRepository.UpdateAsync(org);

            return ObjectMapper.Map<Organization, OrganizationDto>(updatedOrg);
        }

        public async Task<ListResultDto<PositionLookupDto>> GetJobPositionsAsync()
        {
            var positions = await _jobPositionRepository.GetListAsync();
            return new ListResultDto<PositionLookupDto>(ObjectMapper.Map<List<JobPosition>, List<PositionLookupDto>>(positions));
        }

        public async Task AddPositionAsync(AddPositionDto input)
        {
            var positions = new List<OrganizationPosition>();
            if(input.Amount > 0)
            {
                var amount = input.Amount;
                while(amount > 0)
                {
                    var newPosition = new OrganizationPosition()
                    {
                        Name = input.Name,
                        JobPositionId = input.JobPositionId,
                        OrganizationId = input.OrganizationId
                    };
                    positions.Add(newPosition);
                    amount--;
                }
            }
            
            await _organizationPositionRepository.InsertManyAsync(positions);
        }

        public async Task<List<OrganizationPositionDto>> GetPositionsOfOrganization(Guid id, Guid? jobPositionId)
        {
            var queryable = await _organizationPositionRepository.WithDetailsAsync(op => op.Position);
            if (jobPositionId.HasValue)
            {
                queryable = queryable.Where(op => op.JobPositionId == jobPositionId);
            }
            queryable = queryable.Where(op => op.Position.JobFamily.Name != "Management").Where(op => op.OrganizationId == id).OrderBy(op => op.Name);
            var data = await AsyncExecuter.ToListAsync(queryable);

            var result = ObjectMapper.Map<List<OrganizationPosition>, List<OrganizationPositionDto>>(data);
            return result;
        }
    }
}
