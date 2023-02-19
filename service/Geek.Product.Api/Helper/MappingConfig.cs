using AutoMapper;
using Geek.Product.Api.Domain.VO;
using Geek.Product.Api.Domain.Model;

namespace Geek.Product.Api.Helper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ProdutoVO, Produto>().ReverseMap();
        }
    }
}
