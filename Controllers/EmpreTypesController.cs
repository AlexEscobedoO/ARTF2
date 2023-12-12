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
    public class EmpreTypesController : Controller
    {
        private readonly baseartfContext _context;

        public EmpreTypesController(baseartfContext context)
        {
            _context = context;
        }

        // GET: EmpreTypes
        public async Task<IActionResult> Index()
        {
              return _context.EmpreTypes != null ? 
                          View(await _context.EmpreTypes.ToListAsync()) :
                          Problem("Entity set 'baseartfContext.EmpreTypes'  is null.");
        }

        // GET: EmpreTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmpreTypes == null)
            {
                return NotFound();
            }

            var empreType = await _context.EmpreTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empreType == null)
            {
                return NotFound();
            }

            return View(empreType);
        }

        // GET: EmpreTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpreTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] EmpreType empreType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empreType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empreType);
        }

        // GET: EmpreTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmpreTypes == null)
            {
                return NotFound();
            }

            var empreType = await _context.EmpreTypes.FindAsync(id);
            if (empreType == null)
            {
                return NotFound();
            }
            return View(empreType);
        }

        // POST: EmpreTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] EmpreType empreType)
        {
            if (id != empreType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empreType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpreTypeExists(empreType.Id))
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
            return View(empreType);
        }

        // GET: EmpreTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmpreTypes == null)
            {
                return NotFound();
            }

            var empreType = await _context.EmpreTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empreType == null)
            {
                return NotFound();
            }

            return View(empreType);
        }

        // POST: EmpreTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmpreTypes == null)
            {
                return Problem("Entity set 'baseartfContext.EmpreTypes'  is null.");
            }
            var empreType = await _context.EmpreTypes.FindAsync(id);
            if (empreType != null)
            {
                _context.EmpreTypes.Remove(empreType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpreTypeExists(int id)
        {
          return (_context.EmpreTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
