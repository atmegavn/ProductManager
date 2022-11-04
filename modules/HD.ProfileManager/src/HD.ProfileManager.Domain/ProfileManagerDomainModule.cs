using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace HD.ProfileManager;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ProfileManagerDomainSharedModule)
)]
public class ProfileManagerDomainModule : AbpModule
{

}
