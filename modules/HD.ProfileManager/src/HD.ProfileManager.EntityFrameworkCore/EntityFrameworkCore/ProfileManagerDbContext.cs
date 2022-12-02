using HD.ProfileManager.Employees;
using HD.ProfileManager.Locations;
using HD.ProfileManager.Locations.Districts;
using HD.ProfileManager.Locations.Nationals;
using HD.ProfileManager.Locations.Provincials;
using HD.ProfileManager.Locations.Streets;
using HD.ProfileManager.Locations.Villages;
using HD.ProfileManager.Organizations;
using HD.ProfileManager.Profiles;
using HD.ProfileManager.Profiles.BankAccounts;
using HD.ProfileManager.Profiles.Emails;
using HD.ProfileManager.Profiles.IDCards;
using HD.ProfileManager.Profiles.PhoneNumbers;
using HD.ProfileManager.Profiles.Relatives;
using HD.ProfileManager.Profiles.SocialContacts;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

namespace HD.ProfileManager.EntityFrameworkCore;

[ConnectionStringName(ProfileManagerDbProperties.ConnectionStringName)]
public class ProfileManagerDbContext : AbpDbContext<ProfileManagerDbContext>, IProfileManagerDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Organization> Organization { get; set; }
    public DbSet<BankAccount> BankAccount { get; set; }
    public DbSet<Email> Email { get; set; }
    public DbSet<IDCard> IDCard { get; set; }
    public DbSet<PhoneNumber> PhoneNumber { get; set; }
    public DbSet<Address> ProfileLocation { get; set; }
    public DbSet<Relative> Relative { get; set; }
    public DbSet<SocialContact> SocialLink { get; set; }
    public DbSet<Location> Location { get; set; }
    public DbSet<Street> Street { get; set; }
    public DbSet<Village> Village { get; set; }
    public DbSet<District> District { get; set; }
    public DbSet<Provincial> Provincial { get; set; }
    public DbSet<National> National { get; set; }

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
