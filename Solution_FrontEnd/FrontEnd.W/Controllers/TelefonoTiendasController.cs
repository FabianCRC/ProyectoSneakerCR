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
    public class TelefonoTiendasController : Controller
    {
        private readonly SneakersCRContext _context;

        public TelefonoTiendasController(SneakersCRContext context)
        {
            _context = context;
        }

        // GET: TelefonoTiendas
        public async Task<IActionResult> Index()
        {
            var sneakersCRContext = _context.TelefonoTienda.Include(t => t.IdTiendaNavigation);
            return View(await sneakersCRContext.ToListAsync());
        }

        // GET: TelefonoTiendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoTienda = await _context.TelefonoTienda
                .Include(t => t.IdTiendaNavigation)
                .FirstOrDefaultAsync(m => m.IdTelefono == id);
            if (telefonoTienda == null)
            {
                return NotFound();
            }

            return View(telefonoTienda);
        }

        // GET: TelefonoTiendas/Create
        public IActionResult Create()
        {
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda");
            return View();
        }

        // POST: TelefonoTiendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTelefono,Descripcion,Numero,IdTienda")] TelefonoTienda telefonoTienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefonoTienda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", telefonoTienda.IdTienda);
            return View(telefonoTienda);
        }

        // GET: TelefonoTiendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoTienda = await _context.TelefonoTienda.FindAsync(id);
            if (telefonoTienda == null)
            {
                return NotFound();
            }
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", telefonoTienda.IdTienda);
            return View(telefonoTienda);
        }

        // POST: TelefonoTiendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTelefono,Descripcion,Numero,IdTienda")] TelefonoTienda telefonoTienda)
        {
            if (id != telefonoTienda.IdTelefono)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefonoTienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoTiendaExists(telefonoTienda.IdTelefono))
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
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", telefonoTienda.IdTienda);
            return View(telefonoTienda);
        }

        // GET: TelefonoTiendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoTienda = await _context.TelefonoTienda
                .Include(t => t.IdTiendaNavigation)
                .FirstOrDefaultAsync(m => m.IdTelefono == id);
            if (telefonoTienda == null)
            {
                return NotFound();
            }

            return View(telefonoTienda);
        }

        // POST: TelefonoTiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefonoTienda = await _context.TelefonoTienda.FindAsync(id);
            _context.TelefonoTienda.Remove(telefonoTienda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoTiendaExists(int id)
        {
            return _context.TelefonoTienda.Any(e => e.IdTelefono == id);
        }
    }
}
