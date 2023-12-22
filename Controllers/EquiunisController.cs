using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ARTF2.Models;
using ARTF2.Helpers.Constancias;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> Index(string id)
        {
          var baseartfContext = _context.Equiunis.Include(e => e.CombuequiIdNavigationNavigation).Include(e => e.ModaequiIdNavigationNavigation).Include(e => e.MonrentIdNavigationNavigation).Include(e => e.NumacuofsolNavigatorNavigation).Include(e => e.RegiequiIdNavigationNavigation).Include(e => e.TipequiIdNavigationNavigation).Include(e => e.UsoequiIdNavigationNavigation).Include(e => e.Empresa).Include(e => e.Fabricante).Include(e => e.Marca).Include(e => e.ModaEqui).Where(e => e.NumacuofsolNavigator == id);
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
                .Include(e => e.Empresa)
                .Include(e => e.Fabricante)
                .Include(e => e.Marca)
                .Include(e => e.ModaEqui)
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
            var filteredSolrves = _context.Solrves
                                    .Include(x => x.Insrves)
                                    .Where(solrve => solrve.Insrves.All(i => i.Cancelled != true))
                                    .ToList();


            ViewData["CombuequiIdNavigation"] = new SelectList(_context.CombustibleTypes, "Idcomb", "Description");
            ViewData["ModaequiIdNavigation"] = new SelectList(_context.Modelos, "Idmod", "Modequi");
            ViewData["MonrentIdNavigation"] = new SelectList(_context.Moneda, "Id", "Tipomoneda");
            ViewData["NumacuofsolNavigator"] = new SelectList(filteredSolrves, "Numacuofsol", "Numacuofsol");
            ViewData["RegiequiIdNavigation"] = new SelectList(_context.RegimenJuridicos, "Id", "Regimen");
            ViewData["TipequiIdNavigation"] = new SelectList(_context.EquipoTypes, "IdEqui", "Description");
            ViewData["UsoequiIdNavigation"] = new SelectList(_context.Usoequis, "Id", "Usoequi1");
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Idempre", "Rsempre");
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "Idfab", "Rsfab");
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "RsMarca");
            ViewData["ModaEquiId"] = new SelectList(_context.ModaEquis, "Id", "Description");
            return View();
        }

        // POST: Equiunis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idequi,NumacuofsolNavigator,ModaequiIdNavigation,TipequiIdNavigation,CombuequiIdNavigation,Nserie,Matricula,RegiequiIdNavigation,Graequi,UsoequiIdNavigation,Fcons,Nofact,Tcontra,Fcontra,Vcontra,Mrent,MonrentIdNavigation,Obsarre,Obsgra,Obsequi,NameFichaDoc,Fichaequi,Fecharequi,ModaEquiId,MarcaId,FabricanteId,EmpresaId")] Equiuni equiuni)
        {
            if (ModelState.IsValid)
            {
                //Equiuni equipo = new Equiuni();
                //equipo = equiuni;
                _context.Add(equiuni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = equiuni.NumacuofsolNavigator });
            }
            ViewData["CombuequiIdNavigation"] = new SelectList(_context.CombustibleTypes, "Idcomb", "Idcomb", equiuni.CombuequiIdNavigation);
            ViewData["ModaequiIdNavigation"] = new SelectList(_context.Modelos, "Idmod", "Idmod", equiuni.ModaequiIdNavigation);
            ViewData["MonrentIdNavigation"] = new SelectList(_context.Moneda, "Id", "Id", equiuni.MonrentIdNavigation);
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", equiuni.NumacuofsolNavigator);
            ViewData["RegiequiIdNavigation"] = new SelectList(_context.RegimenJuridicos, "Id", "Id", equiuni.RegiequiIdNavigation);
            ViewData["TipequiIdNavigation"] = new SelectList(_context.EquipoTypes, "IdEqui", "IdEqui", equiuni.TipequiIdNavigation);
            ViewData["UsoequiIdNavigation"] = new SelectList(_context.Usoequis, "Id", "Id", equiuni.UsoequiIdNavigation);
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Idempre", "Rsempre", equiuni.EmpresaId);
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "Idfab", "Rsfab", equiuni.FabricanteId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "RsMarca", equiuni.MarcaId);
            ViewData["ModaEquiId"] = new SelectList(_context.ModaEquis, "Id", "Description", equiuni.ModaEquiId);
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Idempre", "Rsempre", equiuni.EmpresaId);
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "Idfab", "Rsfab", equiuni.FabricanteId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "RsMarca", equiuni.MarcaId);
            ViewData["ModaEquiId"] = new SelectList(_context.ModaEquis, "Id", "Description", equiuni.ModaEquiId);
            return View(equiuni);
        }

        // POST: Equiunis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idequi,NumacuofsolNavigator,ModaequiIdNavigation,TipequiIdNavigation,CombuequiIdNavigation,Nserie,Matricula,RegiequiIdNavigation,Graequi,UsoequiIdNavigation,Fcons,Nofact,Tcontra,Fcontra,Vcontra,Mrent,MonrentIdNavigation,Obsarre,Obsgra,Obsequi,NameFichaDoc,Fichaequi,Fecharequi,ModaEquiId,MarcaId,FabricanteId,EmpresaId")] Equiuni equiuni)
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
                return RedirectToAction(nameof(Index), new { id = equiuni.NumacuofsolNavigator });
            }
            ViewData["CombuequiIdNavigation"] = new SelectList(_context.CombustibleTypes, "Idcomb", "Idcomb", equiuni.CombuequiIdNavigation);
            ViewData["ModaequiIdNavigation"] = new SelectList(_context.Modelos, "Idmod", "Idmod", equiuni.ModaequiIdNavigation);
            ViewData["MonrentIdNavigation"] = new SelectList(_context.Moneda, "Id", "Id", equiuni.MonrentIdNavigation);
            ViewData["NumacuofsolNavigator"] = new SelectList(_context.Solrves, "Numacuofsol", "Numacuofsol", equiuni.NumacuofsolNavigator);
            ViewData["RegiequiIdNavigation"] = new SelectList(_context.RegimenJuridicos, "Id", "Id", equiuni.RegiequiIdNavigation);
            ViewData["TipequiIdNavigation"] = new SelectList(_context.EquipoTypes, "IdEqui", "IdEqui", equiuni.TipequiIdNavigation);
            ViewData["UsoequiIdNavigation"] = new SelectList(_context.Usoequis, "Id", "Id", equiuni.UsoequiIdNavigation);
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Idempre", "Rsempre", equiuni.EmpresaId);
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "Idfab", "Rsfab", equiuni.FabricanteId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "RsMarca", equiuni.MarcaId);
            ViewData["ModaEquiId"] = new SelectList(_context.ModaEquis, "Id", "Description", equiuni.ModaEquiId);
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
                .Include(e => e.Empresa)
                .Include(e => e.ModaEqui)
                .Include(e => e.Fabricante)
                .Include(e => e.Marca)
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
            return RedirectToAction(nameof(Index), new { id = equiuni.NumacuofsolNavigator });
        }

        private bool EquiuniExists(int id)
        {
          return (_context.Equiunis?.Any(e => e.Idequi == id)).GetValueOrDefault();
        }

        
        [HttpPost]
        public JsonResult VerificarNumeroSerie(string Nserie)
        {
            bool existeEnBaseDeDatos = _context.Equiunis.Any(m => m.Nserie == Nserie);
            return Json(new { existe = existeEnBaseDeDatos });
        }

        [HttpPost]
        public JsonResult VerificarMatricula(string Matricula)
        {
            bool existeEnBaseDeDatos = _context.Equiunis.Any(m => m.Matricula == Matricula);
            return Json(new { existe = existeEnBaseDeDatos });
        }
    }
}
