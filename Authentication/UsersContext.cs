using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace todogamma
{
    public class UsersContext : IdentityDbContext<IdentityUser>
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // It would be a good idea to move the connection string to user secrets
            options.UseNpgsql("Host=localhost;Port=25432;Database=gamma;Username=admin;Password=12345;");
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Возможно, лучше удалить этот метод, если не делаете дополнительных настроек
    base.OnModelCreating(modelBuilder);
}
    }
}