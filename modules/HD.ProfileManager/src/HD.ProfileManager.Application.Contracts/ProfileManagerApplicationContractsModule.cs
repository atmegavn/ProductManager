using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace HD.ProfileManager;

[DependsOn(
    typeof(ProfileManagerDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ProfileManagerApplicationContractsModule : AbpModule
{

}
