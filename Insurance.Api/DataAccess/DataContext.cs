using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RiskType> RiskTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
            .HasOne(u => u.Person);

            builder.Entity<Person>()
            .HasOne(u => u.Gender);

            builder.Entity<Person>()
            .HasOne(u => u.Country);

            builder.Entity<Location>()
           .HasOne(u => u.Country);

            builder.Entity<InsurancePolicy>()
            .HasOne(u => u.RiskType);

            builder.Entity<InsurancePolicy>()
            .HasOne(u => u.Location);

            builder.Entity<InsurancePolicy>()
            .HasOne(u => u.CoverType);

            builder.Entity<UserRoles>()
            .HasKey(x => new { x.UserId, x.RoleId });

            builder.Entity<UserRoles>()
           .HasOne(u => u.User)
           .WithMany(u => u.Roles)
           .HasForeignKey(u => u.UserId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserRoles>()
           .HasOne(u => u.Role)
           .WithMany(u => u.Users)
           .HasForeignKey(u => u.RoleId)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
