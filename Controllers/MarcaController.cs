using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAna.Models;

namespace ProjetoAna.Controllers
{
    public class MarcaController : Controller
    {
        private readonly MyDbContext _context;

        public MarcaController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Marca
        public async Task<IActionResult> Index()
        {
            return View(await _context.Marca.ToListAsync());
        }

        // GET: Marca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // GET: Marca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // GET: Marca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        // POST: Marca/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao")] Marca marca)
        {
            if (id != marca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // GET: Marca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // POST: Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marca = await _context.Marca.FindAsync(id);
            _context.Marca.Remove(marca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}