using HD.ProfileManager.Employees;
using HD.ProfileManager.Samples;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Domain.Repositories;

namespace HD.ProfileManager.Web.Pages.Employees
{
    public class IndexModel : ProfileManagerPageModel
    {
        private readonly IEmployeeAppService _employeeAppService;
        public PagedResultDto<EmployeeDto> Data { get; set; }

        public IndexModel(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        public async void OnGetAsync(PagedAndSortedResultRequestDto input)
        {
            Data = await _employeeAppService.GetListAsync(input);
        }
    }
}
