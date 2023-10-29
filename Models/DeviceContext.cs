using Microsoft.EntityFrameworkCore;


namespace todogamma.Models
{
    public class DeviceContext : DbContext
    {
   
        public DbSet<Device> Devices { get; set; }
        public DbSet<Category> Categories {get; set;}
        public DbSet<Admin> Admins {get; set;}
	
        public DeviceContext(DbContextOptions<DeviceContext> options) : base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Device>()
        .ToTable("Device", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<Category>()
        .ToTable("Category", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<Admin>()
        .ToTable("Admin", t => t.ExcludeFromMigrations());
        }
	}
}