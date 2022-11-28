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
        Task<EmployeeDto> GetAsync(Guid id);
        Task<PagedResultDto<EmployeeDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task CreateAsync(CreateEmployeeDto input);

        Task UpdateAsync(Guid id, UpdateEmployeeDto input);

        Task DeleteAsync(Guid id);

    }
}
