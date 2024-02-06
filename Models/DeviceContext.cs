using Microsoft.EntityFrameworkCore;

namespace todogamma.Models
{
	public class DeviceContext : DbContext
    {
   
        public DbSet<Device> Devices { get; set; }
        public virtual DbSet<Category> Categories {get; set;}
  
	
        public DeviceContext(DbContextOptions<DeviceContext> options) : base(options)
        {
        
        }
      
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Device>(entity => 
        {
            entity.ToTable(nameof(Device));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Manufacturer)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Price)
                .IsRequired();

            entity.HasOne(e => e.Category)
                .WithMany(e => e.Devices)
                .HasForeignKey(e => e.CategoryId);

        });
        modelBuilder.Entity<Category>(entity => 
        {
            entity.ToTable(nameof(Category));
            
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title)
                  .IsRequired()
                  .HasMaxLength(200);
            
        });
        }

		
	}


}
