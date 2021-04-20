using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FrontEnd.W.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using data = FrontEnd.W.Models;

namespace FrontEnd.W.Controllers
{
    public class MarcaProductosController : Controller
    {
        private readonly SneakersCRContext _context;

        public MarcaProductosController(SneakersCRContext context)
        {
            _context = context;
        }

        // GET: MarcaProductos
        public async Task<IActionResult> Index()
        {
            return View(await _context.MarcaProductos.ToListAsync());
        }

        // GET: MarcaProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaProductos = await _context.MarcaProductos
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (marcaProductos == null)
            {
                return NotFound();
            }

            return View(marcaProductos);
        }

        // GET: MarcaProductos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarcaProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMarca,MarcaProducto")] MarcaProductos marcaProductos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcaProductos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcaProductos);
        }

        // GET: MarcaProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaProductos = await _context.MarcaProductos.FindAsync(id);
            if (marcaProductos == null)
            {
                return NotFound();
            }
            return View(marcaProductos);
        }

        // POST: MarcaProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMarca,MarcaProducto")] MarcaProductos marcaProductos)
        {
            if (id != marcaProductos.IdMarca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcaProductos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaProductosExists(marcaProductos.IdMarca))
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
            return View(marcaProductos);
        }

        // GET: MarcaProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaProductos = await _context.MarcaProductos
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (marcaProductos == null)
            {
                return NotFound();
            }

            return View(marcaProductos);
        }

        // POST: MarcaProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marcaProductos = await _context.MarcaProductos.FindAsync(id);
            _context.MarcaProductos.Remove(marcaProductos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaProductosExists(int id)
        {
            return _context.MarcaProductos.Any(e => e.IdMarca == id);
        }
    }
}
