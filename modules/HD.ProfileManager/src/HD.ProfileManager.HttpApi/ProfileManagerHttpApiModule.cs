using Localization.Resources.AbpUi;
using HD.ProfileManager.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace HD.ProfileManager;

[DependsOn(
    typeof(ProfileManagerApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ProfileManagerHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ProfileManagerHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ProfileManagerResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
