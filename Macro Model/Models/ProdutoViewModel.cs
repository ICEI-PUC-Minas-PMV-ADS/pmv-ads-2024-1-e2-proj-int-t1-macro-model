

namespace Macro_Model.Models
{
    public class ProdutoViewModel
    {

        public IEnumerable<Macro_Model.Models.Produto> Produtos { get; set; }
        public List<Macro_Model.Models.Listadefavorito> ListasFavoritos { get; set; }
        public string OrdenacaoAtual { get; set; }

		public decimal Caloria { get; set; }
		public string Imagem { get; set; } // Propriedade para armazenar o caminho da imagem

		public string Nome { get; set; } // Propriedade para armazenar o nome do produto

		public string Nutricional { get; set; } // Propriedade para armazenar informações nutricionais

		public string Restricao { get; set; } // Propriedade para armazenar informações de restrição alimentar

		// Construtor vazio para garantir que o modelo seja inicializado corretamente
		public ProdutoViewModel()
		{
		}

		
	}
}
