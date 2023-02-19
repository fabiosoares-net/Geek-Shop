using Geek.Web.Domain.Interface;
using Geek.Web.Domain.Model;
using Geek.Web.Helper.Util;
using System.Net.Http.Headers;
using System.Reflection;

namespace Geek.Web.Domain.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/produto";

        public async Task Delete(Guid id)
        {
            // _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/{id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<ProdutoModel> Get(Guid id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.GetContentAs<ProdutoModel>();
        }

        public async Task<ProdutoModel> Post(ProdutoModel item)
        {
            var response = await _client.PostAsJson(BasePath, item);

            if (response.IsSuccessStatusCode)
                return await response.GetContentAs<ProdutoModel>();
            else 
                throw new Exception("Something went wrong when calling API");
        }

        public async Task Put(ProdutoModel item)
        {
            var response = await _client.PutAsJson(BasePath, item);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<IEnumerable<ProdutoModel>> Query()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.GetContentAs<List<ProdutoModel>>();
        }
    }
}
