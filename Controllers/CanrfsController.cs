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
    public class CanrfsController : Controller
    {
        private readonly baseartfContext _context;

        public CanrfsController(baseartfContext context)
        {
            _context = context;
        }

        // GET: Canrfs
        public async Task<IActionResult> Index()
        {
            var baseartfContext = _context.Canrves.Include(c => c.NumacuofsolNavigatorNavigation);
            return View(await baseartfContext.ToListAsync());
        }

        // GET: Canrfs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Canrves == null)
            {
                return NotFound();
            }

            var canrf = await _context.Canrves
                .Include(c => c.NumacuofsolNavigatorNavigation)
                .FirstOrDefaultAsync(m => m.Idcan == id);
            if (canrf == null)
            {
                return NotFound();
            }

            return View(canrf);
        }

        // GET: Canrfs/Create
        public IActionResult Create()
        {
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol");
            return View();
        }

        // POST: Canrfs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcan,NumacuofsolNavigator,Fechaofcan,Juscan,Obscan,NameFichaDoc,Fichacan,Homoclavecan,Fechacan")] Canrf canrf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(canrf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", canrf.NumacuofsolNavigator);
            return View(canrf);
        }

        // GET: Canrfs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Canrves == null)
            {
                return NotFound();
            }

            var canrf = await _context.Canrves.FindAsync(id);
            if (canrf == null)
            {
                return NotFound();
            }
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", canrf.NumacuofsolNavigator);
            return View(canrf);
        }

        // POST: Canrfs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcan,NumacuofsolNavigator,Fechaofcan,Juscan,Obscan,NameFichaDoc,Fichacan,Homoclavecan,Fechacan")] Canrf canrf)
        {
            if (id != canrf.Idcan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(canrf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CanrfExists(canrf.Idcan))
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
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", canrf.NumacuofsolNavigator);
            return View(canrf);
        }

        // GET: Canrfs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Canrves == null)
            {
                return NotFound();
            }

            var canrf = await _context.Canrves
                .Include(c => c.NumacuofsolNavigatorNavigation)
                .FirstOrDefaultAsync(m => m.Idcan == id);
            if (canrf == null)
            {
                return NotFound();
            }

            return View(canrf);
        }

        // POST: Canrfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Canrves == null)
            {
                return Problem("Entity set 'baseartfContext.Canrves'  is null.");
            }
            var canrf = await _context.Canrves.FindAsync(id);
            if (canrf != null)
            {
                _context.Canrves.Remove(canrf);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CanrfExists(int id)
        {
          return (_context.Canrves?.Any(e => e.Idcan == id)).GetValueOrDefault();
        }
    }
}
