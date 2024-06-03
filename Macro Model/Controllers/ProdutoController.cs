using System.Diagnostics;
using System.Drawing;
using Macro_Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;


namespace Macro_Model.Controllers
{
	[Authorize]
	public class ProdutoController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _env;
		public ProdutoController(AppDbContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;

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
				case "Calorias":
                    produtos = produtos.OrderByDescending(p => p.Caloria);
					break;
				case "CaloriasMenor":
					produtos = produtos.OrderBy(p => p.Caloria);
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
        public async Task<IActionResult> Produto(ProdutoViewModel model, IFormFile imagem)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Verifica se foi enviado um arquivo de imagem e se é válido
                    if (imagem != null && imagem.Length > 0 && IsImagemValida(imagem))
                    {
                        // Define o caminho onde a imagem será salva
                        var imagePath = Path.Combine(_env.WebRootPath, "imagens");

                        // Verifica se o diretório existe, senão cria
                        if (!Directory.Exists(imagePath))
                        {
                            Directory.CreateDirectory(imagePath);
                        }

                        // Define um nome único para o arquivo
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);

                        // Define o caminho completo do arquivo
                        var filePath = Path.Combine(imagePath, fileName);

                        // Salva a imagem no diretório
                        using (FileStream stream = new FileStream(filePath, FileMode.Create))
                        {
                            await imagem.CopyToAsync(stream);
                        }

                        // Atualiza o caminho da imagem no modelo
                        model.Imagem = "/imagens/" + fileName;
                    }

                    // Converte ProdutoViewModel para Produto
                    var produto = new Produto
                    {
                        Nome = model.Nome,
                        Nutricional = model.Nutricional,
                        Restricao = model.Restricao,
                        Imagem = model.Imagem // Adiciona o caminho da imagem
                    };

                    // Adiciona o produto ao contexto e salva no banco de dados
                    _context.Produtos.Add(produto);
                    await _context.SaveChangesAsync();

                    // Redireciona para a página de lista de produtos
                    return RedirectToAction("Lista");
                }
                catch (IOException ex)
                {
                    // Trata exceções de E/S (pode ocorrer ao salvar a imagem)
                    ModelState.AddModelError("", "Erro de E/S ao salvar a imagem.");
                }
                catch (Exception ex)
                {
                    // Trata outras exceções genéricas
                    ModelState.AddModelError("", "Ocorreu um erro ao cadastrar o produto. Por favor, tente novamente.");
                }
            }

            // Se houver erros de validação ou se a imagem não for válida, retorna para a view com os erros
            return View(model);
        }

        // Verifica se o arquivo é uma imagem
        private bool IsImagemValida(IFormFile file)
        {
            // Lista de tipos de arquivo de imagem permitidos
            var tiposImagemPermitidos = new[] { "image/jpeg", "image/png", "image/gif" };

            // Verifica se o tipo de conteúdo do arquivo está na lista de tipos de imagem permitidos
            return tiposImagemPermitidos.Contains(file.ContentType);
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


		[HttpPost]
		public async Task<IActionResult> UploadImagem(IFormFile arquivo)
		{
			if (arquivo == null || arquivo.Length == 0)
			{
				return BadRequest("Nenhum arquivo enviado.");
			}

			var extensao = Path.GetExtension(arquivo.FileName);
			var tipoConteudo = arquivo.ContentType;

			// Verificar se a extensão e o tipo de conteúdo correspondem a JPEG ou PNG
			if (extensao != ".jpg" && extensao != ".jpeg" && extensao != ".png")
			{
				return BadRequest("O arquivo deve ser do tipo JPEG ou PNG.");
			}

			// Salvar a imagem em uma pasta específica
			var nomeArquivo = Guid.NewGuid().ToString() + extensao;
			var caminhoArquivo = Path.Combine(_env.WebRootPath, "imagens", nomeArquivo);

			using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
			{
				await arquivo.CopyToAsync(stream);
			}

			// Salvar informações da imagem no banco de dados, como caminho e tipo de conteúdo
			// Você pode associar essas informações ao seu objeto Produto

			return Ok(new { caminho = "/imagens/" + nomeArquivo }); // Retorna o caminho da imagem
		}


        
    }
}
