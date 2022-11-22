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
    public class EmployeeAppService: ProfileManagerAppService, IEmployeeAppService
    {
        private readonly IRepository<Employee, Guid> _employeeRepository;
        public EmployeeAppService(IRepository<Employee, Guid> employeeRepository) {
            _employeeRepository = employeeRepository;
        }

        public Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<EmployeeDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
            //var queryable = await _employeeRepository.GetQueryableAsync();

            //queryable = queryable.Skip(input.SkipCount).Take(input.MaxResultCount).OrderBy(x => x.Name);
            //var employees = await AsyncExecuter.ToListAsync(queryable);
            //var count = await _employeeRepository.GetCountAsync();

            //return new PagedResultDto<EmployeeDto>(count, ObjectMapper.Map<List<Employee>, List<EmployeeDto>>(employees));
        }

        public Task<EmployeeDto> UpdateAsync(EmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }
      
    }
}
