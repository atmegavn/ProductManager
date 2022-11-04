using ProductManager.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ProductManager.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ProductManagerController : AbpControllerBase
{
    protected ProductManagerController()
    {
        LocalizationResource = typeof(ProductManagerResource);
    }
}
