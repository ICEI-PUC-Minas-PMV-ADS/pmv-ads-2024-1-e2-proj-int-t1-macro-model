﻿using System.Diagnostics;
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

        public async Task<IActionResult> Lista()
        {
			var produtos = _context.Produto.ToList();
			ViewBag.ListasFavoritos = _context.Listadefavorito.ToList();
			return View(produtos);
			//return View(await _context.Produto.ToListAsync());
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



    }
}
