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
    public class EmpresasController : Controller
    {
        private readonly baseartfContext _context;

        public EmpresasController(baseartfContext context)
        {
            _context = context;
        }

        // GET: Empresas
        public async Task<IActionResult> Index()
        {
            var baseartfContext = _context.Empresas.Include(e => e.TipoempreIdNavigationNavigation);
            return View(await baseartfContext.ToListAsync());
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empresas == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .Include(e => e.TipoempreIdNavigationNavigation)
                .FirstOrDefaultAsync(m => m.Idempre == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresas/Create
        public IActionResult Create()
        {
            ViewData["TipoempreIdNavigation"] = new SelectList(_context.EmpreTypes, "Id", "Id");
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idempre,Rsempre,Dirempre,TipoempreIdNavigation")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoempreIdNavigation"] = new SelectList(_context.EmpreTypes, "Id", "Id", empresa.TipoempreIdNavigation);
            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empresas == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            ViewData["TipoempreIdNavigation"] = new SelectList(_context.EmpreTypes, "Id", "Id", empresa.TipoempreIdNavigation);
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idempre,Rsempre,Dirempre,TipoempreIdNavigation")] Empresa empresa)
        {
            if (id != empresa.Idempre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.Idempre))
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
            ViewData["TipoempreIdNavigation"] = new SelectList(_context.EmpreTypes, "Id", "Id", empresa.TipoempreIdNavigation);
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empresas == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .Include(e => e.TipoempreIdNavigationNavigation)
                .FirstOrDefaultAsync(m => m.Idempre == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empresas == null)
            {
                return Problem("Entity set 'baseartfContext.Empresas'  is null.");
            }
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(int id)
        {
          return (_context.Empresas?.Any(e => e.Idempre == id)).GetValueOrDefault();
        }
    }
}
