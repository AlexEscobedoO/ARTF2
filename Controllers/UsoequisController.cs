using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ARTF2.Models;

namespace ARTF2.Controllers
{
    public class UsoequisController : Controller
    {
        private readonly baseartfContext _context;

        public UsoequisController(baseartfContext context)
        {
            _context = context;
        }

        // GET: Usoequis
        public async Task<IActionResult> Index()
        {
              return _context.Usoequis != null ? 
                          View(await _context.Usoequis.ToListAsync()) :
                          Problem("Entity set 'baseartfContext.Usoequis'  is null.");
        }

        // GET: Usoequis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usoequis == null)
            {
                return NotFound();
            }

            var usoequi = await _context.Usoequis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usoequi == null)
            {
                return NotFound();
            }

            return View(usoequi);
        }

        // GET: Usoequis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usoequis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Usoequi1")] Usoequi usoequi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usoequi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usoequi);
        }

        // GET: Usoequis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usoequis == null)
            {
                return NotFound();
            }

            var usoequi = await _context.Usoequis.FindAsync(id);
            if (usoequi == null)
            {
                return NotFound();
            }
            return View(usoequi);
        }

        // POST: Usoequis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Usoequi1")] Usoequi usoequi)
        {
            if (id != usoequi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usoequi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsoequiExists(usoequi.Id))
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
            return View(usoequi);
        }

        // GET: Usoequis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usoequis == null)
            {
                return NotFound();
            }

            var usoequi = await _context.Usoequis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usoequi == null)
            {
                return NotFound();
            }

            return View(usoequi);
        }

        // POST: Usoequis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usoequis == null)
            {
                return Problem("Entity set 'baseartfContext.Usoequis'  is null.");
            }
            var usoequi = await _context.Usoequis.FindAsync(id);
            if (usoequi != null)
            {
                _context.Usoequis.Remove(usoequi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsoequiExists(int id)
        {
          return (_context.Usoequis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
