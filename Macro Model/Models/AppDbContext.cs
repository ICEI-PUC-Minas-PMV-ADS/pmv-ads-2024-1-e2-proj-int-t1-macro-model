using Microsoft.EntityFrameworkCore;
using Macro_Model.Models;

namespace Macro_Model.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
		public DbSet<Produto> Produto { get; set; }

        public DbSet<Cadastro> Cadastro { get; set; }

      

    }
}
