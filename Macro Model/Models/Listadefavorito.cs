using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Macro_Model.Models
{
    [Table("Listadefavorito")]
    public class Listadefavorito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Cadastro")]
        public string CadastroCpf { get; set; }
        public virtual Cadastro Cadastro { get; set; }

        [ForeignKey("ProdutoFK")]
        public int ProdutoId { get; set; }
        public virtual Produto ProdutoFK { get; set; }


        [DisplayName("Nome da Lista")]
        public string Nome { get; set; }


        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
