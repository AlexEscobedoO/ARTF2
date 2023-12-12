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
    public class EquiunisController : Controller
    {
        private readonly baseartfContext _context;

        public EquiunisController(baseartfContext context)
        {
            _context = context;
        }

        // GET: Equiunis
        public async Task<IActionResult> Index()
        {
            var baseartfContext = _context.Equiunis.Include(e => e.CombuequiIdNavigationNavigation).Include(e => e.ModaequiIdNavigationNavigation).Include(e => e.MonrentIdNavigationNavigation).Include(e => e.NumacuofsolNavigatorNavigation).Include(e => e.RegiequiIdNavigationNavigation).Include(e => e.TipequiIdNavigationNavigation).Include(e => e.UsoequiIdNavigationNavigation);
            return View(await baseartfContext.ToListAsync());
        }

        // GET: Equiunis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equiunis == null)
            {
                return NotFound();
            }

            var equiuni = await _context.Equiunis
                .Include(e => e.CombuequiIdNavigationNavigation)
                .Include(e => e.ModaequiIdNavigationNavigation)
                .Include(e => e.MonrentIdNavigationNavigation)
                .Include(e => e.NumacuofsolNavigatorNavigation)
                .Include(e => e.RegiequiIdNavigationNavigation)
                .Include(e => e.TipequiIdNavigationNavigation)
                .Include(e => e.UsoequiIdNavigationNavigation)
                .FirstOrDefaultAsync(m => m.Idequi == id);
            if (equiuni == null)
            {
                return NotFound();
            }

            return View(equiuni);
        }

        // GET: Equiunis/Create
        public IActionResult Create()
        {
            ViewData["CombuequiIdNavigation"] = new SelectList(_context.CombustibleTypes, "Idcomb", "Idcomb");
            ViewData["ModaequiIdNavigation"] = new SelectList(_context.Modelos, "Idmod", "Idmod");
            ViewData["MonrentIdNavigation"] = new SelectList(_context.Moneda, "Id", "Id");
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol");
            ViewData["RegiequiIdNavigation"] = new SelectList(_context.RegimenJuridicos, "Id", "Id");
            ViewData["TipequiIdNavigation"] = new SelectList(_context.EquipoTypes, "IdEqui", "IdEqui");
            ViewData["UsoequiIdNavigation"] = new SelectList(_context.Usoequis, "Id", "Id");
            return View();
        }

        // POST: Equiunis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idequi,NumacuofsolNavigator,ModaequiIdNavigation,TipequiIdNavigation,CombuequiIdNavigation,Nserie,Matricula,RegiequiIdNavigation,Graequi,UsoequiIdNavigation,Fcons,Nofact,Tcontra,Fcontra,Vcontra,Mrent,MonrentIdNavigation,Obsarre,Obsgra,Obsequi,NameFichaDoc,Fichaequi,Fecharequi")] Equiuni equiuni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equiuni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CombuequiIdNavigation"] = new SelectList(_context.CombustibleTypes, "Idcomb", "Idcomb", equiuni.CombuequiIdNavigation);
            ViewData["ModaequiIdNavigation"] = new SelectList(_context.Modelos, "Idmod", "Idmod", equiuni.ModaequiIdNavigation);
            ViewData["MonrentIdNavigation"] = new SelectList(_context.Moneda, "Id", "Id", equiuni.MonrentIdNavigation);
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", equiuni.NumacuofsolNavigator);
            ViewData["RegiequiIdNavigation"] = new SelectList(_context.RegimenJuridicos, "Id", "Id", equiuni.RegiequiIdNavigation);
            ViewData["TipequiIdNavigation"] = new SelectList(_context.EquipoTypes, "IdEqui", "IdEqui", equiuni.TipequiIdNavigation);
            ViewData["UsoequiIdNavigation"] = new SelectList(_context.Usoequis, "Id", "Id", equiuni.UsoequiIdNavigation);
            return View(equiuni);
        }

        // GET: Equiunis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Equiunis == null)
            {
                return NotFound();
            }

            var equiuni = await _context.Equiunis.FindAsync(id);
            if (equiuni == null)
            {
                return NotFound();
            }
            ViewData["CombuequiIdNavigation"] = new SelectList(_context.CombustibleTypes, "Idcomb", "Idcomb", equiuni.CombuequiIdNavigation);
            ViewData["ModaequiIdNavigation"] = new SelectList(_context.Modelos, "Idmod", "Idmod", equiuni.ModaequiIdNavigation);
            ViewData["MonrentIdNavigation"] = new SelectList(_context.Moneda, "Id", "Id", equiuni.MonrentIdNavigation);
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", equiuni.NumacuofsolNavigator);
            ViewData["RegiequiIdNavigation"] = new SelectList(_context.RegimenJuridicos, "Id", "Id", equiuni.RegiequiIdNavigation);
            ViewData["TipequiIdNavigation"] = new SelectList(_context.EquipoTypes, "IdEqui", "IdEqui", equiuni.TipequiIdNavigation);
            ViewData["UsoequiIdNavigation"] = new SelectList(_context.Usoequis, "Id", "Id", equiuni.UsoequiIdNavigation);
            return View(equiuni);
        }

        // POST: Equiunis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idequi,NumacuofsolNavigator,ModaequiIdNavigation,TipequiIdNavigation,CombuequiIdNavigation,Nserie,Matricula,RegiequiIdNavigation,Graequi,UsoequiIdNavigation,Fcons,Nofact,Tcontra,Fcontra,Vcontra,Mrent,MonrentIdNavigation,Obsarre,Obsgra,Obsequi,NameFichaDoc,Fichaequi,Fecharequi")] Equiuni equiuni)
        {
            if (id != equiuni.Idequi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equiuni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquiuniExists(equiuni.Idequi))
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
            ViewData["CombuequiIdNavigation"] = new SelectList(_context.CombustibleTypes, "Idcomb", "Idcomb", equiuni.CombuequiIdNavigation);
            ViewData["ModaequiIdNavigation"] = new SelectList(_context.Modelos, "Idmod", "Idmod", equiuni.ModaequiIdNavigation);
            ViewData["MonrentIdNavigation"] = new SelectList(_context.Moneda, "Id", "Id", equiuni.MonrentIdNavigation);
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", equiuni.NumacuofsolNavigator);
            ViewData["RegiequiIdNavigation"] = new SelectList(_context.RegimenJuridicos, "Id", "Id", equiuni.RegiequiIdNavigation);
            ViewData["TipequiIdNavigation"] = new SelectList(_context.EquipoTypes, "IdEqui", "IdEqui", equiuni.TipequiIdNavigation);
            ViewData["UsoequiIdNavigation"] = new SelectList(_context.Usoequis, "Id", "Id", equiuni.UsoequiIdNavigation);
            return View(equiuni);
        }

        // GET: Equiunis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equiunis == null)
            {
                return NotFound();
            }

            var equiuni = await _context.Equiunis
                .Include(e => e.CombuequiIdNavigationNavigation)
                .Include(e => e.ModaequiIdNavigationNavigation)
                .Include(e => e.MonrentIdNavigationNavigation)
                .Include(e => e.NumacuofsolNavigatorNavigation)
                .Include(e => e.RegiequiIdNavigationNavigation)
                .Include(e => e.TipequiIdNavigationNavigation)
                .Include(e => e.UsoequiIdNavigationNavigation)
                .FirstOrDefaultAsync(m => m.Idequi == id);
            if (equiuni == null)
            {
                return NotFound();
            }

            return View(equiuni);
        }

        // POST: Equiunis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equiunis == null)
            {
                return Problem("Entity set 'baseartfContext.Equiunis'  is null.");
            }
            var equiuni = await _context.Equiunis.FindAsync(id);
            if (equiuni != null)
            {
                _context.Equiunis.Remove(equiuni);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquiuniExists(int id)
        {
          return (_context.Equiunis?.Any(e => e.Idequi == id)).GetValueOrDefault();
        }
    }
}
