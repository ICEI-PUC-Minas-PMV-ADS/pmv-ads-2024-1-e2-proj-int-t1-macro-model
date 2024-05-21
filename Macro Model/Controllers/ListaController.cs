using System.Diagnostics;
using System.Drawing;
using Macro_Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Macro_Model.Controllers
{
	[Authorize]
	public class ListaController : Controller
	{
		private readonly AppDbContext _context;

		public ListaController(AppDbContext context)
		{
			_context = context;


		}


		public async Task<IActionResult> ListaFavoritos()
		{
			var usuarioNome = User.Identity.Name;
			if (string.IsNullOrEmpty(usuarioNome))
			{
				// Usuário não está autenticado ou nome de usuário inválido
				return RedirectToAction("Login"); // Redirecionar para a página de login
			}
			
			var usuario = await _context.Cadastro
				.Include(c => c.Listadefavorito)
				.ThenInclude(l => l.RelacaoProdutoListas)
				.ThenInclude(r => r.Produto)
				.FirstOrDefaultAsync(c => c.Nome == usuarioNome);

			var favoritos = usuario.Listadefavorito;

			return View(favoritos);

		}


		[HttpPost]
		public async Task<IActionResult> CriaFavoritos([Bind("Nome")] string nomeLista)
		{
			if (ModelState.IsValid)
			{
				var usuarioNome = User.Identity.Name; // Obtém o nome de usuário

				if (string.IsNullOrEmpty(usuarioNome))
				{
					// Usuário não está autenticado ou nome de usuário inválido
					return RedirectToAction("Login"); // Redirecionar para a página de login
				}

				// Busca o usuário na tabela Cadastro pelo nome de usuário
				var usuario = _context.Cadastro.FirstOrDefault(c => c.Nome == usuarioNome);

				if (usuario == null)
				{
					// Usuário não encontrado na tabela Cadastro
					// Trate o erro de acordo com a sua lógica de negócios
					return RedirectToAction("Erro");
				}

				// CPF do usuário encontrado, cria uma nova lista de favoritos
				var listaFavoritos = new Listadefavorito
				{
					Cadastro = usuario,
					Nome = nomeLista
				};

				_context.Listadefavorito.Add(listaFavoritos);
				await _context.SaveChangesAsync();
				return RedirectToAction("ListaFavoritos");
			}
			return View();

		}


		public async Task<IActionResult> Editar(int? id)
		{

			if (id == null)
				return NotFound();

			var dados = await _context.Listadefavorito.FindAsync(id);

			if (dados == null)
				return NotFound();

			return View(dados);
		}

		[HttpPost]
		public async Task<IActionResult> Editar(int? id, Listadefavorito listadefavorito)
		{
			if (id != listadefavorito.Id)
				return NotFound();

			if (ModelState.IsValid)
			{

				_context.Listadefavorito.Update(listadefavorito);
				await _context.SaveChangesAsync();
				return RedirectToAction("ListaFavoritos");


			}
			return View();
		}




		public async Task<IActionResult> Detalhe(int? id)
		{
			if (id == null)
				return NotFound();

			var dados = await _context.Listadefavorito.FindAsync(id);

			if (dados == null)
				return NotFound();

			return View(dados);

		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return NotFound();

			var dados = await _context.Listadefavorito.FindAsync(id);

			if (dados == null)
				return NotFound();

			return RedirectToAction("ListaFavoritos");

		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int? id)
		{
			var dados = await _context.Listadefavorito.FindAsync(id);
			if (dados != null)
			{
				_context.Listadefavorito.Remove(dados);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction(nameof(ListaFavoritos));

		}




		//public async Task<IActionResult> SelecionarLista(int produtoId)
		//{
		//	var listasFavoritos = await _context.Listadefavorito.ToListAsync();
		//	var viewModel = new ListaFavoritosViewModel
		//		{
		//			ListasFavoritos = listasFavoritos
		//		};

		//	return View(viewModel);
		//}

		// Ação para adicionar o produto à lista selecionada

		[HttpPost]
		public async Task<IActionResult> AdicionarProdutoNaLista(int produtoId, int listaId)
		{
			var produto = await _context.Produto.FindAsync(produtoId);
			var listaFavorito = await _context.Listadefavorito.FindAsync(listaId);

			if (produto == null || listaFavorito == null)
			{
				return NotFound();
			}
			var relacao = new RelacaoProdutoLista
			{
				ProdutoId = produtoId,
				ListadefavoritoId = listaId
			};

			_context.RelacaoProdutoListas.Add(relacao);
			await _context.SaveChangesAsync();

			return RedirectToAction("ListaFavoritos");
		}

		

	}
}
