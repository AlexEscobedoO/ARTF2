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
    public class SolrfsController : Controller
    {
        private readonly baseartfContext _context;

        public SolrfsController(baseartfContext context)
        {
            _context = context;
        }

        // GET: Solrfs
        public async Task<IActionResult> Index()
        {
            var response = _context.Solrves
            .Include(x => x.Insrves)
            .Where(x => x.Insrves.All(i => i.Cancelled != true))
            .ToList();

            return View(response);
        }

        // GET: Solrfs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Solrves == null)
            {
                return NotFound();
            }

            var solrf = await _context.Solrves
                .FirstOrDefaultAsync(m => m.Numacuofsol == id);
            if (solrf == null)
            {
                return NotFound();
            }

            return View(solrf);
        }

        // GET: Solrfs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solrfs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Numacuofsol,Obssol,Fecapsol")] Solrf solrf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solrf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solrf);
        }

        // GET: Solrfs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Solrves == null)
            {
                return NotFound();
            }

            var solrf = await _context.Solrves.FindAsync(id);
            if (solrf == null)
            {
                return NotFound();
            }
            return View(solrf);
        }

        // POST: Solrfs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Numacuofsol,Obssol,Fecapsol")] Solrf solrf)
        {
            if (id != solrf.Numacuofsol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solrf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolrfExists(solrf.Numacuofsol))
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
            return View(solrf);
        }

        // GET: Solrfs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Solrves == null)
            {
                return NotFound();
            }

            var solrf = await _context.Solrves
                .FirstOrDefaultAsync(m => m.Numacuofsol == id);
            if (solrf == null)
            {
                return NotFound();
            }

            return View(solrf);
        }

        // POST: Solrfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Solrves == null)
            {
                return Problem("Entity set 'baseartfContext.Solrves'  is null.");
            }
            var solrf = await _context.Solrves.FindAsync(id);
            if (solrf != null)
            {
                _context.Solrves.Remove(solrf);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolrfExists(string id)
        {
          return (_context.Solrves?.Any(e => e.Numacuofsol == id)).GetValueOrDefault();
        }

        [HttpPost]
        public JsonResult VerificarNumeroAcuerdo(string NoAcuerdo)
        {
            bool existeEnBaseDeDatos = _context.Solrves.Any(m => m.Numacuofsol == NoAcuerdo);
            return Json(new { existe = existeEnBaseDeDatos });
        }
    }
}
