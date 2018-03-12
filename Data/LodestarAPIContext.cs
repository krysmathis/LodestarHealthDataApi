using LodestarHealthDataApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LodestarHealthDataApi.Data
{
    public class LodestarAPIContext: DbContext
    {         
        public LodestarAPIContext(DbContextOptions<LodestarAPIContext> options)
            : base(options)
        { }

        public DbSet<Facility> Facility {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facility>()
            .HasIndex(p => new { p.Lat, p.Long });
        }
    
    }
}