using HD.ProfileManager.Organizations;
using HD.ProfileManager.Samples;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HD.ProfileManager.Employees
{
    public class EmployeeAppService : ProfileManagerAppService, IEmployeeAppService
    {
        private readonly IRepository<Employee, Guid> _employeeRepository;
        private readonly IRepository<Organization, Guid> _organizationRepository;

        public EmployeeAppService(IRepository<Employee, Guid> employeeRepository, IRepository<Organization, Guid> organizationRepository) { 
            _employeeRepository = employeeRepository;
            _organizationRepository = organizationRepository;   
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto input)
        {
            //var employee = ObjectMapper.Map<CreateEmployeeDto, Employee>(input);
            var employee = new Employee();
            employee.Code = input.Code;
            employee.Name = input.Name;
            employee.DateOfOnboard = input.DateOfOnboard;
            employee.OrganzinationId = input.OrganizationId;

            await _employeeRepository.InsertAsync(employee);
         
           return ObjectMapper.Map<Employee, EmployeeDto>(employee);
        }

        async Task<PagedResultDto<EmployeeDto>> IEmployeeAppService.GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _employeeRepository.GetQueryableAsync();
            queryable = queryable.OrderByDescending(e => e.CreationTime).Skip(input.SkipCount).Take(input.MaxResultCount);

            var data = await AsyncExecuter.ToListAsync(queryable);
            var count = await _employeeRepository.GetCountAsync();

            var result = new PagedResultDto<EmployeeDto>(count, ObjectMapper.Map<List<Employee>, List<EmployeeDto>>(data));
            return result;
        }

        public async Task<ListResultDto<OrganizationLookupDto>> GetOrganizationAsync(Guid? rootOrgId)
        {
            var orgs = await _organizationRepository.GetListAsync();
            return new ListResultDto<OrganizationLookupDto>(ObjectMapper.Map<List<Organization>, List<OrganizationLookupDto>>(orgs));
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, UpdateEmployeeDto input)
        {
            throw new NotImplementedException();
        }

      
    }
}
