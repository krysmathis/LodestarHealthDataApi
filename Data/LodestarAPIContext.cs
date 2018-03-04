using Microsoft.EntityFrameworkCore;

namespace LodestarHealthDataApi.Data
{
    public class LodestarAPIContext: DbContext
    {         
        public LodestarAPIContext(DbContextOptions<LodestarAPIContext> options)
            : base(options)
        { }

        //public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    
    }
}