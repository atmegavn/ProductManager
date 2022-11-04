using HD.ProfileManager.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HD.ProfileManager;

public abstract class ProfileManagerController : AbpControllerBase
{
    protected ProfileManagerController()
    {
        LocalizationResource = typeof(ProfileManagerResource);
    }
}
