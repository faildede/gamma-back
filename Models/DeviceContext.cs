using Microsoft.EntityFrameworkCore;


namespace todogamma.Models
{
    public class DeviceContext : DbContext
    {
   
        public DbSet<Device> Devices { get; set; }
	
    public DeviceContext(DbContextOptions<DeviceContext> options) : base(options)
{
}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    modelBuilder.Entity<Device>()
        .ToTable("Device", t => t.ExcludeFromMigrations());
}
	}
}