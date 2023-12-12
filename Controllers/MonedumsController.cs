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
    public class MonedumsController : Controller
    {
        private readonly baseartfContext _context;

        public MonedumsController(baseartfContext context)
        {
            _context = context;
        }

        // GET: Monedums
        public async Task<IActionResult> Index()
        {
              return _context.Moneda != null ? 
                          View(await _context.Moneda.ToListAsync()) :
                          Problem("Entity set 'baseartfContext.Moneda'  is null.");
        }

        // GET: Monedums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Moneda == null)
            {
                return NotFound();
            }

            var monedum = await _context.Moneda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monedum == null)
            {
                return NotFound();
            }

            return View(monedum);
        }

        // GET: Monedums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monedums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipomoneda")] Monedum monedum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monedum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monedum);
        }

        // GET: Monedums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Moneda == null)
            {
                return NotFound();
            }

            var monedum = await _context.Moneda.FindAsync(id);
            if (monedum == null)
            {
                return NotFound();
            }
            return View(monedum);
        }

        // POST: Monedums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipomoneda")] Monedum monedum)
        {
            if (id != monedum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monedum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonedumExists(monedum.Id))
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
            return View(monedum);
        }

        // GET: Monedums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Moneda == null)
            {
                return NotFound();
            }

            var monedum = await _context.Moneda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monedum == null)
            {
                return NotFound();
            }

            return View(monedum);
        }

        // POST: Monedums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Moneda == null)
            {
                return Problem("Entity set 'baseartfContext.Moneda'  is null.");
            }
            var monedum = await _context.Moneda.FindAsync(id);
            if (monedum != null)
            {
                _context.Moneda.Remove(monedum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonedumExists(int id)
        {
          return (_context.Moneda?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
