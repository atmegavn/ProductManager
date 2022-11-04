using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace HD.ProfileManager;

[DependsOn(
    typeof(ProfileManagerApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ProfileManagerHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ProfileManagerApplicationContractsModule).Assembly,
            ProfileManagerRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ProfileManagerHttpApiClientModule>();
        });

    }
}
