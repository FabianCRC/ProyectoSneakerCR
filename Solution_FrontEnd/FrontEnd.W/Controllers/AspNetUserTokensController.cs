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
    public class AspNetUserTokensController : Controller
    {
        private readonly SneakersCRContext _context;

        public AspNetUserTokensController(SneakersCRContext context)
        {
            _context = context;
        }

        // GET: AspNetUserTokens
        public async Task<IActionResult> Index()
        {
            var sneakersCRContext = _context.AspNetUserTokens.Include(a => a.User);
            return View(await sneakersCRContext.ToListAsync());
        }

        // GET: AspNetUserTokens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUserTokens = await _context.AspNetUserTokens
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUserTokens == null)
            {
                return NotFound();
            }

            return View(aspNetUserTokens);
        }

        // GET: AspNetUserTokens/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: AspNetUserTokens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,LoginProvider,Name,Value")] AspNetUserTokens aspNetUserTokens)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspNetUserTokens);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", aspNetUserTokens.UserId);
            return View(aspNetUserTokens);
        }

        // GET: AspNetUserTokens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUserTokens = await _context.AspNetUserTokens.FindAsync(id);
            if (aspNetUserTokens == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", aspNetUserTokens.UserId);
            return View(aspNetUserTokens);
        }

        // POST: AspNetUserTokens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,LoginProvider,Name,Value")] AspNetUserTokens aspNetUserTokens)
        {
            if (id != aspNetUserTokens.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspNetUserTokens);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetUserTokensExists(aspNetUserTokens.Id))
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
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", aspNetUserTokens.UserId);
            return View(aspNetUserTokens);
        }

        // GET: AspNetUserTokens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUserTokens = await _context.AspNetUserTokens
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUserTokens == null)
            {
                return NotFound();
            }

            return View(aspNetUserTokens);
        }

        // POST: AspNetUserTokens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aspNetUserTokens = await _context.AspNetUserTokens.FindAsync(id);
            _context.AspNetUserTokens.Remove(aspNetUserTokens);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetUserTokensExists(int id)
        {
            return _context.AspNetUserTokens.Any(e => e.Id == id);
        }
    }
}
