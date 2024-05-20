using Microsoft.EntityFrameworkCore;
using Macro_Model.Models;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;


namespace Macro_Model.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Produto> Produto { get; set; }
        		
		public DbSet<Listadefavorito> Listadefavorito { get; set; }
               
        public DbSet<Cadastro> Cadastro { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Define um índice único para a coluna Email
            modelBuilder.Entity<Cadastro>()
                .HasIndex(c => c.Email)
                .IsUnique();


            modelBuilder.Entity<Listadefavorito>()
                .HasOne(l => l.Cadastro)
                .WithMany(c => c.Listadefavorito)
                .HasForeignKey(c => c.Cpf);
            base.OnModelCreating(modelBuilder);

        }
      


    }
}
