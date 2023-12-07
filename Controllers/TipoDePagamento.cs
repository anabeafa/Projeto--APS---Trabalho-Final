using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAna.Models;

namespace ProjetoAna.Controllers
{
    public class TipoDePagamentoController : Controller
    {
        private readonly MyDbContext _context;

        public TipoDePagamentoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: TipoDePagamento
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDePagamento.ToListAsync());
        }

        // GET: TipoDePagamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDePagamento = await _context.TipoDePagamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDePagamento == null)
            {
                return NotFound();
            }

            return View(tipoDePagamento);
        }

        // GET: TipoDePagamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDePagamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeDoCobrado,InformacoesAdicionais")] TipoDePagamento tipoDePagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDePagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDePagamento);
        }

        // GET: TipoDePagamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDePagamento = await _context.TipoDePagamento.FindAsync(id);
            if (tipoDePagamento == null)
            {
                return NotFound();
            }
            return View(tipoDePagamento);
        }

        // POST: TipoDePagamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeDoCobrado,InformacoesAdicionais")] TipoDePagamento tipoDePagamento)
        {
            if (id != tipoDePagamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDePagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDePagamento);
        }

        // GET: TipoDePagamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDePagamento = await _context.TipoDePagamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDePagamento == null)
            {
                return NotFound();
            }

            return View(tipoDePagamento);
        }

        // POST: TipoDePagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDePagamento = await _context.TipoDePagamento.FindAsync(id);
            _context.TipoDePagamento.Remove(tipoDePagamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}