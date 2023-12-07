using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAna.Models;

namespace ProjetoAna.Controllers
{
    public class TransportadoraController : Controller
    {
        private readonly MyDbContext _context;

        public TransportadoraController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Transportadora
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transportadora.ToListAsync());
        }

        // GET: Transportadora/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportadora = await _context.Transportadora
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportadora == null)
            {
                return NotFound();
            }

            return View(transportadora);
        }

        // GET: Transportadora/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transportadora/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome")] Transportadora transportadora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transportadora);
        }

        // GET: Transportadora/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportadora = await _context.Transportadora.FindAsync(id);
            if (transportadora == null)
            {
                return NotFound();
            }
            return View(transportadora);
        }

        // POST: Transportadora/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Transportadora transportadora)
        {
            if (id != transportadora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportadora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(transportadora);
        }

        // GET: Transportadora/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportadora = await _context.Transportadora
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportadora == null)
            {
                return NotFound();
            }

            return View(transportadora);
        }

        // POST: Transportadora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transportadora = await _context.Transportadora.FindAsync(id);
            _context.Transportadora.Remove(transportadora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}