using System.ComponentModel.DataAnnotations.Schema;

namespace Macro_Model.Models
{
	[Table("RelacaoProdutoListas")]
	public class RelacaoProdutoLista
	{
		// Chave estrangeira para Listadefavorito
		[ForeignKey("ListadefavoritoId")]
		public int ListadefavoritoId { get; set; }
		public Listadefavorito Listadefavorito { get; set; }


		// Chave estrangeira para Produto
		[ForeignKey("ProdutoId")]
		public int ProdutoId { get; set; }
		public Produto Produto { get; set; }
	}
}
