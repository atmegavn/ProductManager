using HD.ProfileManager.Employees;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace HD.ProfileManager.EntityFrameworkCore;

[DependsOn(
    typeof(ProfileManagerDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class ProfileManagerEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ProfileManagerDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

    }
}
