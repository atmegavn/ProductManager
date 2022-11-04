using HD.ProfileManager.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace HD.ProfileManager.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ProfileManagerPageModel : AbpPageModel
{
    protected ProfileManagerPageModel()
    {
        LocalizationResourceType = typeof(ProfileManagerResource);
        ObjectMapperContext = typeof(ProfileManagerWebModule);
    }
}
