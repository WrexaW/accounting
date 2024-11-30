using accounting.entities;
using Microsoft.EntityFrameworkCore;

namespace accounting
{
    public class AccountinigDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<PackageEntity> Packages { get; set; }

        public DbSet<UserPackageEntity> UserPackages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=130.185.75.54;Database=Accounting;Encrypt=false;user id = i3center-1561 ; password = ");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
