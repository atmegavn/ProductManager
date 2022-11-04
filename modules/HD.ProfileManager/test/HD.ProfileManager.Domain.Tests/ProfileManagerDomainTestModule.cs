using HD.ProfileManager.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace HD.ProfileManager;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(ProfileManagerEntityFrameworkCoreTestModule)
    )]
public class ProfileManagerDomainTestModule : AbpModule
{

}
