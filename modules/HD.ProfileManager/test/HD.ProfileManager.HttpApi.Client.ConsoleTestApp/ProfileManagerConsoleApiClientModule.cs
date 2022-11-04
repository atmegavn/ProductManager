using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace HD.ProfileManager;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProfileManagerHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ProfileManagerConsoleApiClientModule : AbpModule
{

}
