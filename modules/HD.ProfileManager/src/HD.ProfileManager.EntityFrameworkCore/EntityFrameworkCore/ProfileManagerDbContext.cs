using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace HD.ProfileManager.EntityFrameworkCore;

[ConnectionStringName(ProfileManagerDbProperties.ConnectionStringName)]
public class ProfileManagerDbContext : AbpDbContext<ProfileManagerDbContext>, IProfileManagerDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public ProfileManagerDbContext(DbContextOptions<ProfileManagerDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureProfileManager();
    }
}
