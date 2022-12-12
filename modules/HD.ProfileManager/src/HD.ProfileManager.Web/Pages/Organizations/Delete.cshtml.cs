using HD.ProfileManager.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;

namespace HD.ProfileManager.Web.Pages.Organizations
{
    public class DeleteModel : ProfileManagerPageModel
    {
        private readonly IJobPositionAppService _organizationAppService;
        public DeleteModel(IJobPositionAppService organizationAppService)
        {
            _organizationAppService = organizationAppService;
        }
        public async Task OnGetAsync(Guid id)
        {
           
        }
    }
}
