using System.Diagnostics;
using System.Security.Claims;

using Macro_Model.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Macro_Model.Controllers
{
    [Authorize]
    public class CadastroController : Controller
	{

		private readonly AppDbContext _context;

		public CadastroController(AppDbContext context)
		{
			_context = context;
		}

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Usuario()
		{
			return View(await _context.Cadastro.ToListAsync());
		}

        [AllowAnonymous]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
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
                    new Claim(ClaimTypes.Role, dados.Perfil.ToString())
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


        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Cadastro");
        }


        [AllowAnonymous]
        public IActionResult AcessDenied()
		{
			return View();
		}

        [AllowAnonymous]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Cadastro(/*[Bind("Cpf,Nome,E-mail,Senha,Perfil")]*/ Cadastro cadastro)
		{

	
			
            if (ModelState.IsValid)
			{

				cadastro.Senha = BCrypt.Net.BCrypt.HashPassword(cadastro.Senha);
				_context.Cadastro.Add(cadastro);
				await _context.SaveChangesAsync();
				return RedirectToAction("Login");
			}
			return View();
		}

        
        public async Task<IActionResult> Edit(string? id)
		{

			if (id == null)
				return NotFound();

			var dados = await _context.Cadastro.FindAsync(id);

			if (dados == null)
				return NotFound();

			return View(dados);
		}

		[HttpPost]
        
        public async Task<IActionResult> Edit(/*[Bind("Cpf,Nome,E-mail,Senha,Perfil")]*/ string id, Cadastro cadastro)
		{
			if (id != cadastro.Cpf)
				return NotFound();

			if (ModelState.IsValid)
			{

				cadastro.Senha = BCrypt.Net.BCrypt.HashPassword(cadastro.Senha);
				_context.Cadastro.Update(cadastro);

                cadastro.Senha = BCrypt.Net.BCrypt.HashPassword(cadastro.Senha);
                _context.Cadastro.Update(cadastro);

				await _context.SaveChangesAsync();
				return RedirectToAction("Usuario");
			}
			return View();
		}
        
        public async Task<IActionResult> Detalhe(string? id)
		{
			if (id == null)
				return NotFound();

			var dados = await _context.Cadastro.FindAsync(id);

			if (dados == null)
				return NotFound();

			return View(dados);

		}

        
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Cadastro.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);

        }

		[HttpPost, ActionName("Delete")]
       
        public async Task<IActionResult> DeleteConfirmed(string? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Cadastro.FindAsync(id);

            if (dados == null)
                return NotFound();

			_context.Cadastro.Remove(dados);
			await _context.SaveChangesAsync();

            return RedirectToAction("Usuario");

        }
    }
}

