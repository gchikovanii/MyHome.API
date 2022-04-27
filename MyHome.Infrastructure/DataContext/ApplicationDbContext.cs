using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyHome.Domain.Entities.AdvertisementAggregate;
using MyHome.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Infrastructure.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Advertisement>? Advertisements { get; set; }
        public DbSet<AdvertisementFeature>? AdvertisementFeatures { get; set; }
        public DbSet<Feature>? Features { get; set; }
        public DbSet<FeatureItem>? FeatureItems { get; set; }
        public DbSet<FeatureItemSelect>? FeatureItemSelects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(i => i.AppUserRoles)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId);

            builder.Entity<AppRole>()
                .HasMany(i => i.AppUserRoles)
                .WithOne(i => i.Role)
                .HasForeignKey(i => i.RoleId);

            builder.Entity<Feature>()
                .HasMany(i => i.FeatureItems)
                .WithOne(i => i.Feature)
                .HasForeignKey(i => i.FeatureId); 

            builder.Entity<AppUser>()
                .HasMany(i => i.Advertisements)
                .WithOne(i => i.AppUser)
                .HasForeignKey(i => i.UserId);

            builder.Entity<Advertisement>()
                .HasMany(i => i.AdvertisementFeatures)
                .WithOne(i => i.Advertisement)
                .HasForeignKey(i => i.AdvertisementId);

            builder.Entity<Feature>()
                .HasMany(i => i.FeatureItems)
                .WithOne(i => i.Feature)
                .HasForeignKey(i => i.FeatureId);

            builder.Entity<AdvertisementFeature>()
               .HasOne(i => i.FeatureItem)
               .WithMany(i => i.AdvertisementFeatures)
               .HasForeignKey(i => i.FeatureItemId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<FeatureItem>()
                .HasMany(i => i.FeatureItemSelects)
                .WithOne(i => i.FeatureItem)
                .HasForeignKey(i => i.FeatureItemId);
         

        }

        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Server=chiko\\SQLEXPRESS;Database=MyHomeDB;Trusted_Connection=True;MultipleActiveResultSets=True");
                return new ApplicationDbContext(options.Options);
            }
        }
    }
}
