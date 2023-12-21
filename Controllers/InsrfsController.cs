using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ARTF2.Models;
using ARTF2.Helpers.Constancias;

namespace ARTF2.Controllers
{
    public class InsrfsController : Controller
    {
        private readonly baseartfContext _context;

        public InsrfsController(baseartfContext context)
        {
            _context = context;
        }

        // GET: Insrfs
        public async Task<IActionResult> Index()
        {
            var baseartfContext = _context.Insrves.Include(i => i.NumacuofsolNavigatorNavigation);
            return View(await baseartfContext.ToListAsync());
        }

        // GET: Insrfs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Insrves == null)
            {
                return NotFound();
            }

            var insrf = await _context.Insrves
                .Include(i => i.NumacuofsolNavigatorNavigation)
                .FirstOrDefaultAsync(m => m.Idins == id);
            if (insrf == null)
            {
                return NotFound();
            }

            return View(insrf);
        }

        // GET: Insrfs/Create
        public IActionResult Create()
        {
            //ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol");
            //return View();

            // Supongamos que deseas filtrar Solrves donde alguna propiedad cumple con cierta condición
            var filteredSolrves = _context.Solrves
                .Where(solrve => _context.Equiunis.Any(ot => ot.NumacuofsolNavigator == solrve.Numacuofsol))
                .ToList();

            ViewData["NumacuofsolNavigator"] = new SelectList(filteredSolrves, "Numacuofsol", "Numacuofsol");
            return View();
        }

        // POST: Insrfs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idins,NumacuofsolNavigator,Obsins,Fecapins,Homoclaveins")] Insrf insrf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insrf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", insrf.NumacuofsolNavigator);
            return View(insrf);
        }

        // GET: Insrfs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Insrves == null)
            {
                return NotFound();
            }

            var insrf = await _context.Insrves.FindAsync(id);
            if (insrf == null)
            {
                return NotFound();
            }
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", insrf.NumacuofsolNavigator);
            return View(insrf);
        }

        // POST: Insrfs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idins,NumacuofsolNavigator,Obsins,Fecapins,Homoclaveins")] Insrf insrf)
        {
            if (id != insrf.Idins)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insrf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsrfExists(insrf.Idins))
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
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", insrf.NumacuofsolNavigator);
            return View(insrf);
        }

        // GET: Insrfs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Insrves == null)
            {
                return NotFound();
            }

            var insrf = await _context.Insrves
                .Include(i => i.NumacuofsolNavigatorNavigation)
                .FirstOrDefaultAsync(m => m.Idins == id);
            if (insrf == null)
            {
                return NotFound();
            }

            return View(insrf);
        }

        // POST: Insrfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Insrves == null)
            {
                return Problem("Entity set 'baseartfContext.Insrves'  is null.");
            }
            var insrf = await _context.Insrves.FindAsync(id);
            if (insrf != null)
            {
                _context.Insrves.Remove(insrf);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsrfExists(int id)
        {
          return (_context.Insrves?.Any(e => e.Idins == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> GenerateConsistency(string Id)
        {
            if (Id == null || _context.Equiunis == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equiunis
                .Include(i => i.NumacuofsolNavigatorNavigation)
                .Include(i => i.CombuequiIdNavigationNavigation)
                .Include(i => i.ModaequiIdNavigationNavigation)
                .Include(i => i.MonrentIdNavigationNavigation)
                .Include(i => i.RegiequiIdNavigationNavigation)
                .Include(i => i.TipequiIdNavigationNavigation)
                .Include(i => i.UsoequiIdNavigationNavigation)
                .Include(i => i.Marca)
                .Include(i => i.Empresa)
                .Include(i => i.Fabricante)
                .Include(i => i.ModaEqui)
                .FirstOrDefaultAsync(m => m.NumacuofsolNavigatorNavigation.Numacuofsol == Id);


            ConstanciaInscripcion constanciaInscripcion = new ConstanciaInscripcion();
            var result = constanciaInscripcion.Generar(equipo);

            // Verificar si el resultado es de tipo FileContentResult o FileStreamResult
            if (result is FileContentResult fileContentResult)
            {
                // Puedes realizar acciones adicionales si es necesario
            }
            else if (result is FileStreamResult fileStreamResult)
            {
                // Puedes realizar acciones adicionales si es necesario
            }
            return result;

        }
    }
}
