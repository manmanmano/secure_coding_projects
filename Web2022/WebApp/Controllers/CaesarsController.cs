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
using WebApp.Helpers;


namespace WebApp.Controllers
{
    [Authorize]
    public class CaesarsController : Controller
    {
        private readonly ApplicationDbContext _context;


        public CaesarsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Caesars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext =
                _context
                    .Caesars
                    .Where(c => c.AppUserId == GetLoggedInUserId())
                    .Include(c => c.AppUser);

            return View(await applicationDbContext.ToListAsync());
        }


        public string GetLoggedInUserId()
        {
            return User.Claims.First(cm =>
                cm.Type == ClaimTypes.NameIdentifier).Value;
        }


        // GET: Caesars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Caesars == null)
            {
                return NotFound();
            }

            var caesar = await _context.Caesars
                .Include(c => c.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (caesar == null)
            {
                return NotFound();
            }

            return View(caesar);
        }


        // GET: Caesars/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Caesars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Caesar caesar)
        {
            caesar.AppUserId = GetLoggedInUserId();
            caesar.Ciphertext = CaesarHelper.EncryptText(caesar.Plaintext, caesar.ShiftAmount);

            if (ModelState.IsValid)
            {
                _context.Add(caesar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(caesar);
        }


        // GET: Caesars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Caesars == null)
            {
                return NotFound();
            }

            var caesar = await _context.Caesars
                .SingleOrDefaultAsync(c => c.AppUserId == GetLoggedInUserId() && c.Id == id);

            if (caesar == null)
            {
                return NotFound();
            }

            return View(caesar);
        }


        // POST: Caesars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Caesar caesar)
        {
            if (id != caesar.Id)
            {
                return NotFound();
            }

            caesar.AppUserId = GetLoggedInUserId();
            caesar.Ciphertext = CaesarHelper.EncryptText(caesar.Plaintext, caesar.ShiftAmount);

            // check that the user actually owns the data
            var isOwned = await _context.Caesars.AnyAsync(c => c.Id == id && c.AppUserId == GetLoggedInUserId());

            if (!isOwned)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caesar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaesarExists(caesar.Id))
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

            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", caesar.AppUserId);

            return View(caesar);
        }

        
        // GET: Caesars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Caesars == null)
            {
                return NotFound();
            }

            var caesar = await _context.Caesars
                .Include(c => c.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caesar == null)
            {
                return NotFound();
            }

            return View(caesar);
        }

        
        // POST: Caesars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Caesars == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Caesars'  is null.");
            }

            var caesar = await _context.Caesars.FindAsync(id);
            
            if (caesar != null)
            {
                _context.Caesars.Remove(caesar);
            }

            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        
        private bool CaesarExists(int id)
        {
            return (_context.Caesars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}