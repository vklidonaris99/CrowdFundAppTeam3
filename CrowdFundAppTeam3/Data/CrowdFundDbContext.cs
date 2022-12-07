using CrowdFoundAppTeam3.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CrowdFoundAppTeam3.Data
{
    public class CrowdFundDbContext : DbContext
    {
        //public DbSet<User> Users =>  Set<User>();

        public DbSet<FundingPackage> FundingPackages => Set<FundingPackage>();
        public DbSet<Project> Projects => Set<Project>();

        public DbSet<ProjectCreator> ProjectCreators => Set<ProjectCreator>();

        public DbSet<Backer> Backers => Set<Backer>();
        public CrowdFundDbContext(DbContextOptions<CrowdFundDbContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Backer>();
        //    builder.Entity<ProjectCreator>();

        //    base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);
        //}
    }
}

