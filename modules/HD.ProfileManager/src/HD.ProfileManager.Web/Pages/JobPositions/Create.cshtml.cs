using HD.ProfileManager.JobPositions;
using HD.ProfileManager.Organizations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.ProfileManager.Web.Pages.JobPositions
{
    public class CreateModel : ProfileManagerPageModel
    {
        public CreateJobPositionDto Form { get; set; }
        public string BackUrl { get; set; }
        public List<SelectListItem> JobFamiliesLookup { get; set; }
        public readonly IJobPositionAppService _jobPositionAppService;
        public CreateModel(IJobPositionAppService jobPositionAppService)
        {
            _jobPositionAppService = jobPositionAppService;
        }
        public async Task OnGetAsync(string backUrl)
        {
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
            Form = new CreateJobPositionDto();
            var positionLookUp = await _jobPositionAppService.GetJobFamiliesLookupAsync();
            JobFamiliesLookup = positionLookUp.Items.Select(p => new SelectListItem(p.Name, p.Id.ToString())).ToList();
        }

        public async Task<ActionResult> OnPostAsync(CreateJobPositionDto form)
        {
            if (!ModelState.IsValid)
            {
                Form = form;
                ViewData["Exception"] = "Form Invalid";
                return Page();
            }

            var insert = _jobPositionAppService.CreateAsync(form);
            if (insert.IsCompletedSuccessfully)
            {
                return RedirectToPage("Detail", new { id = insert.Result.Id });
            }
            else
            {
                Form = form;
                ViewData["Exception"] = insert.Exception.ToString();
                return Page();
            }
        }
    }
}
