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
    public class EquipoTypesController : Controller
    {
        private readonly baseartfContext _context;

        public EquipoTypesController(baseartfContext context)
        {
            _context = context;
        }

        // GET: EquipoTypes
        public async Task<IActionResult> Index()
        {
              return _context.EquipoTypes != null ? 
                          View(await _context.EquipoTypes.ToListAsync()) :
                          Problem("Entity set 'baseartfContext.EquipoTypes'  is null.");
        }

        // GET: EquipoTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EquipoTypes == null)
            {
                return NotFound();
            }

            var equipoType = await _context.EquipoTypes
                .FirstOrDefaultAsync(m => m.IdEqui == id);
            if (equipoType == null)
            {
                return NotFound();
            }

            return View(equipoType);
        }

        // GET: EquipoTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EquipoTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEqui,Description")] EquipoType equipoType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipoType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipoType);
        }

        // GET: EquipoTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EquipoTypes == null)
            {
                return NotFound();
            }

            var equipoType = await _context.EquipoTypes.FindAsync(id);
            if (equipoType == null)
            {
                return NotFound();
            }
            return View(equipoType);
        }

        // POST: EquipoTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEqui,Description")] EquipoType equipoType)
        {
            if (id != equipoType.IdEqui)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipoType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoTypeExists(equipoType.IdEqui))
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
            return View(equipoType);
        }

        // GET: EquipoTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EquipoTypes == null)
            {
                return NotFound();
            }

            var equipoType = await _context.EquipoTypes
                .FirstOrDefaultAsync(m => m.IdEqui == id);
            if (equipoType == null)
            {
                return NotFound();
            }

            return View(equipoType);
        }

        // POST: EquipoTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EquipoTypes == null)
            {
                return Problem("Entity set 'baseartfContext.EquipoTypes'  is null.");
            }
            var equipoType = await _context.EquipoTypes.FindAsync(id);
            if (equipoType != null)
            {
                _context.EquipoTypes.Remove(equipoType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoTypeExists(int id)
        {
          return (_context.EquipoTypes?.Any(e => e.IdEqui == id)).GetValueOrDefault();
        }
    }
}
