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
    public class AspNetUserLoginsController : Controller
    {
        private readonly SneakersCRContext _context;

        public AspNetUserLoginsController(SneakersCRContext context)
        {
            _context = context;
        }

        // GET: AspNetUserLogins
        public async Task<IActionResult> Index()
        {
            var sneakersCRContext = _context.AspNetUserLogins.Include(a => a.User);
            return View(await sneakersCRContext.ToListAsync());
        }

        // GET: AspNetUserLogins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUserLogins = await _context.AspNetUserLogins
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUserLogins == null)
            {
                return NotFound();
            }

            return View(aspNetUserLogins);
        }

        // GET: AspNetUserLogins/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: AspNetUserLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LoginProvider,ProviderKey,ProviderDisplayName,UserId")] AspNetUserLogins aspNetUserLogins)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspNetUserLogins);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", aspNetUserLogins.UserId);
            return View(aspNetUserLogins);
        }

        // GET: AspNetUserLogins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUserLogins = await _context.AspNetUserLogins.FindAsync(id);
            if (aspNetUserLogins == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", aspNetUserLogins.UserId);
            return View(aspNetUserLogins);
        }

        // POST: AspNetUserLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LoginProvider,ProviderKey,ProviderDisplayName,UserId")] AspNetUserLogins aspNetUserLogins)
        {
            if (id != aspNetUserLogins.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspNetUserLogins);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetUserLoginsExists(aspNetUserLogins.Id))
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
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", aspNetUserLogins.UserId);
            return View(aspNetUserLogins);
        }

        // GET: AspNetUserLogins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUserLogins = await _context.AspNetUserLogins
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUserLogins == null)
            {
                return NotFound();
            }

            return View(aspNetUserLogins);
        }

        // POST: AspNetUserLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aspNetUserLogins = await _context.AspNetUserLogins.FindAsync(id);
            _context.AspNetUserLogins.Remove(aspNetUserLogins);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetUserLoginsExists(int id)
        {
            return _context.AspNetUserLogins.Any(e => e.Id == id);
        }
    }
}
