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
    public class CorreoTiendasController : Controller
    {
        private readonly SneakersCRContext _context;

        public CorreoTiendasController(SneakersCRContext context)
        {
            _context = context;
        }

        // GET: CorreoTiendas
        public async Task<IActionResult> Index()
        {
            var sneakersCRContext = _context.CorreoTienda.Include(c => c.IdTiendaNavigation);
            return View(await sneakersCRContext.ToListAsync());
        }

        // GET: CorreoTiendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correoTienda = await _context.CorreoTienda
                .Include(c => c.IdTiendaNavigation)
                .FirstOrDefaultAsync(m => m.IdCorreo == id);
            if (correoTienda == null)
            {
                return NotFound();
            }

            return View(correoTienda);
        }

        // GET: CorreoTiendas/Create
        public IActionResult Create()
        {
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda");
            return View();
        }

        // POST: CorreoTiendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCorreo,Correo,Descripcion,IdTienda")] CorreoTienda correoTienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(correoTienda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", correoTienda.IdTienda);
            return View(correoTienda);
        }

        // GET: CorreoTiendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correoTienda = await _context.CorreoTienda.FindAsync(id);
            if (correoTienda == null)
            {
                return NotFound();
            }
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", correoTienda.IdTienda);
            return View(correoTienda);
        }

        // POST: CorreoTiendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCorreo,Correo,Descripcion,IdTienda")] CorreoTienda correoTienda)
        {
            if (id != correoTienda.IdCorreo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(correoTienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorreoTiendaExists(correoTienda.IdCorreo))
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
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", correoTienda.IdTienda);
            return View(correoTienda);
        }

        // GET: CorreoTiendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correoTienda = await _context.CorreoTienda
                .Include(c => c.IdTiendaNavigation)
                .FirstOrDefaultAsync(m => m.IdCorreo == id);
            if (correoTienda == null)
            {
                return NotFound();
            }

            return View(correoTienda);
        }

        // POST: CorreoTiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var correoTienda = await _context.CorreoTienda.FindAsync(id);
            _context.CorreoTienda.Remove(correoTienda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorreoTiendaExists(int id)
        {
            return _context.CorreoTienda.Any(e => e.IdCorreo == id);
        }
    }
}
