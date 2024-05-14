using System.Diagnostics;
using System.Drawing;
using Macro_Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace Macro_Model.Controllers
{
    [Authorize]
	public class ProdutoController : Controller
	{
		private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHost;

		public ProdutoController(AppDbContext context, IWebHostEnvironment webHost)
		{
			_context = context;
            _webHost = webHost;

		}

        public async Task<IActionResult> Lista()
        {
            return View(await _context.Produto.ToListAsync());
        }

        
        public IActionResult Produto()
		{
		
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Produto([Bind("Id,Nome,Nutricional,Restricao")]Produto produto)
        {
          

            if (ModelState.IsValid)
            {
              
			    _context.Produto.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Lista");
            }
            return View(produto);
        }

        public async Task<IActionResult> Editar(int? id)
        {

            if (id == null)
                return NotFound();

            var dados = await _context.Produto.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(int? id, Produto produto)
        {
            if (id != produto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Produto.Update(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Lista");
            }
            return View();
        }

        public async Task<IActionResult> Detalhe(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Produto.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Produto.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Produto.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Produto.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Lista");

        }


        //[HttpPost]
        //public async Task<IActionResult> Listafavorito(int? id)
        //{
        //    var usuarioCpf = User.Identity.Name; // Obtém o CPF do usuário logado

        //    // Verifica se o usuário já possui uma lista de favoritos
        //    var listaFavoritos = await _context.Listadefavorito.Include(lf => lf.ProdutoFK).FirstOrDefaultAsync(up => up.CadastroCpf == usuarioCpf);
        //    if (listaFavoritos == null)
        //    {
        //        // Se o usuário não tiver uma lista de favoritos, redireciona para uma página onde ele pode criar a lista
        //        return RedirectToAction("CriarListaFavoritos");
        //    }

        //    // Adiciona o produto à lista de favoritos do usuário
        //    listaFavoritos.Produtos.Add(new Produto { Id = id });
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("Lista");
        //}

        //public IActionResult CriarListaFavoritos()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> CriarListaFavoritos(string nomeLista)
        //{
        //    var usuarioCpf = User.Identity.Name; // Obtém o CPF do usuário logado

        //    // Cria uma nova lista de favoritos para o usuário
        //    var listaFavoritos = new Listadefavorito
        //    {
        //        CadastroCpf = usuarioCpf,
        //        Nome = nomeLista
        //    };
        //    _context.Listadefavorito.Add(listaFavoritos);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("Lista");
        //}
    }
}
