using Geek.Product.Api.Domain.VO;

namespace Geek.Product.Api.Domain.Interface
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutoVO>> Query();
        Task<ProdutoVO> Get(Guid id);
        Task<ProdutoVO> Post(ProdutoVO item);
        Task Put(ProdutoVO item);
        Task Delete(Guid id);
    }
}
