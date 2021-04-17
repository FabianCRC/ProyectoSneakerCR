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
    public class CategoriaProductosController : Controller
    {
        private readonly SneakersCRContext _context;

        public CategoriaProductosController(SneakersCRContext context)
        {
            _context = context;
        }

        // GET: CategoriaProductos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaProductos.ToListAsync());
        }

        // GET: CategoriaProductos/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProductos = await _context.CategoriaProductos
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categoriaProductos == null)
            {
                return NotFound();
            }

            return View(categoriaProductos);
        }

        // GET: CategoriaProductos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoria,Categoria")] CategoriaProductos categoriaProductos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaProductos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaProductos);
        }

        // GET: CategoriaProductos/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProductos = await _context.CategoriaProductos.FindAsync(id);
            if (categoriaProductos == null)
            {
                return NotFound();
            }
            return View(categoriaProductos);
        }

        // POST: CategoriaProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdCategoria,Categoria")] CategoriaProductos categoriaProductos)
        {
            if (id != categoriaProductos.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaProductos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaProductosExists(categoriaProductos.IdCategoria))
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
            return View(categoriaProductos);
        }

        // GET: CategoriaProductos/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProductos = await _context.CategoriaProductos
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categoriaProductos == null)
            {
                return NotFound();
            }

            return View(categoriaProductos);
        }

        // POST: CategoriaProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var categoriaProductos = await _context.CategoriaProductos.FindAsync(id);
            _context.CategoriaProductos.Remove(categoriaProductos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaProductosExists(decimal id)
        {
            return _context.CategoriaProductos.Any(e => e.IdCategoria == id);
        }
    }
}
