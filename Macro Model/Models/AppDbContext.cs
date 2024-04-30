using Microsoft.EntityFrameworkCore;
using Macro_Model.Models;

namespace Macro_Model.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

<<<<<<< HEAD
        public DbSet<Produto> Produto { get; set; }


        public DbSet<Cadastro> Cadastro { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Define um índice único para a coluna Email
            modelBuilder.Entity<Cadastro>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }
       
=======
        
		public DbSet<Produto> Produto { get; set; }
>>>>>>> 5cbf18c9b84570393ab4a5d15b52e40679f3d6a4

        public DbSet<Cadastro> Cadastro { get; set; }

      

    }
}
