using LodestarHealthDataApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LodestarHealthDataApi.Data
{
    public class LodestarAPIContext: IdentityDbContext<ApplicationUser>
    {         
        public LodestarAPIContext(DbContextOptions<LodestarAPIContext> options)
            : base(options)
        { }

        public DbSet<Facility> Facility {get;set;}
        public DbSet<Hospital> Hospital {get;set;}
        public DbSet<ApplicationUser> ApplicationUser {get;set;}
        public DbSet<HomeLocation> HomeLocation {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Facility>()
            .HasIndex(p => new { p.Lat, p.Long });
        }
    
    }
}