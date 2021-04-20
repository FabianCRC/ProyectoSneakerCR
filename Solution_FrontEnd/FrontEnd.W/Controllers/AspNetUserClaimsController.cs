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
    public class AspNetUserClaimsController : Controller
    {
        private readonly SneakersCRContext _context;

        public AspNetUserClaimsController(SneakersCRContext context)
        {
            _context = context;
        }

        // GET: AspNetUserClaims
        public async Task<IActionResult> Index()
        {
            var sneakersCRContext = _context.AspNetUserClaims.Include(a => a.User);
            return View(await sneakersCRContext.ToListAsync());
        }

        // GET: AspNetUserClaims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUserClaims = await _context.AspNetUserClaims
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUserClaims == null)
            {
                return NotFound();
            }

            return View(aspNetUserClaims);
        }

        // GET: AspNetUserClaims/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: AspNetUserClaims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ClaimType,ClaimValue")] AspNetUserClaims aspNetUserClaims)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspNetUserClaims);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", aspNetUserClaims.UserId);
            return View(aspNetUserClaims);
        }

        // GET: AspNetUserClaims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUserClaims = await _context.AspNetUserClaims.FindAsync(id);
            if (aspNetUserClaims == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", aspNetUserClaims.UserId);
            return View(aspNetUserClaims);
        }

        // POST: AspNetUserClaims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ClaimType,ClaimValue")] AspNetUserClaims aspNetUserClaims)
        {
            if (id != aspNetUserClaims.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspNetUserClaims);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetUserClaimsExists(aspNetUserClaims.Id))
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
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", aspNetUserClaims.UserId);
            return View(aspNetUserClaims);
        }

        // GET: AspNetUserClaims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUserClaims = await _context.AspNetUserClaims
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUserClaims == null)
            {
                return NotFound();
            }

            return View(aspNetUserClaims);
        }

        // POST: AspNetUserClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aspNetUserClaims = await _context.AspNetUserClaims.FindAsync(id);
            _context.AspNetUserClaims.Remove(aspNetUserClaims);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetUserClaimsExists(int id)
        {
            return _context.AspNetUserClaims.Any(e => e.Id == id);
        }
    }
}
