using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreLibrary.Models;
using DataLibrary.Models;

namespace ApiService.Controllers
{
    public class AudDatasController : Controller
    {
        private readonly CotDataContext _context;

        public AudDatasController(CotDataContext context)
        {
            _context = context;
        }

        // GET: AudDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aud.ToListAsync());
        }

        // GET: AudDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audData = await _context.Aud
                .FirstOrDefaultAsync(m => m.Id == id);
            if (audData == null)
            {
                return NotFound();
            }

            return View(audData);
        }

        // GET: AudDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AudDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Long,Short,PercentLong,PercentShort,NetPositions,Id")] AudData audData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(audData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(audData);
        }

        // GET: AudDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audData = await _context.Aud.FindAsync(id);
            if (audData == null)
            {
                return NotFound();
            }
            return View(audData);
        }

        // POST: AudDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,Long,Short,PercentLong,PercentShort,NetPositions,Id")] AudData audData)
        {
            if (id != audData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(audData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AudDataExists(audData.Id))
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
            return View(audData);
        }

        // GET: AudDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audData = await _context.Aud
                .FirstOrDefaultAsync(m => m.Id == id);
            if (audData == null)
            {
                return NotFound();
            }

            return View(audData);
        }

        // POST: AudDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var audData = await _context.Aud.FindAsync(id);
            _context.Aud.Remove(audData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AudDataExists(int id)
        {
            return _context.Aud.Any(e => e.Id == id);
        }
    }
}
