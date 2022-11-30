using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Domain;

namespace WebApp.Controllers
{
    [Authorize]
    public class DiffieHellmanController : Controller
    {
        private readonly ApplicationDbContext _context;

        
        public DiffieHellmanController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public string GetLoggedInUserId()
        {
            return User.Claims.First(cm =>
                cm.Type == ClaimTypes.NameIdentifier).Value;
        }
        
        
        // GET: DiffieHellman
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = 
                _context
                    .DiffieHellman!
                    .Where(d => d.AppUserId == GetLoggedInUserId())
                    .Include(d => d.AppUser);
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DiffieHellman/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // check that the user actually owns the data
            var isOwned = await _context.Caesars.AnyAsync(c => c.Id == id && c.AppUserId == GetLoggedInUserId());

            if (!isOwned)
            {
                return NotFound();
            }
            
            if (id == null || _context.DiffieHellman == null)
            {
                return NotFound();
            }

            var diffieHellman = await _context.DiffieHellman
                .Include(d => d.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (diffieHellman == null)
            {
                return NotFound();
            }

            return View(diffieHellman);
        }

        
        // GET: DiffieHellman/Create
        public IActionResult Create()
        {
            return View();
        }

        
        // POST: DiffieHellman/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DiffieHellman diffieHellman)
        {
            diffieHellman.AppUserId = GetLoggedInUserId();

            if (ModelState.IsValid)
            {
                _context.Add(diffieHellman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(diffieHellman);
        }

        // GET: DiffieHellman/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // check that the user actually owns the data
            var isOwned = await _context.Caesars.AnyAsync(c => c.Id == id && c.AppUserId == GetLoggedInUserId());

            if (!isOwned)
            {
                return NotFound();
            }
            
            if (id == null || _context.DiffieHellman == null)
            {
                return NotFound();
            }

            var diffieHellman = await _context.DiffieHellman.FindAsync(id);
            if (diffieHellman == null)
            {
                return NotFound();
            }
            
            return View(diffieHellman);
        }

        // POST: DiffieHellman/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DiffieHellman diffieHellman)
        {
            // check that the user actually owns the data
            var isOwned = await _context.Caesars.AnyAsync(c => c.Id == id && c.AppUserId == GetLoggedInUserId());

            if (!isOwned)
            {
                return NotFound();
            }
            
            diffieHellman.AppUserId = GetLoggedInUserId();

            if (id != diffieHellman.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diffieHellman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiffieHellmanExists(diffieHellman.Id))
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
            
            return View(diffieHellman);
        }

        // GET: DiffieHellman/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // check that the user actually owns the data
            var isOwned = await _context.Caesars.AnyAsync(c => c.Id == id && c.AppUserId == GetLoggedInUserId());

            if (!isOwned)
            {
                return NotFound();
            }

            if (id == null || _context.DiffieHellman == null)
            {
                return NotFound();
            }

            var diffieHellman = await _context.DiffieHellman
                .Include(d => d.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diffieHellman == null)
            {
                return NotFound();
            }

            return View(diffieHellman);
        }

        // POST: DiffieHellman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // check that the user actually owns the data
            var isOwned = await _context.Caesars.AnyAsync(c => c.Id == id && c.AppUserId == GetLoggedInUserId());

            if (!isOwned)
            {
                return NotFound();
            }

            if (_context.DiffieHellman == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DiffieHellman'  is null.");
            }
            var diffieHellman = await _context.DiffieHellman.FindAsync(id);
            if (diffieHellman != null)
            {
                _context.DiffieHellman.Remove(diffieHellman);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiffieHellmanExists(int id)
        {
          return (_context.DiffieHellman?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
