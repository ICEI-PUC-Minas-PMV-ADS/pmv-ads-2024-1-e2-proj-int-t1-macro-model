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
        public int Id { get; set; }

        public string Cpf { get; set; }

        [ForeignKey("Cpf")]
        public Cadastro Cadastro { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }


        [Required(ErrorMessage ="Nome obrigatório!")]
        [DisplayName("Nome da Lista")]
        public string Nome { get; set; }
    }
}
