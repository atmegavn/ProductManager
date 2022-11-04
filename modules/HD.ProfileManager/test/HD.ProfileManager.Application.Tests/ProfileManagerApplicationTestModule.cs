using Volo.Abp.Modularity;

namespace HD.ProfileManager;

[DependsOn(
    typeof(ProfileManagerApplicationModule),
    typeof(ProfileManagerDomainTestModule)
    )]
public class ProfileManagerApplicationTestModule : AbpModule
{

}
