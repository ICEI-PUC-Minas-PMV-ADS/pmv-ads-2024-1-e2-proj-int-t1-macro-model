using System.Diagnostics;
using System.Drawing;
using Macro_Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Security.Claims;


namespace Macro_Model.Controllers
{
    [Authorize]
	public class ProdutoController : Controller
	{
		private readonly AppDbContext _context;
        
		public ProdutoController(AppDbContext context )
		{
			_context = context;
           

		}

		public async Task<IActionResult> Lista(string ordenacao)
		{
            var usuarioNome = User.Identity.Name;
            if (string.IsNullOrEmpty(usuarioNome))
            {
                return RedirectToAction("Login");
            }

            var usuario = await _context.Cadastro
                .Include(c => c.Listadefavorito)
                .FirstOrDefaultAsync(c => c.Nome == usuarioNome);

            if (usuario == null)
            {
                return NotFound();
            }

            var produtos = _context.Produtos.AsQueryable();

            // Verifica se foi escolhida uma opção de ordenação
            switch (ordenacao)
            {
                case "Nome":
                    produtos = produtos.OrderBy(p => p.Nome);
                    break;

                // Adicione mais casos conforme necessário
                default:
                    produtos = produtos.OrderBy(p => p.Id); // Ordenação padrão
                    break;
            }

            var viewModel = new ProdutoViewModel
            {
				Produtos = await produtos.ToListAsync(),
				ListasFavoritos = usuario.Listadefavorito.ToList(), // Convertendo HashSet para List
				OrdenacaoAtual = ordenacao
			};

            return View(viewModel);
   
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
              
			    _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Lista");
            }
            return View(produto);
        }

        public async Task<IActionResult> Editar(int? id)
        {

            if (id == null)
                return NotFound();

            var dados = await _context.Produtos.FindAsync(id);

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
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Lista");
            }
            return View();
        }

        public async Task<IActionResult> Detalhe(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Produtos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Produtos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Produtos.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Produtos.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Lista");

        }



    }
}
