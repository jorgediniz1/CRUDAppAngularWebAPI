using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Models
{
    public class Context : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public Context(DbContextOptions<Context> opcoes) : base(opcoes)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
        }
        
        
    }
}