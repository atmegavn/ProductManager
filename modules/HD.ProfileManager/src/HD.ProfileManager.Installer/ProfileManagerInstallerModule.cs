using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace HD.ProfileManager;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class ProfileManagerInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ProfileManagerInstallerModule>();
        });
    }
}
