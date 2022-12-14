using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.EntityFrameworkCore;

namespace HD.ProfileManager;

[DependsOn(
    typeof(ProfileManagerDomainModule),
    typeof(ProfileManagerApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(AbpAutoMapperModule)
    )]
public class ProfileManagerApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<ProfileManagerApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ProfileManagerApplicationModule>(validate: true);
        });
    }
}
