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
    public class PermisoinsController : Controller
    {
        private readonly baseartfContext _context;

        public PermisoinsController(baseartfContext context)
        {
            _context = context;
        }

        // GET: Permisoins
        public async Task<IActionResult> Index()
        {
              return _context.Permisoins != null ? 
                          View(await _context.Permisoins.ToListAsync()) :
                          Problem("Entity set 'baseartfContext.Permisoins'  is null.");
        }

        // GET: Permisoins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Permisoins == null)
            {
                return NotFound();
            }

            var permisoin = await _context.Permisoins
                .FirstOrDefaultAsync(m => m.Idperins == id);
            if (permisoin == null)
            {
                return NotFound();
            }

            return View(permisoin);
        }

        // GET: Permisoins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Permisoins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idperins,Numper,Numofper,Fechaper,Obper,Tipoper,Lugaper,Estaper,Munper,Obrper,Vigenper,Condper,Noautpro,Areares,Areapro,Fechaappro,Proejeper,Natgar,Montgar,Tergar,Cauter,Replegal,Instnot,Obsper,Homoins")] Permisoin permisoin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permisoin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permisoin);
        }

        // GET: Permisoins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Permisoins == null)
            {
                return NotFound();
            }

            var permisoin = await _context.Permisoins.FindAsync(id);
            if (permisoin == null)
            {
                return NotFound();
            }
            return View(permisoin);
        }

        // POST: Permisoins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idperins,Numper,Numofper,Fechaper,Obper,Tipoper,Lugaper,Estaper,Munper,Obrper,Vigenper,Condper,Noautpro,Areares,Areapro,Fechaappro,Proejeper,Natgar,Montgar,Tergar,Cauter,Replegal,Instnot,Obsper,Homoins")] Permisoin permisoin)
        {
            if (id != permisoin.Idperins)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permisoin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermisoinExists(permisoin.Idperins))
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
            return View(permisoin);
        }

        // GET: Permisoins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Permisoins == null)
            {
                return NotFound();
            }

            var permisoin = await _context.Permisoins
                .FirstOrDefaultAsync(m => m.Idperins == id);
            if (permisoin == null)
            {
                return NotFound();
            }

            return View(permisoin);
        }

        // POST: Permisoins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Permisoins == null)
            {
                return Problem("Entity set 'baseartfContext.Permisoins'  is null.");
            }
            var permisoin = await _context.Permisoins.FindAsync(id);
            if (permisoin != null)
            {
                _context.Permisoins.Remove(permisoin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermisoinExists(int id)
        {
          return (_context.Permisoins?.Any(e => e.Idperins == id)).GetValueOrDefault();
        }
    }
}
