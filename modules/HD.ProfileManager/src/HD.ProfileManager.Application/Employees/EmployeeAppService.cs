﻿using HD.ProfileManager.Samples;
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
        public EmployeeAppService(IRepository<Employee, Guid> employeeRepository) { 
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto input)
        {
            //var employee = ObjectMapper.Map<CreateEmployeeDto, Employee>(input);
            var employee = new Employee();
            employee.Code = input.Code;
            employee.Name = input.Name;
            employee.DateOfOnboard = input.DateOfOnboard;

            await _employeeRepository.InsertAsync(employee);
         
           return ObjectMapper.Map<Employee, EmployeeDto>(employee);
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

        async Task<PagedResultDto<EmployeeDto>> IEmployeeAppService.GetListAsync(PagedAndSortedResultRequestDto input)
        {
            input.MaxResultCount = 2;
            var queryable = await _employeeRepository.GetQueryableAsync();
            queryable = queryable.Skip(input.SkipCount).Take(input.MaxResultCount).OrderBy(e => e.Name);

            var data = await AsyncExecuter.ToListAsync(queryable);
            var count = await _employeeRepository.GetCountAsync();

            var result = new PagedResultDto<EmployeeDto>(count, ObjectMapper.Map<List<Employee>, List<EmployeeDto>>(data));
            return result;
        }
    }
}
