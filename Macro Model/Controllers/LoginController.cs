using System.Diagnostics;
using System.Security.Claims;
using Macro_Model.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

namespace Macro_Model.Controllers
{
	
	public class LoginController : Controller
	{
		private readonly AppDbContext _context;

		public LoginController(AppDbContext context)
		{
			_context = context;
		}
		
		public IActionResult Login()
		{
		
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Login(Cadastro cadastro)
		{

			var dados = await _context.Cadastro.FirstOrDefaultAsync(c => c.Cpf == cadastro.Cpf || c.Email == cadastro.Email);
			//var dados = await _context.Cadastro.FindAsync(cadastro.Cpf);

			if (dados == null)
			{
				ViewBag.Message = "Usuário e/ou senha inválidos! ";
				return View();
			}


			bool senhaCorreta = BCrypt.Net.BCrypt.Verify(cadastro.Senha, dados.Senha);

			if (senhaCorreta)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, dados.Nome),
					new Claim(ClaimTypes.NameIdentifier, dados.Cpf.ToString()),
					new Claim(ClaimTypes.Role, dados.Email.ToString())
				};

				var usuarioIdentididade = new ClaimsIdentity(claims, "login");
				ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentididade);

				var propriedade = new AuthenticationProperties
				{
					AllowRefresh = true,
					ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
					IsPersistent = true,
				};
				await HttpContext.SignInAsync(principal, propriedade);
				return Redirect("/");


			}
			else
			{
				ViewBag.Message = "Usuário e/ou senha inválidos!";
			}

			return View();
		}


		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Login", "Login");
		}


		public IActionResult AcessDenied()
		{
			return View();
		}

	}
}
