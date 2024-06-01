namespace Macro_Model.Models
{
    public class ProdutoViewModel
    {

        public IEnumerable<Macro_Model.Models.Produto> Produtos { get; set; }
        public List<Macro_Model.Models.Listadefavorito> ListasFavoritos { get; set; }
        public string OrdenacaoAtual { get; set; }
    }
}
