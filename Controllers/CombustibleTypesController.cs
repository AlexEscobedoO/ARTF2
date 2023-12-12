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
    public class CombustibleTypesController : Controller
    {
        private readonly baseartfContext _context;

        public CombustibleTypesController(baseartfContext context)
        {
            _context = context;
        }

        // GET: CombustibleTypes
        public async Task<IActionResult> Index()
        {
              return _context.CombustibleTypes != null ? 
                          View(await _context.CombustibleTypes.ToListAsync()) :
                          Problem("Entity set 'baseartfContext.CombustibleTypes'  is null.");
        }

        // GET: CombustibleTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CombustibleTypes == null)
            {
                return NotFound();
            }

            var combustibleType = await _context.CombustibleTypes
                .FirstOrDefaultAsync(m => m.Idcomb == id);
            if (combustibleType == null)
            {
                return NotFound();
            }

            return View(combustibleType);
        }

        // GET: CombustibleTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CombustibleTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcomb,Description")] CombustibleType combustibleType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(combustibleType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(combustibleType);
        }

        // GET: CombustibleTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CombustibleTypes == null)
            {
                return NotFound();
            }

            var combustibleType = await _context.CombustibleTypes.FindAsync(id);
            if (combustibleType == null)
            {
                return NotFound();
            }
            return View(combustibleType);
        }

        // POST: CombustibleTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcomb,Description")] CombustibleType combustibleType)
        {
            if (id != combustibleType.Idcomb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(combustibleType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CombustibleTypeExists(combustibleType.Idcomb))
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
            return View(combustibleType);
        }

        // GET: CombustibleTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CombustibleTypes == null)
            {
                return NotFound();
            }

            var combustibleType = await _context.CombustibleTypes
                .FirstOrDefaultAsync(m => m.Idcomb == id);
            if (combustibleType == null)
            {
                return NotFound();
            }

            return View(combustibleType);
        }

        // POST: CombustibleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CombustibleTypes == null)
            {
                return Problem("Entity set 'baseartfContext.CombustibleTypes'  is null.");
            }
            var combustibleType = await _context.CombustibleTypes.FindAsync(id);
            if (combustibleType != null)
            {
                _context.CombustibleTypes.Remove(combustibleType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CombustibleTypeExists(int id)
        {
          return (_context.CombustibleTypes?.Any(e => e.Idcomb == id)).GetValueOrDefault();
        }
    }
}
