using example_net6_api.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace example_net6_api.Context 
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder
                .Entity<User>()
                .HasData(
                    new User { Id = 1 });
        }
    }
}