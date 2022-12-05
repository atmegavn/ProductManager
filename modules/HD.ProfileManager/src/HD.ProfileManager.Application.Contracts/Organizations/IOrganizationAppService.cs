using HD.ProfileManager.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HD.ProfileManager.Organizations
{
    public interface IOrganizationAppService: IApplicationService
    {
        Task<OrganizationDto> GetAsync(Guid id);
        Task<PagedResultDto<OrganizationDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<OrganizationDto> CreateAsync(CreateOrganizationDto input);
        Task<List<OrganizationDto>> GetListSubOrganizationAsync(Guid id);
        Task UpdateAsync(Guid id, OrganizationDto input);

        Task DeleteAsync(Guid id);
    }
}
