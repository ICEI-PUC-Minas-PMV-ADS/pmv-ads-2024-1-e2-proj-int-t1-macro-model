using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Macro_Model.Models
{
    [Table("Listadefavoritos")]
    public class Listadefavorito
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("Cadastro")]
        public string CadastroCpf { get; set; }
        public virtual Cadastro Cadastro { get; set; }


        [ForeignKey("Produto")]
        public string ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }


        [Display(Name = "Nome da lista")]
        [Required(ErrorMessage = "Obrigatório digitar um nome ")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string Nome { get; set; }


    }
}