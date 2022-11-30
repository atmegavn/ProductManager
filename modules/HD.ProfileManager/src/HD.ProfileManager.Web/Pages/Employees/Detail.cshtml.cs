using HD.ProfileManager.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace HD.ProfileManager.Web.Pages.Employees
{
    public class DetailModel : PageModel
    {
        public string BackUrl { get; set; }
        public void OnGet(string backUrl)
        {
            BackUrl = string.IsNullOrEmpty(backUrl) ? "Index" : backUrl;
        }
    }
}
