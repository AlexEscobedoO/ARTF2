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
    public class RectrfsController : Controller
    {
        private readonly baseartfContext _context;

        public RectrfsController(baseartfContext context)
        {
            _context = context;
        }

        // GET: Rectrfs
        public async Task<IActionResult> Index()
        {
            var baseartfContext = _context.Rectrves.Include(r => r.NumacuofsolNavigatorNavigation);
            return View(await baseartfContext.ToListAsync());
        }

        // GET: Rectrfs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rectrves == null)
            {
                return NotFound();
            }

            var rectrf = await _context.Rectrves
                .Include(r => r.NumacuofsolNavigatorNavigation)
                .FirstOrDefaultAsync(m => m.Idrect == id);
            if (rectrf == null)
            {
                return NotFound();
            }

            return View(rectrf);
        }

        // GET: Rectrfs/Create
        public IActionResult Create()
        {
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol");
            return View();
        }

        // POST: Rectrfs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idrect,NumacuofsolNavigator,NameFichatecDoc,Fichatecrect,Numdocemp,Fechadocsol,Fecharect,Desrect,Obsrect,NameAcuDoc,Acurect,Homoclaverect,Fechamodrect")] Rectrf rectrf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rectrf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", rectrf.NumacuofsolNavigator);
            return View(rectrf);
        }

        // GET: Rectrfs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rectrves == null)
            {
                return NotFound();
            }

            var rectrf = await _context.Rectrves.FindAsync(id);
            if (rectrf == null)
            {
                return NotFound();
            }
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", rectrf.NumacuofsolNavigator);
            return View(rectrf);
        }

        // POST: Rectrfs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idrect,NumacuofsolNavigator,NameFichatecDoc,Fichatecrect,Numdocemp,Fechadocsol,Fecharect,Desrect,Obsrect,NameAcuDoc,Acurect,Homoclaverect,Fechamodrect")] Rectrf rectrf)
        {
            if (id != rectrf.Idrect)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rectrf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RectrfExists(rectrf.Idrect))
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
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", rectrf.NumacuofsolNavigator);
            return View(rectrf);
        }

        // GET: Rectrfs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rectrves == null)
            {
                return NotFound();
            }

            var rectrf = await _context.Rectrves
                .Include(r => r.NumacuofsolNavigatorNavigation)
                .FirstOrDefaultAsync(m => m.Idrect == id);
            if (rectrf == null)
            {
                return NotFound();
            }

            return View(rectrf);
        }

        // POST: Rectrfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rectrves == null)
            {
                return Problem("Entity set 'baseartfContext.Rectrves'  is null.");
            }
            var rectrf = await _context.Rectrves.FindAsync(id);
            if (rectrf != null)
            {
                _context.Rectrves.Remove(rectrf);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RectrfExists(int id)
        {
          return (_context.Rectrves?.Any(e => e.Idrect == id)).GetValueOrDefault();
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
                .ThenInclude(i => i.Rectrves)

                .FirstOrDefaultAsync(m => m.NumacuofsolNavigatorNavigation.Numacuofsol == Id);


            CostanciaCancelacion constanciaInscripcion = new CostanciaCancelacion();
            var result = constanciaInscripcion.Generar(equipo, "RECTIFICACIÓN");

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
