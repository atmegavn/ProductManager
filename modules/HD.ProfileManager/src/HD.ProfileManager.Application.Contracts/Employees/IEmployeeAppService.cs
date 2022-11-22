using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HD.ProfileManager.Employees
{
    public interface IEmployeeAppService: IApplicationService
    {
        Task<EmployeeDto> UpdateAsync(EmployeeDto employeeDto); 
        Task DeleteAsync(Guid id);    
        Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto);
        Task<PagedResultDto<EmployeeDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}
