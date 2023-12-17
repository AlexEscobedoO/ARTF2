using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ARTF2.Models;
using artf_MVC.Helper.Constancias;

namespace ARTF2.Controllers
{
    public class ModrfsController : Controller
    {
        private readonly baseartfContext _context;

        public ModrfsController(baseartfContext context)
        {
            _context = context;
        }

        // GET: Modrfs
        public async Task<IActionResult> Index()
        {
            var baseartfContext = _context.Modrves.Include(m => m.NumacuofsolNavigatorNavigation);
            return View(await baseartfContext.ToListAsync());
        }

        // GET: Modrfs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modrves == null)
            {
                return NotFound();
            }

            var modrf = await _context.Modrves
                .Include(m => m.NumacuofsolNavigatorNavigation)
                .FirstOrDefaultAsync(m => m.Idmod == id);
            if (modrf == null)
            {
                return NotFound();
            }

            return View(modrf);
        }

        // GET: Modrfs/Create
        public IActionResult Create()
        {
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol");
            return View();
        }

        // POST: Modrfs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmod,NumacuofsolNavigator,NameAcuDoc,Acumod,Fechamod,Desmod,Obsmod,NameFichaTecDoc,Fichatecmod,Clavemod")] Modrf modrf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modrf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", modrf.NumacuofsolNavigator);
            return View(modrf);
        }

        // GET: Modrfs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Modrves == null)
            {
                return NotFound();
            }

            var modrf = await _context.Modrves.FindAsync(id);
            if (modrf == null)
            {
                return NotFound();
            }
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", modrf.NumacuofsolNavigator);
            return View(modrf);
        }

        // POST: Modrfs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmod,NumacuofsolNavigator,NameAcuDoc,Acumod,Fechamod,Desmod,Obsmod,NameFichaTecDoc,Fichatecmod,Clavemod")] Modrf modrf)
        {
            if (id != modrf.Idmod)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modrf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModrfExists(modrf.Idmod))
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
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", modrf.NumacuofsolNavigator);
            return View(modrf);
        }

        // GET: Modrfs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Modrves == null)
            {
                return NotFound();
            }

            var modrf = await _context.Modrves
                .Include(m => m.NumacuofsolNavigatorNavigation)
                .FirstOrDefaultAsync(m => m.Idmod == id);
            if (modrf == null)
            {
                return NotFound();
            }

            return View(modrf);
        }

        // POST: Modrfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modrves == null)
            {
                return Problem("Entity set 'baseartfContext.Modrves'  is null.");
            }
            var modrf = await _context.Modrves.FindAsync(id);
            if (modrf != null)
            {
                _context.Modrves.Remove(modrf);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModrfExists(int id)
        {
          return (_context.Modrves?.Any(e => e.Idmod == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> GenerateConsistency(string Id)
        {
            if (Id == null || _context.Equiunis == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equiunis
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
                .Include(i => i.NumacuofsolNavigatorNavigation)
                .ThenInclude(i => i.Modrves)

                .FirstOrDefaultAsync(m => m.NumacuofsolNavigatorNavigation.Numacuofsol == Id);


            CostanciaCancelacion constanciaInscripcion = new CostanciaCancelacion();
            var result = constanciaInscripcion.Generar(equipo, "MODIFICACIÓN");

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
