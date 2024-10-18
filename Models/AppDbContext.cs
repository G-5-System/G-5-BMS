using Microsoft.EntityFrameworkCore;
namespace G_5_BMS.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)  
        {
                
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Clearance> Clearances { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<ID> Ids { get; set; }
        public DbSet<Complain> Complains { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

       

    }
}
