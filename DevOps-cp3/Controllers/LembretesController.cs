using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevOps_cp3.Models;
using DevOps_cp3.Persistence;
using System.Diagnostics;

namespace DevOps_cp3.Controllers
{
    public class LembretesController : Controller
    {
        private readonly AzureDbContext _context;

        public LembretesController(AzureDbContext context)
        {
            _context = context;
        }

        // GET: Lembretes
        public async Task<IActionResult> Index()
        {
              return _context.Lembretes != null ? 
                          View(await _context.Lembretes.ToListAsync()) :
                          Problem("Entity set 'AzureDbContext.Lembretes'  is null.");
        }

        // GET: Lembretes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Lembretes == null)
            {
                return NotFound();
            }

            var lembrete = await _context.Lembretes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lembrete == null)
            {
                return NotFound();
            }

            return View(lembrete);
        }

        // GET: Lembretes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lembretes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Texto,DataHoraLembrete,Id")] Lembrete lembrete)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(lembrete);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception for debugging purposes
                    // You can also return an error view or message to the user
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the record.");
                    return View(ex);
                }
            }
            return View(lembrete);
        }

        // GET: Lembretes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Lembretes == null)
            {
                return NotFound();
            }

            var lembrete = await _context.Lembretes.FindAsync(id);
            if (lembrete == null)
            {
                return NotFound();
            }
            return View(lembrete);
        }

        // POST: Lembretes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Texto,DataHoraLembrete,Id")] Lembrete lembrete)
        {
            if (id != lembrete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lembrete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LembreteExists(lembrete.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lembrete);
        }

        // GET: Lembretes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Lembretes == null)
            {
                return NotFound();
            }

            var lembrete = await _context.Lembretes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lembrete == null)
            {
                return NotFound();
            }

            return View(lembrete);
        }

        // POST: Lembretes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Lembretes == null)
            {
                return Problem("Entity set 'AzureDbContext.Lembretes'  is null.");
            }
            var lembrete = await _context.Lembretes.FindAsync(id);
            if (lembrete != null)
            {
                _context.Lembretes.Remove(lembrete);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LembreteExists(long id)
        {
          return (_context.Lembretes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
