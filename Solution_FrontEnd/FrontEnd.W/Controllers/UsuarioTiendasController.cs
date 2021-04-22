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
    public class UsuarioTiendasController : Controller
    {
        private readonly SneakersCRContext _context;

        public UsuarioTiendasController(SneakersCRContext context)
        {
            _context = context;
        }

        // GET: UsuarioTiendas
        public async Task<IActionResult> Index()
        {
            var sneakersCRContext = _context.UsuarioTienda.Include(u => u.IdTiendaNavigation).Include(u => u.IdUsuarioNavigation);
            return View(await sneakersCRContext.ToListAsync());
        }

        // GET: UsuarioTiendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioTienda = await _context.UsuarioTienda
                .Include(u => u.IdTiendaNavigation)
                .Include(u => u.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuarioTienda == id);
            if (usuarioTienda == null)
            {
                return NotFound();
            }

            return View(usuarioTienda);
        }

        // GET: UsuarioTiendas/Create
        public IActionResult Create()
        {
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda");
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: UsuarioTiendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuarioTienda,IdUsuario,IdTienda")] UsuarioTienda usuarioTienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioTienda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", usuarioTienda.IdTienda);
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id", usuarioTienda.IdUsuario);
            return View(usuarioTienda);
        }

        // GET: UsuarioTiendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioTienda = await _context.UsuarioTienda.FindAsync(id);
            if (usuarioTienda == null)
            {
                return NotFound();
            }
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", usuarioTienda.IdTienda);
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id", usuarioTienda.IdUsuario);
            return View(usuarioTienda);
        }

        // POST: UsuarioTiendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuarioTienda,IdUsuario,IdTienda")] UsuarioTienda usuarioTienda)
        {
            if (id != usuarioTienda.IdUsuarioTienda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioTienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioTiendaExists(usuarioTienda.IdUsuarioTienda))
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
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", usuarioTienda.IdTienda);
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id", usuarioTienda.IdUsuario);
            return View(usuarioTienda);
        }

        // GET: UsuarioTiendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioTienda = await _context.UsuarioTienda
                .Include(u => u.IdTiendaNavigation)
                .Include(u => u.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuarioTienda == id);
            if (usuarioTienda == null)
            {
                return NotFound();
            }

            return View(usuarioTienda);
        }

        // POST: UsuarioTiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioTienda = await _context.UsuarioTienda.FindAsync(id);
            _context.UsuarioTienda.Remove(usuarioTienda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioTiendaExists(int id)
        {
            return _context.UsuarioTienda.Any(e => e.IdUsuarioTienda == id);
        }
    }
}
