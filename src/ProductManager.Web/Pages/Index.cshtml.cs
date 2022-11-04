using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace ProductManager.Web.Pages;

[Authorize]
public class IndexModel : ProductManagerPageModel
{
    public void OnGet()
    {
       
    }
}
