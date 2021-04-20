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
    public class ProductosController : Controller
    {
        private readonly SneakersCRContext _context;

        public ProductosController(SneakersCRContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var sneakersCRContext = _context.Productos.Include(p => p.IdCategoriaNavigation).Include(p => p.IdMarcaProductoNavigation).Include(p => p.IdTiendaNavigation);
            return View(await sneakersCRContext.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .Include(p => p.IdCategoriaNavigation)
                .Include(p => p.IdMarcaProductoNavigation)
                .Include(p => p.IdTiendaNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaProductos, "IdCategoria", "Categoria");
            ViewData["IdMarcaProducto"] = new SelectList(_context.MarcaProductos, "IdMarca", "MarcaProducto");
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,NombreProducto,DescripcionPproducto,Anno,Valor,IdMarcaProducto,IdTienda,IdCategoria")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaProductos, "IdCategoria", "Categoria", productos.IdCategoria);
            ViewData["IdMarcaProducto"] = new SelectList(_context.MarcaProductos, "IdMarca", "MarcaProducto", productos.IdMarcaProducto);
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", productos.IdTienda);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaProductos, "IdCategoria", "Categoria", productos.IdCategoria);
            ViewData["IdMarcaProducto"] = new SelectList(_context.MarcaProductos, "IdMarca", "MarcaProducto", productos.IdMarcaProducto);
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", productos.IdTienda);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,NombreProducto,DescripcionPproducto,Anno,Valor,IdMarcaProducto,IdTienda,IdCategoria")] Productos productos)
        {
            if (id != productos.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(productos.IdProducto))
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
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaProductos, "IdCategoria", "Categoria", productos.IdCategoria);
            ViewData["IdMarcaProducto"] = new SelectList(_context.MarcaProductos, "IdMarca", "MarcaProducto", productos.IdMarcaProducto);
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "DescripcionTienda", productos.IdTienda);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .Include(p => p.IdCategoriaNavigation)
                .Include(p => p.IdMarcaProductoNavigation)
                .Include(p => p.IdTiendaNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productos = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(productos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.IdProducto == id);
        }
    }
}
