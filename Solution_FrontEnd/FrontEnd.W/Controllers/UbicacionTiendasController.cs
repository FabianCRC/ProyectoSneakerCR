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
    public class UbicacionTiendasController : Controller
    {
        private readonly SneakersCRContext _context;

        public UbicacionTiendasController(SneakersCRContext context)
        {
            _context = context;
        }

        // GET: UbicacionTiendas
        public async Task<IActionResult> Index()
        {
            var sneakersCRContext = _context.UbicacionTienda.Include(u => u.IdTiendaNavigation);
            return View(await sneakersCRContext.ToListAsync());
        }

        // GET: UbicacionTiendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacionTienda = await _context.UbicacionTienda
                .Include(u => u.IdTiendaNavigation)
                .FirstOrDefaultAsync(m => m.IdUbicacion == id);
            if (ubicacionTienda == null)
            {
                return NotFound();
            }

            return View(ubicacionTienda);
        }

        // GET: UbicacionTiendas/Create
        public IActionResult Create()
        {
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda");
            return View();
        }

        // POST: UbicacionTiendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUbicacion,Provincia,Canton,Direccion,IdTienda")] UbicacionTienda ubicacionTienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ubicacionTienda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", ubicacionTienda.IdTienda);
            return View(ubicacionTienda);
        }

        // GET: UbicacionTiendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacionTienda = await _context.UbicacionTienda.FindAsync(id);
            if (ubicacionTienda == null)
            {
                return NotFound();
            }
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", ubicacionTienda.IdTienda);
            return View(ubicacionTienda);
        }

        // POST: UbicacionTiendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUbicacion,Provincia,Canton,Direccion,IdTienda")] UbicacionTienda ubicacionTienda)
        {
            if (id != ubicacionTienda.IdUbicacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ubicacionTienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UbicacionTiendaExists(ubicacionTienda.IdUbicacion))
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
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", ubicacionTienda.IdTienda);
            return View(ubicacionTienda);
        }

        // GET: UbicacionTiendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacionTienda = await _context.UbicacionTienda
                .Include(u => u.IdTiendaNavigation)
                .FirstOrDefaultAsync(m => m.IdUbicacion == id);
            if (ubicacionTienda == null)
            {
                return NotFound();
            }

            return View(ubicacionTienda);
        }

        // POST: UbicacionTiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ubicacionTienda = await _context.UbicacionTienda.FindAsync(id);
            _context.UbicacionTienda.Remove(ubicacionTienda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UbicacionTiendaExists(int id)
        {
            return _context.UbicacionTienda.Any(e => e.IdUbicacion == id);
        }
    }
}
