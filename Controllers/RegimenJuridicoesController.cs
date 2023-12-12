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
    public class RegimenJuridicoesController : Controller
    {
        private readonly baseartfContext _context;

        public RegimenJuridicoesController(baseartfContext context)
        {
            _context = context;
        }

        // GET: RegimenJuridicoes
        public async Task<IActionResult> Index()
        {
              return _context.RegimenJuridicos != null ? 
                          View(await _context.RegimenJuridicos.ToListAsync()) :
                          Problem("Entity set 'baseartfContext.RegimenJuridicos'  is null.");
        }

        // GET: RegimenJuridicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegimenJuridicos == null)
            {
                return NotFound();
            }

            var regimenJuridico = await _context.RegimenJuridicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regimenJuridico == null)
            {
                return NotFound();
            }

            return View(regimenJuridico);
        }

        // GET: RegimenJuridicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegimenJuridicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Regimen")] RegimenJuridico regimenJuridico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regimenJuridico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regimenJuridico);
        }

        // GET: RegimenJuridicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegimenJuridicos == null)
            {
                return NotFound();
            }

            var regimenJuridico = await _context.RegimenJuridicos.FindAsync(id);
            if (regimenJuridico == null)
            {
                return NotFound();
            }
            return View(regimenJuridico);
        }

        // POST: RegimenJuridicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Regimen")] RegimenJuridico regimenJuridico)
        {
            if (id != regimenJuridico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regimenJuridico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegimenJuridicoExists(regimenJuridico.Id))
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
            return View(regimenJuridico);
        }

        // GET: RegimenJuridicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegimenJuridicos == null)
            {
                return NotFound();
            }

            var regimenJuridico = await _context.RegimenJuridicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regimenJuridico == null)
            {
                return NotFound();
            }

            return View(regimenJuridico);
        }

        // POST: RegimenJuridicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegimenJuridicos == null)
            {
                return Problem("Entity set 'baseartfContext.RegimenJuridicos'  is null.");
            }
            var regimenJuridico = await _context.RegimenJuridicos.FindAsync(id);
            if (regimenJuridico != null)
            {
                _context.RegimenJuridicos.Remove(regimenJuridico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegimenJuridicoExists(int id)
        {
          return (_context.RegimenJuridicos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
