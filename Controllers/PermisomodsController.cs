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
    public class PermisomodsController : Controller
    {
        private readonly baseartfContext _context;

        public PermisomodsController(baseartfContext context)
        {
            _context = context;
        }

        // GET: Permisomods
        public async Task<IActionResult> Index()
        {
              return _context.Permisomods != null ? 
                          View(await _context.Permisomods.ToListAsync()) :
                          Problem("Entity set 'baseartfContext.Permisomods'  is null.");
        }

        // GET: Permisomods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Permisomods == null)
            {
                return NotFound();
            }

            var permisomod = await _context.Permisomods
                .FirstOrDefaultAsync(m => m.Idpermod == id);
            if (permisomod == null)
            {
                return NotFound();
            }

            return View(permisomod);
        }

        // GET: Permisomods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Permisomods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idpermod,Numper,Numofper,Fechaper,Obper,Tipoper,Lugaper,Estaper,Munper,Obrper,Vigenper,Condper,Noautpro,Areares,Areapro,Fechaappro,Proejeper,Natgar,Montgar,Tergar,Cauter,Replegal,Instnot,Obsper,Rfmobs,Tipoasientomod,Nummod,Desmod,Pdfmod,Consmod,Numofimod,Fechaofimod,Idempresa,Domicilio,Homoins,Fechainsc")] Permisomod permisomod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permisomod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permisomod);
        }

        // GET: Permisomods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Permisomods == null)
            {
                return NotFound();
            }

            var permisomod = await _context.Permisomods.FindAsync(id);
            if (permisomod == null)
            {
                return NotFound();
            }
            return View(permisomod);
        }

        // POST: Permisomods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idpermod,Numper,Numofper,Fechaper,Obper,Tipoper,Lugaper,Estaper,Munper,Obrper,Vigenper,Condper,Noautpro,Areares,Areapro,Fechaappro,Proejeper,Natgar,Montgar,Tergar,Cauter,Replegal,Instnot,Obsper,Rfmobs,Tipoasientomod,Nummod,Desmod,Pdfmod,Consmod,Numofimod,Fechaofimod,Idempresa,Domicilio,Homoins,Fechainsc")] Permisomod permisomod)
        {
            if (id != permisomod.Idpermod)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permisomod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermisomodExists(permisomod.Idpermod))
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
            return View(permisomod);
        }

        // GET: Permisomods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Permisomods == null)
            {
                return NotFound();
            }

            var permisomod = await _context.Permisomods
                .FirstOrDefaultAsync(m => m.Idpermod == id);
            if (permisomod == null)
            {
                return NotFound();
            }

            return View(permisomod);
        }

        // POST: Permisomods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Permisomods == null)
            {
                return Problem("Entity set 'baseartfContext.Permisomods'  is null.");
            }
            var permisomod = await _context.Permisomods.FindAsync(id);
            if (permisomod != null)
            {
                _context.Permisomods.Remove(permisomod);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermisomodExists(int id)
        {
          return (_context.Permisomods?.Any(e => e.Idpermod == id)).GetValueOrDefault();
        }
    }
}
