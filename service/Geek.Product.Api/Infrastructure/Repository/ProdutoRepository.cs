using AutoMapper;
using Geek.Product.Api.Domain.VO;
using Geek.Product.Api.Domain.Interface;
using Geek.Product.Api.Domain.Model;
using Geek.Product.Api.Infrastructure;
using Geek.Product.Api.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Geek.Product.Api.Helper;

namespace Geek.Product.Api.Infrastructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _context;
        private IMapper _mapper;

        public ProdutoRepository(ProdutoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoVO>> Query()
        {
            return _mapper.Map<List<ProdutoVO>>(await _context.Produto.AsNoTracking().ToListAsync());
        }

        public async Task<ProdutoVO> Get(Guid id)
        {
            return _mapper.Map<ProdutoVO>(await _context.Produto.AsNoTracking().Where(p => p.IdProduto == id).FirstOrDefaultAsync());
        }

        public async Task<ProdutoVO> Post(ProdutoVO item)
        {
            if (_context.Produto.Where(x => x.Nome.Equals(item.Nome)).FirstOrDefault() != null)
            {
                throw new BusinessException($"O Produto com o Nome: {item.Nome} já existe!");
            }

            item.IdProduto = Guid.NewGuid();
            var produto = _mapper.Map<Produto>(item);
            produto.DataHoraCadastro = DateTime.Now;

            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();
            
            return _mapper.Map<ProdutoVO>(produto);
        }

        public async Task Put(ProdutoVO item)
        {
            var produtoBD = _context.Produto
                .Where(x => x.IdProduto == item.IdProduto)
                .FirstOrDefault();

            if (produtoBD != null)
            {
                produtoBD.Nome = item.Nome;
                produtoBD.NomeCategoria = item.NomeCategoria;
                produtoBD.Descricao = item.Descricao;
                produtoBD.Preco = item.Preco;
                produtoBD.ImageURL = item.ImageURL;

                _context.Produto.Update(produtoBD);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            _context.Produto.Remove(new Produto() { IdProduto = id });
            await _context.SaveChangesAsync();
        }
    }
}
