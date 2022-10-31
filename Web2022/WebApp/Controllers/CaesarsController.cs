using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Domain;

namespace WebApp.Controllers
{
    public class CaesarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CaesarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Caesar
        public async Task<IActionResult> Index()
        {
              return _context.Caesars != null ? 
                          View(await _context.Caesars.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Caesars'  is null.");
        }

        // GET: Caesars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Caesars == null)
            {
                return NotFound();
            }

            var caesars = await _context.Caesars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caesars == null)
            {
                return NotFound();
            }

            return View(caesars);
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
        public async Task<IActionResult> Create([Bind("Id,ShiftAmount,Plaintext,Ciphertext")] Caesar caesar)
        {
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

            var caesar = await _context.Caesars.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShiftAmount,Plaintext,Ciphertext")] Caesar caesar)
        {
            if (id != caesar.Id)
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
                    if (!CaesarsExists(caesar.Id))
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
            return View(caesar);
        }

        // GET: Caesars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Caesars == null)
            {
                return NotFound();
            }

            var caesars = await _context.Caesars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caesars == null)
            {
                return NotFound();
            }

            return View(caesars);
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
            var caesars = await _context.Caesars.FindAsync(id);
            if (caesars != null)
            {
                _context.Caesars.Remove(caesars);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaesarsExists(int id)
        {
          return (_context.Caesars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
