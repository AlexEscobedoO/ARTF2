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
    public class SolrfDocsController : Controller
    {
        private readonly baseartfContext _context;

        public SolrfDocsController(baseartfContext context)
        {
            _context = context;
        }

        // GET: SolrfDocs
        public async Task<IActionResult> Index()
        {
            var baseartfContext = _context.SolrfDocs.Include(s => s.NumacuofsolNavigatorNavigation);
            return View(await baseartfContext.ToListAsync());
        }

        // GET: SolrfDocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SolrfDocs == null)
            {
                return NotFound();
            }

            var solrfDoc = await _context.SolrfDocs
                .Include(s => s.NumacuofsolNavigatorNavigation)
                .FirstOrDefaultAsync(m => m.Iddoc == id);
            if (solrfDoc == null)
            {
                return NotFound();
            }

            return View(solrfDoc);
        }

        // GET: SolrfDocs/Create
        public IActionResult Create()
        {
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol");
            return View();
        }

        // POST: SolrfDocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddoc,NumacuofsolNavigator,NameDoc,Docsol")] SolrfDoc solrfDoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solrfDoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", solrfDoc.NumacuofsolNavigator);
            return View(solrfDoc);
        }

        // GET: SolrfDocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SolrfDocs == null)
            {
                return NotFound();
            }

            var solrfDoc = await _context.SolrfDocs.FindAsync(id);
            if (solrfDoc == null)
            {
                return NotFound();
            }
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", solrfDoc.NumacuofsolNavigator);
            return View(solrfDoc);
        }

        // POST: SolrfDocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iddoc,NumacuofsolNavigator,NameDoc,Docsol")] SolrfDoc solrfDoc)
        {
            if (id != solrfDoc.Iddoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solrfDoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolrfDocExists(solrfDoc.Iddoc))
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
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", solrfDoc.NumacuofsolNavigator);
            return View(solrfDoc);
        }

        // GET: SolrfDocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SolrfDocs == null)
            {
                return NotFound();
            }

            var solrfDoc = await _context.SolrfDocs
                .Include(s => s.NumacuofsolNavigatorNavigation)
                .FirstOrDefaultAsync(m => m.Iddoc == id);
            if (solrfDoc == null)
            {
                return NotFound();
            }

            return View(solrfDoc);
        }

        // POST: SolrfDocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SolrfDocs == null)
            {
                return Problem("Entity set 'baseartfContext.SolrfDocs'  is null.");
            }
            var solrfDoc = await _context.SolrfDocs.FindAsync(id);
            if (solrfDoc != null)
            {
                _context.SolrfDocs.Remove(solrfDoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolrfDocExists(int id)
        {
          return (_context.SolrfDocs?.Any(e => e.Iddoc == id)).GetValueOrDefault();
        }
    }
}
