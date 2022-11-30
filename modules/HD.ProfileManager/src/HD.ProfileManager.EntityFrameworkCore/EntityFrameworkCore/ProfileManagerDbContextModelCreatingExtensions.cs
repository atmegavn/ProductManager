using HD.ProfileManager.Decisions;
using HD.ProfileManager.Employees;
using HD.ProfileManager.JobPositions;
using HD.ProfileManager.JobTitles;
using HD.ProfileManager.Locations;
using HD.ProfileManager.Locations.Districts;
using HD.ProfileManager.Locations.Nationals;
using HD.ProfileManager.Locations.Provincials;
using HD.ProfileManager.Locations.Streets;
using HD.ProfileManager.Locations.Villages;
using HD.ProfileManager.OrganizationPositions;
using HD.ProfileManager.Organizations;
using HD.ProfileManager.Profiles;
using HD.ProfileManager.Profiles.BankAccounts;
using HD.ProfileManager.Profiles.Emails;
using HD.ProfileManager.Profiles.IDCards;
using HD.ProfileManager.Profiles.PhoneNumbers;
using HD.ProfileManager.Profiles.Relationships;
using HD.ProfileManager.Profiles.Relatives;
using HD.ProfileManager.Profiles.SocialContacts;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace HD.ProfileManager.EntityFrameworkCore;

public static class ProfileManagerDbContextModelCreatingExtensions
{
    public static void ConfigureProfileManager(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:
        */

        builder.Entity<Profile>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "Profile", ProfileManagerDbProperties.DbSchema);

            //Properties
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.FirstName).IsRequired().HasMaxLength(ProfileConsts.NameMaxLength);
            b.Property(p => p.SurName).IsRequired().HasMaxLength(ProfileConsts.NameMaxLength);
            b.Property(p => p.GivenName).IsRequired().HasMaxLength(ProfileConsts.NameMaxLength);
            b.Property(p => p.Gender).IsRequired();
            b.Property(p => p.DateOfBird);
            b.Property(p => p.MaritalStatus);
            b.Property(p => p.TaxCode);

            //Relations
            b.HasMany(p => p.Emails).WithOne().HasForeignKey(em => em.ProfileId);
            b.HasMany(p => p.PhoneNumbers).WithOne().HasForeignKey(no => no.ProfileId);
            b.HasMany(p => p.Cards).WithOne().HasForeignKey(c => c.ProfileId);
            b.HasMany(p => p.Address).WithOne().HasForeignKey(pl => pl.ProfileId);
            b.HasOne(p => p.ProfileType).WithMany().HasForeignKey(pt => pt.ProfileTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasMany(p => p.Relatives).WithOne().HasForeignKey(r => r.ProfileId).OnDelete(DeleteBehavior.NoAction).IsRequired();

            b.ConfigureByConvention();

            //many-to-many 
            b.HasMany(p => p.Address).WithOne().HasForeignKey(x=>x.ProfileId).IsRequired();
        });

        builder.Entity<Employee>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "Employee", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Code).IsRequired().HasMaxLength(EmployeeConsts.CodeMaxLength);
            b.Property(p => p.Name).IsRequired().HasMaxLength(EmployeeConsts.NameMaxLength);
            b.Property(p => p.Avatar).IsRequired(false);
            b.Property(p => p.OrganzinationId).IsRequired();
            b.Property(p => p.ProfileId).IsRequired(false);
            b.Property(p => p.JobTitleId).IsRequired(false);

            b.HasOne(p => p.JobTitle).WithMany().HasForeignKey(pt => pt.JobTitleId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasMany(p => p.Positions).WithOne().HasForeignKey(r => r.EmployeeId).OnDelete(DeleteBehavior.NoAction).IsRequired();

            b.ConfigureByConvention();
        });
       

        builder.Entity<Organization>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "Organization", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Code).IsRequired().HasMaxLength(EmployeeConsts.CodeMaxLength);
            b.Property(p => p.Name).IsRequired().HasMaxLength(EmployeeConsts.NameMaxLength);
            b.Property(p => p.ParentId).IsRequired(false);
            b.Property(p => p.Location).IsRequired(false);
            b.Property(p => p.Disabled).IsRequired(false);

            b.HasMany(p => p.Positions).WithOne().HasForeignKey(r => r.JobPositionId).OnDelete(DeleteBehavior.NoAction).IsRequired();

            b.ConfigureByConvention();
        });

        builder.Entity<OrganizationPosition>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "OrganizationPosition", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired().HasMaxLength(EmployeeConsts.NameMaxLength);
            b.Property(p => p.DecisionId).IsRequired(false);
            b.Property(p => p.EmployeeId).IsRequired(false);
            b.Property(p => p.OrganizationId).IsRequired(true);

            b.HasOne(p => p.Position).WithMany().HasForeignKey(r => r.JobPositionId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            //b.HasOne(p => p.Organization).WithMany().HasForeignKey(r => r.OrganizationId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasOne(p => p.Employee).WithMany().HasForeignKey(r => r.EmployeeId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasOne(p => p.Decision).WithMany().HasForeignKey(r => r.DecisionId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.ConfigureByConvention();
        });

        builder.Entity<JobTitle>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "JobTitle", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.Description).IsRequired(false);
            b.Property(p => p.Disabled).IsRequired(false);

            b.ConfigureByConvention();
        });

        builder.Entity<JobPosition>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "JobPosition", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.Description).IsRequired(false);
            b.Property(p => p.Disabled).IsRequired(false);

            b.ConfigureByConvention();
        });

        builder.Entity<Decision>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "Decision", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.DecisionMakerId).IsRequired();
            b.Property(p => p.DecisionReceiverId).IsRequired(false);
            b.Property(p => p.Note).IsRequired(false);
            b.Property(p => p.ApplyDate).IsRequired(false);
            b.Property(p => p.Number).IsRequired();
            b.Property(p => p.ExperiedDate).IsRequired(false);
            b.Property(p => p.Description).IsRequired(false);

            b.HasOne(p => p.DecisionMaker).WithMany().HasForeignKey(p => p.DecisionMakerId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasOne(p => p.DecisionType).WithMany().HasForeignKey(p => p.TypeId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.HasOne(p => p.DecisionReceiver).WithMany().HasForeignKey(p => p.DecisionReceiverId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            b.ConfigureByConvention();
        });

        builder.Entity<DecisionType>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "DecisionType", ProfileManagerDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.Property(p => p.Id).HasDefaultValueSql("newid()");

            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.Description).IsRequired(false);
            b.Property(p => p.Disabled).IsRequired(false);
        });

        builder.Entity<ProfileType>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "ProfileType", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.ConfigureByConvention();
        });

        builder.Entity<BankAccount>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "BankAccount", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.ConfigureByConvention();
        });

        builder.Entity<Email>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "Email", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.ConfigureByConvention();
        });

        builder.Entity<IDCard>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "IDCard", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.ConfigureByConvention();
        });

        builder.Entity<PhoneNumber>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "PhoneNumber", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.ConfigureByConvention();
        });

        builder.Entity<Address>(b => {
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "Address", ProfileManagerDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.HasKey(x => new { x.ProfileId, x.LocationId });
            //many-to-many configuration
            b.HasOne<Profile>().WithMany(x => x.Address).HasForeignKey(x => x.ProfileId).IsRequired();
            b.HasOne(a => a.Location).WithMany().HasForeignKey(a => a.LocationId).IsRequired();
            b.HasIndex(x=>new{x.ProfileId,x.LocationId});
        });

        builder.Entity<Relative>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "Relative", ProfileManagerDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.Property(p => p.PersonId).IsRequired(false);
            b.HasOne<Profile>().WithMany().HasForeignKey(r => r.PersonId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            b.HasOne(r => r.Relationship).WithMany().HasForeignKey(r => r.RelationshipId).OnDelete(DeleteBehavior.NoAction).IsRequired();
        });

        builder.Entity<Relationship>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "Relationship", ProfileManagerDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.Property(p => p.Id).HasDefaultValueSql("newid()");

            b.Property(p => p.Name).IsRequired();
            b.Property(p => p.Description).IsRequired(false);
            b.Property(p => p.Disabled).IsRequired(false);
        });

        builder.Entity<SocialContact>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "SocialContact", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.HasOne(a => a.SocialNetwork).WithMany().HasForeignKey(a => a.SocialNetworkId).IsRequired();
            b.ConfigureByConvention();
        });

        builder.Entity<SocialNetwork>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "SocialNetwork", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.ConfigureByConvention();
        });

        builder.Entity<Location>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "Location", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.ConfigureByConvention();
            b.HasOne(p => p.Street).WithMany().HasForeignKey(em => em.StreetId).OnDelete(DeleteBehavior.NoAction);
            b.HasOne(p => p.Village).WithMany().HasForeignKey(em => em.VillageId).OnDelete(DeleteBehavior.NoAction);
            b.HasOne(p => p.District).WithMany().HasForeignKey(em => em.DistrictId).OnDelete(DeleteBehavior.NoAction);
            b.HasOne(p => p.Provincial).WithMany().HasForeignKey(em => em.ProvincialId).OnDelete(DeleteBehavior.NoAction);
            b.HasOne(p => p.National).WithMany().HasForeignKey(em => em.NationalId).OnDelete(DeleteBehavior.NoAction);
        });

        builder.Entity<Street>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "Street", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.ConfigureByConvention();
            b.HasOne(p => p.Village).WithMany().HasForeignKey(em => em.VillageId).OnDelete(DeleteBehavior.NoAction);
        });

        builder.Entity<Village>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "Village", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.ConfigureByConvention();
            b.HasOne(p => p.District).WithMany().HasForeignKey(em => em.DistrictId).OnDelete(DeleteBehavior.NoAction);

        });

        builder.Entity<District>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "District", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.ConfigureByConvention();
            b.HasOne(p => p.Provincial).WithMany().HasForeignKey(em => em.ProvincialId).OnDelete(DeleteBehavior.NoAction);

        });

        builder.Entity<Provincial>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "Provincial", ProfileManagerDbProperties.DbSchema);
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.ConfigureByConvention();
            b.HasOne(p => p.National).WithMany().HasForeignKey(em => em.NationalId).OnDelete(DeleteBehavior.NoAction);

        });

        builder.Entity<National>(b =>
        {
            //Configure table & schema name
            b.Property(p => p.Id).HasDefaultValueSql("newid()");
            b.ToTable(ProfileManagerDbProperties.DbTablePrefix + "National", ProfileManagerDbProperties.DbSchema);
            b.ConfigureByConvention();
        });

    }
}
