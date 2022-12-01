using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Domain;

namespace WebApp.Controllers
{
    public class RSAController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RSAController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RSA
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RSA.Include(r => r.AppUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RSA/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RSA == null)
            {
                return NotFound();
            }

            var rSA = await _context.RSA
                .Include(r => r.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rSA == null)
            {
                return NotFound();
            }

            return View(rSA);
        }

        // GET: RSA/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: RSA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Plaintext,PlaintextBytes,PrimeP,PrimeQ,Modulus,Exponent,EncryptedBytes,AppUserId")] RSA rSA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rSA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", rSA.AppUserId);
            return View(rSA);
        }

        // GET: RSA/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RSA == null)
            {
                return NotFound();
            }

            var rSA = await _context.RSA.FindAsync(id);
            if (rSA == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", rSA.AppUserId);
            return View(rSA);
        }

        // POST: RSA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Plaintext,PlaintextBytes,PrimeP,PrimeQ,Modulus,Exponent,EncryptedBytes,AppUserId")] RSA rSA)
        {
            if (id != rSA.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rSA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RSAExists(rSA.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", rSA.AppUserId);
            return View(rSA);
        }

        // GET: RSA/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RSA == null)
            {
                return NotFound();
            }

            var rSA = await _context.RSA
                .Include(r => r.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rSA == null)
            {
                return NotFound();
            }

            return View(rSA);
        }

        // POST: RSA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RSA == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RSA'  is null.");
            }
            var rSA = await _context.RSA.FindAsync(id);
            if (rSA != null)
            {
                _context.RSA.Remove(rSA);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RSAExists(int id)
        {
          return (_context.RSA?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
