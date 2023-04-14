using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WeatherApp.Models;

namespace WeatherApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Weather> Weather { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
