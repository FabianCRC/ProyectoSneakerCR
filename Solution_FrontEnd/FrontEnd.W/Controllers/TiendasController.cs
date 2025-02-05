﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrontEnd.W.Models;

namespace FrontEnd.W.Controllers
{
    public class TiendasController : Controller
    {
        private readonly SneakersCRContext _context;

        public TiendasController(SneakersCRContext context)
        {
            _context = context;
        }

        // GET: Tiendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tiendas.ToListAsync());
        }

        // GET: Tiendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiendas = await _context.Tiendas
                .FirstOrDefaultAsync(m => m.IdTienda == id);
            if (tiendas == null)
            {
                return NotFound();
            }

            return View(tiendas);
        }

        // GET: Tiendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tiendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTienda,NombreTienda,DescripcionTienda")] Tiendas tiendas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiendas);
        }

        // GET: Tiendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiendas = await _context.Tiendas.FindAsync(id);
            if (tiendas == null)
            {
                return NotFound();
            }
            return View(tiendas);
        }

        // POST: Tiendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTienda,NombreTienda,DescripcionTienda")] Tiendas tiendas)
        {
            if (id != tiendas.IdTienda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiendasExists(tiendas.IdTienda))
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
            return View(tiendas);
        }

        // GET: Tiendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiendas = await _context.Tiendas
                .FirstOrDefaultAsync(m => m.IdTienda == id);
            if (tiendas == null)
            {
                return NotFound();
            }

            return View(tiendas);
        }

        // POST: Tiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiendas = await _context.Tiendas.FindAsync(id);
            _context.Tiendas.Remove(tiendas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiendasExists(int id)
        {
            return _context.Tiendas.Any(e => e.IdTienda == id);
        }
    }
}
