using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace HD.ProfileManager.EntityFrameworkCore;

[ConnectionStringName(ProfileManagerDbProperties.ConnectionStringName)]
public interface IProfileManagerDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
