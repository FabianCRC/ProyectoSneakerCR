using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrontEnd.W.Models;

namespace FrontEnd.W.Controllers
{
    public class ValoracionTiendasController : Controller
    {
        private readonly SneakersCRContext _context;

        public ValoracionTiendasController(SneakersCRContext context)
        {
            _context = context;
        }

        // GET: ValoracionTiendas
        public async Task<IActionResult> Index()
        {
            var sneakersCRContext = _context.ValoracionTienda.Include(v => v.IdTiendaNavigation).Include(v => v.IdUsuarioNavigation);
            return View(await sneakersCRContext.ToListAsync());
        }

        // GET: ValoracionTiendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valoracionTienda = await _context.ValoracionTienda
                .Include(v => v.IdTiendaNavigation)
                .Include(v => v.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdValoracion == id);
            if (valoracionTienda == null)
            {
                return NotFound();
            }

            return View(valoracionTienda);
        }

        // GET: ValoracionTiendas/Create
        public IActionResult Create()
        {
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda");
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: ValoracionTiendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdValoracion,Valoracion,Comentario,IdUsuario,IdTienda")] ValoracionTienda valoracionTienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(valoracionTienda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", valoracionTienda.IdTienda);
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id", valoracionTienda.IdUsuario);
            return View(valoracionTienda);
        }

        // GET: ValoracionTiendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valoracionTienda = await _context.ValoracionTienda.FindAsync(id);
            if (valoracionTienda == null)
            {
                return NotFound();
            }
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", valoracionTienda.IdTienda);
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id", valoracionTienda.IdUsuario);
            return View(valoracionTienda);
        }

        // POST: ValoracionTiendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdValoracion,Valoracion,Comentario,IdUsuario,IdTienda")] ValoracionTienda valoracionTienda)
        {
            if (id != valoracionTienda.IdValoracion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(valoracionTienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValoracionTiendaExists(valoracionTienda.IdValoracion))
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
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", valoracionTienda.IdTienda);
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id", valoracionTienda.IdUsuario);
            return View(valoracionTienda);
        }

        // GET: ValoracionTiendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valoracionTienda = await _context.ValoracionTienda
                .Include(v => v.IdTiendaNavigation)
                .Include(v => v.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdValoracion == id);
            if (valoracionTienda == null)
            {
                return NotFound();
            }

            return View(valoracionTienda);
        }

        // POST: ValoracionTiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var valoracionTienda = await _context.ValoracionTienda.FindAsync(id);
            _context.ValoracionTienda.Remove(valoracionTienda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValoracionTiendaExists(int id)
        {
            return _context.ValoracionTienda.Any(e => e.IdValoracion == id);
        }
    }
}
