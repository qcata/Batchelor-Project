using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<TablesLayout> Tables { get; set; }

        public DbSet<Appointments> Appointments { get; set; }

        public DbSet<RestaurantSettings> RestaurantSettings { get; set; }
    }
}
