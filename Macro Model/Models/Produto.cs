using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Macro_Model.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        [Display(Name = "Código do produto")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [RegularExpression(@"^\d+$", ErrorMessage = "O código do produto deve conter apenas números")]
		public int Id { get; set; }
        

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Obrigatório digitar um nome ")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Informações Nutricionais")]
        [Required(ErrorMessage = "Obrigatório digitar uma relação nutricional")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Descreva qual o tipo de de produto e sua categoria nutricional.")]
        public string Nutricional { get; set; }

		[Display(Name = "Restrições alimentares ")]
		[Required(ErrorMessage = "Obrigatório informa as restrições do alimento ")]
		[MaxLength(500, ErrorMessage = "Máximo de 500 caracteres.")]
		public string Restricao { get; set; }

		[Display(Name = "Adicione uma imagem do produto. (máximo 5MB)")]
		public string Imagem { get; set; }

        [Display(Name = "Tipo de Conteúdo da Imagem")]
        [RegularExpression(@"^image\/(jpeg|png)$", ErrorMessage = "O tipo de conteúdo da imagem deve ser JPEG ou PNG.")]
        public string TipoConteudoImagem { get; set; }

		public virtual ICollection<RelacaoProdutoLista> RelacaoProdutoListas { get; set; }
	}
}
