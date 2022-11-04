using System;
using System.Collections.Generic;
using System.Text;
using ProductManager.Localization;
using Volo.Abp.Application.Services;

namespace ProductManager;

/* Inherit your application services from this class.
 */
public abstract class ProductManagerAppService : ApplicationService
{
    protected ProductManagerAppService()
    {
        LocalizationResource = typeof(ProductManagerResource);
    }
}
