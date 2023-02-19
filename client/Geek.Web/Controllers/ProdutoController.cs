using Geek.Web.Domain.Interface;
using Geek.Web.Domain.Model;
using Geek.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Geek.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _produtoService.Query();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProdutoModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _produtoService.Post(model);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var model = await _produtoService.Get(id);

            if (model == null) 
                return NotFound();
                
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProdutoModel model)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.Put(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _produtoService.Get(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProdutoModel model)
        {
            await _produtoService.Delete(model.IdProduto);
            return RedirectToAction(nameof(Index));
        }
    }
}
