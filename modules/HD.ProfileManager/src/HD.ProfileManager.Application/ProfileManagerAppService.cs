using HD.ProfileManager.Localization;
using Volo.Abp.Application.Services;

namespace HD.ProfileManager;

public abstract class ProfileManagerAppService : ApplicationService
{
    protected ProfileManagerAppService()
    {
        LocalizationResource = typeof(ProfileManagerResource);
        ObjectMapperContext = typeof(ProfileManagerApplicationModule);
    }
}
