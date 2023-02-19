namespace Geek.Web.Domain.Model
{
    public class ProdutoModel
    {
        public Guid IdProduto { get; set; }
        public string NomeCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImageURL { get; set; }
    }
}
