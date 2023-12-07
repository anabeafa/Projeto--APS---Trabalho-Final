using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAna.Models;

namespace ProjetoAna.Controllers
{
    public class NotaDeVendaController : Controller
    {
        private readonly MyDbContext _context;

        public NotaDeVendaController(MyDbContext context)
        {
            _context = context;
        }

        // GET: NotaDeVenda
        public async Task<IActionResult> Index()
        {
            return View(await _context.NotaDeVenda.ToListAsync());
        }

        // GET: NotaDeVenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotaDeVenda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            return View(notaDeVenda);
        }

        // GET: NotaDeVenda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NotaDeVenda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Tipo")] NotaDeVenda notaDeVenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notaDeVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notaDeVenda);
        }

        // GET: NotaDeVenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotaDeVenda.FindAsync(id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }
            return View(notaDeVenda);
        }

        // POST: NotaDeVenda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Tipo")] NotaDeVenda notaDeVenda)
        {
            if (id != notaDeVenda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notaDeVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(notaDeVenda);
        }

        // GET: NotaDeVenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotaDeVenda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            return View(notaDeVenda);
        }

        // POST: NotaDeVenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notaDeVenda = await _context.NotaDeVenda.FindAsync(id);
            _context.NotaDeVenda.Remove(notaDeVenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Método para cancelar uma nota de venda
        public async Task<IActionResult> Cancelar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotaDeVenda.FindAsync(id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            notaDeVenda.Cancelada = true; // Defina a propriedade Cancelada como true ou insira a lógica adequada para cancelar

            _context.Update(notaDeVenda);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Método para devolver uma nota de venda
        public async Task<IActionResult> Devolver(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotaDeVenda.FindAsync(id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            notaDeVenda.Devolvida = true; // Defina a propriedade Devolvida como true ou insira a lógica adequada para devolver

            _context.Update(notaDeVenda);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}