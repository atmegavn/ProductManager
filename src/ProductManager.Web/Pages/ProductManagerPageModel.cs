using ProductManager.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ProductManager.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ProductManagerPageModel : AbpPageModel
{
    protected ProductManagerPageModel()
    {
        LocalizationResourceType = typeof(ProductManagerResource);
    }
}
