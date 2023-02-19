using Geek.Web.Domain.Model;

namespace Geek.Web.Domain.Interface
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoModel>> Query();
        Task<ProdutoModel> Get(Guid id);
        Task<ProdutoModel> Post(ProdutoModel item);
        Task Put(ProdutoModel item);
        Task Delete(Guid id);
    }
}
