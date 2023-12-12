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
    public class PermicansController : Controller
    {
        private readonly baseartfContext _context;

        public PermicansController(baseartfContext context)
        {
            _context = context;
        }

        // GET: Permicans
        public async Task<IActionResult> Index()
        {
              return _context.Permicans != null ? 
                          View(await _context.Permicans.ToListAsync()) :
                          Problem("Entity set 'baseartfContext.Permicans'  is null.");
        }

        // GET: Permicans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Permicans == null)
            {
                return NotFound();
            }

            var permican = await _context.Permicans
                .FirstOrDefaultAsync(m => m.Idper == id);
            if (permican == null)
            {
                return NotFound();
            }

            return View(permican);
        }

        // GET: Permicans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Permicans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idper,Numper,Numofper,Fechaper,Obper,Tipoper,Lugaper,Estaper,Munper,Obrper,Vigenper,Condper,Noautpro,Areares,Areapro,Fechaappro,Proejeper,Natgar,Montgar,Tergar,Cauter,Replegal,Instnot,Obsper,Rfmobservaciones,Tipoasientocan,Ultimoasientoregistrado,Descancelacion,Pdfcancelacion,Justcancelacion,Numoficiocancelacion,Fechaoficiocancelacion")] Permican permican)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permican);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permican);
        }

        // GET: Permicans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Permicans == null)
            {
                return NotFound();
            }

            var permican = await _context.Permicans.FindAsync(id);
            if (permican == null)
            {
                return NotFound();
            }
            return View(permican);
        }

        // POST: Permicans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idper,Numper,Numofper,Fechaper,Obper,Tipoper,Lugaper,Estaper,Munper,Obrper,Vigenper,Condper,Noautpro,Areares,Areapro,Fechaappro,Proejeper,Natgar,Montgar,Tergar,Cauter,Replegal,Instnot,Obsper,Rfmobservaciones,Tipoasientocan,Ultimoasientoregistrado,Descancelacion,Pdfcancelacion,Justcancelacion,Numoficiocancelacion,Fechaoficiocancelacion")] Permican permican)
        {
            if (id != permican.Idper)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permican);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermicanExists(permican.Idper))
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
            return View(permican);
        }

        // GET: Permicans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Permicans == null)
            {
                return NotFound();
            }

            var permican = await _context.Permicans
                .FirstOrDefaultAsync(m => m.Idper == id);
            if (permican == null)
            {
                return NotFound();
            }

            return View(permican);
        }

        // POST: Permicans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Permicans == null)
            {
                return Problem("Entity set 'baseartfContext.Permicans'  is null.");
            }
            var permican = await _context.Permicans.FindAsync(id);
            if (permican != null)
            {
                _context.Permicans.Remove(permican);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermicanExists(int id)
        {
          return (_context.Permicans?.Any(e => e.Idper == id)).GetValueOrDefault();
        }
    }
}
