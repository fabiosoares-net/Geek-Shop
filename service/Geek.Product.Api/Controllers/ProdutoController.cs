using Geek.Product.Api.Domain.VO;
using Geek.Product.Api.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Geek.Product.Api.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Query()
        {
            return Ok(await _repository.Query());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _repository.Get(id);

            if (product == null) 
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProdutoVO item)
        {
            return Ok(await _repository.Post(item));
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProdutoVO item)
        {
            await _repository.Put(item);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}
