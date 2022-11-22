using HD.ProfileManager.Employees;
using HD.ProfileManager.Localization;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HD.ProfileManager;

public abstract class ProfileManagerAppService : ApplicationService
{

    protected ProfileManagerAppService()
    {
        LocalizationResource = typeof(ProfileManagerResource);
        ObjectMapperContext = typeof(ProfileManagerApplicationModule);
    }
}
