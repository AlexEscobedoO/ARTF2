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
    public class PermrectsController : Controller
    {
        private readonly baseartfContext _context;

        public PermrectsController(baseartfContext context)
        {
            _context = context;
        }

        // GET: Permrects
        public async Task<IActionResult> Index()
        {
              return _context.Permrects != null ? 
                          View(await _context.Permrects.ToListAsync()) :
                          Problem("Entity set 'baseartfContext.Permrects'  is null.");
        }

        // GET: Permrects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Permrects == null)
            {
                return NotFound();
            }

            var permrect = await _context.Permrects
                .FirstOrDefaultAsync(m => m.Idpermrect == id);
            if (permrect == null)
            {
                return NotFound();
            }

            return View(permrect);
        }

        // GET: Permrects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Permrects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idpermrect,Numper,Numofper,Fechaper,Obper,Tipoper,Lugaper,Estaper,Munper,Obrper,Vigenper,Condper,Noautpro,Areares,Areapro,Fechaappro,Proejeper,Natgar,Montgar,Tergar,Cauter,Replegal,Instnot,Obsper,RfmObservaciones,TipoAsientoRect,NumeroRectificacion,DescripcionRectificacion,PdfRectificacion,ConsideracionesRectificacion,NumeroOficioRectificacion,FechaOficioRectificacion,FechaInscripcion")] Permrect permrect)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permrect);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permrect);
        }

        // GET: Permrects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Permrects == null)
            {
                return NotFound();
            }

            var permrect = await _context.Permrects.FindAsync(id);
            if (permrect == null)
            {
                return NotFound();
            }
            return View(permrect);
        }

        // POST: Permrects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idpermrect,Numper,Numofper,Fechaper,Obper,Tipoper,Lugaper,Estaper,Munper,Obrper,Vigenper,Condper,Noautpro,Areares,Areapro,Fechaappro,Proejeper,Natgar,Montgar,Tergar,Cauter,Replegal,Instnot,Obsper,RfmObservaciones,TipoAsientoRect,NumeroRectificacion,DescripcionRectificacion,PdfRectificacion,ConsideracionesRectificacion,NumeroOficioRectificacion,FechaOficioRectificacion,FechaInscripcion")] Permrect permrect)
        {
            if (id != permrect.Idpermrect)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permrect);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermrectExists(permrect.Idpermrect))
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
            return View(permrect);
        }

        // GET: Permrects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Permrects == null)
            {
                return NotFound();
            }

            var permrect = await _context.Permrects
                .FirstOrDefaultAsync(m => m.Idpermrect == id);
            if (permrect == null)
            {
                return NotFound();
            }

            return View(permrect);
        }

        // POST: Permrects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Permrects == null)
            {
                return Problem("Entity set 'baseartfContext.Permrects'  is null.");
            }
            var permrect = await _context.Permrects.FindAsync(id);
            if (permrect != null)
            {
                _context.Permrects.Remove(permrect);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermrectExists(int id)
        {
          return (_context.Permrects?.Any(e => e.Idpermrect == id)).GetValueOrDefault();
        }
    }
}
