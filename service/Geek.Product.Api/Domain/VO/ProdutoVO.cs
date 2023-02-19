namespace Geek.Product.Api.Domain.VO
{
    public class ProdutoVO
    {
        public Guid IdProduto { get; set; }
        public string NomeCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImageURL { get; set; }
    }
}
