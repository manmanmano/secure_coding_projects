using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Domain;
using WebApp.Helpers;

namespace WebApp.Controllers
{
    public class RSAController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RSAController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        
        public string GetLoggedInUserId()
        {
            return User.Claims.First(cm =>
                cm.Type == ClaimTypes.NameIdentifier).Value;
        }

        
        // GET: RSA
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = 
                _context
                    .RSA
                    .Where(r=>r.AppUserId == GetLoggedInUserId()) 
                    .Include(r => r.AppUser);
            
            return View(await applicationDbContext.ToListAsync());
        }

        
        // GET: RSA/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // check that the user actually owns the data
            var isOwned = await _context.RSA.AnyAsync(r => r.Id == id && r.AppUserId == GetLoggedInUserId());

            if (!isOwned)
            {
                return NotFound();
            }
            
            if (id == null || _context.RSA == null)
            {
                return NotFound();
            }

            var rsa = await _context.RSA
                .Include(r => r.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (rsa == null)
            {
                return NotFound();
            }

            return View(rsa);
        }

        
        // GET: RSA/Create
        public IActionResult Create()
        {
            return View();
        }

        
        // POST: RSA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RSA rsa)
        {
            rsa.AppUserId = GetLoggedInUserId();
            
            var plaintextBytes = System.Text.Encoding.UTF8.GetBytes(rsa.Plaintext);
            var longBytes = plaintextBytes.Select(b => (long)b).ToList();
            rsa.PlaintextBytes = string.Join(" ", plaintextBytes);
            rsa.PrimeP = RSAHelper.ValidateP(rsa.PrimeP);
            rsa.PrimeQ = RSAHelper.ValidateQ(rsa.PrimeP, rsa.PrimeQ);
            rsa.PublicKeyN = rsa.PrimeP * rsa.PrimeQ;
            rsa.Modulus = (rsa.PrimeP - 1) * (rsa.PrimeQ - 1);
            rsa.Exponent = RSAHelper.CalculateE(rsa.Modulus, 1);

            rsa.EncryptedBytes = RSAHelper.EncryptTextBytes(longBytes, rsa.Exponent, rsa.PublicKeyN);

            if (ModelState.IsValid)
            {
                _context.Add(rsa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(rsa);
        }

        
        // GET: RSA/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // check that the user actually owns the data
            var isOwned = await _context.RSA.AnyAsync(r => r.Id == id && r.AppUserId == GetLoggedInUserId());

            if (!isOwned)
            {
                return NotFound();
            }
            
            if (id == null || _context.RSA == null)
            {
                return NotFound();
            }

            var rsa = await _context.RSA.FindAsync(id);
            if (rsa == null)
            {
                return NotFound();
            }
            
            return View(rsa);
        }

        
        // POST: RSA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RSA rsa)
        {
            // check that the user actually owns the data
            var isOwned = await _context.RSA.AnyAsync(r => r.Id == id && r.AppUserId == GetLoggedInUserId());

            if (!isOwned)
            {
                return NotFound();
            }
            
            if (id != rsa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rsa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RSAExists(rsa.Id))
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
            
            return View(rsa);
        }

        
        // GET: RSA/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // check that the user actually owns the data
            var isOwned = await _context.RSA.AnyAsync(r => r.Id == id && r.AppUserId == GetLoggedInUserId());

            if (!isOwned)
            {
                return NotFound();
            }

            if (id == null || _context.RSA == null)
            {
                return NotFound();
            }

            var rsa = await _context.RSA
                .Include(r => r.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rsa == null)
            {
                return NotFound();
            }

            return View(rsa);
        }

        
        // POST: RSA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // check that the user actually owns the data
            var isOwned = await _context.RSA.AnyAsync(r => r.Id == id && r.AppUserId == GetLoggedInUserId());

            if (!isOwned)
            {
                return NotFound();
            }

            if (_context.RSA == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RSA'  is null.");
            }
            
            var rsa = await _context.RSA.FindAsync(id);
            
            if (rsa != null)
            {
                _context.RSA.Remove(rsa);
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
