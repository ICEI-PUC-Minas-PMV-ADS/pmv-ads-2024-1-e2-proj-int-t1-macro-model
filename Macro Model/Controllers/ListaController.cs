using System.Diagnostics;
using System.Drawing;
using System.Security.Claims;
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


            if (usuario == null)
            {
                // Se o usuário não for encontrado
                return NotFound(); // Ou redirecionar para outra página apropriada
            }
            ViewBag.ListasFavoritos = usuario.Listadefavorito;
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

			var listaFavorito = await _context.Listadefavorito
		    .Include(l => l.RelacaoProdutoListas)
		    .ThenInclude(r => r.Produto) // Certifique-se de incluir os produtos relacionados
		    .FirstOrDefaultAsync(m => m.Id == id);

			if (listaFavorito == null)
			{
				return NotFound();
			}

			return View(listaFavorito);
		}

        [HttpPost]
        public async Task<IActionResult> Editar(int? id, Listadefavorito listadefavorito)
        {
			if (id != listadefavorito.Id || listadefavorito == null)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				try
				{
					_context.Listadefavorito.Update(listadefavorito);
					await _context.SaveChangesAsync();
					return RedirectToAction("Detalhe", "Lista", new { id = listadefavorito.Id });
				}
				catch (DbUpdateException)
				{
					// Lidar com erros de atualização do banco de dados
					ModelState.AddModelError("", "Ocorreu um erro ao salvar as alterações. Por favor, tente novamente.");
					return View(listadefavorito);
				}
			}
			return View();
        }




        public async Task<IActionResult> Detalhe(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Listadefavorito
            .Include(l => l.RelacaoProdutoListas)
            .ThenInclude(r => r.Produto)
            .FirstOrDefaultAsync(m => m.Id == id);

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



        [HttpPost]
        public async Task<IActionResult> AdicionarProdutoNaLista(int listaId, int produtoId)
        {
			// Obtém o userId do usuário logado
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            			

			var listaFavoritos = await _context.Listadefavorito
                .Include(l => l.RelacaoProdutoListas)
                .FirstOrDefaultAsync(l => l.Id == listaId && l.Cadastro.Cpf == userId);

            if (listaFavoritos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(produtoId);
            if (produto == null)
            {
                return NotFound();
            }

			// Verifica se o produto já está na lista
			var produtoNaLista = listaFavoritos.RelacaoProdutoListas
				.Any(rpl => rpl.ProdutoId == produtoId);

			if (produtoNaLista)
			{
				// Produto já está na lista, retorna uma mensagem ou redireciona conforme necessário
				TempData["ErrorMessage"] = "O produto já está na lista.";
				return RedirectToAction("Lista", "Produto"); // Supondo que "Detalhe" seja a view para exibir detalhes da lista
			}

			listaFavoritos.RelacaoProdutoListas.Add(new RelacaoProdutoLista
            {
                ProdutoId = produtoId,
                ListadefavoritoId = listaId
            });
            await _context.SaveChangesAsync();

            // Redireciona para a view de detalhes da lista específica
            return RedirectToAction("Detalhe", "Lista", new { id = listaId });
        }


		[HttpPost]
		public async Task<IActionResult> RemoverProduto(int listaId, int produtoId)
		{
			var listaFavoritos = await _context.Listadefavorito
				.Include(l => l.RelacaoProdutoListas)
				.FirstOrDefaultAsync(l => l.Id == listaId);

			if (listaFavoritos == null)
			{
				return NotFound();
			}

			var relacaoProduto = listaFavoritos.RelacaoProdutoListas.FirstOrDefault(r => r.ProdutoId == produtoId);
			if (relacaoProduto == null)
			{
				return NotFound();
			}

			
			listaFavoritos.RelacaoProdutoListas.Remove(relacaoProduto);
			await _context.SaveChangesAsync();

			// Redireciona de volta para a página de edição da lista
			return RedirectToAction("Detalhe", "Lista", new { id = listaId });
		}


	}



}

