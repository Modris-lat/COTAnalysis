using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreLibrary.Models;
using DataLibrary.Models;

namespace ApiService.Controllers
{
    public class ChfDatasController : Controller
    {
        private readonly CotDataContext _context;

        public ChfDatasController(CotDataContext context)
        {
            _context = context;
        }

        // GET: ChfDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chf.ToListAsync());
        }

        // GET: ChfDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chfData = await _context.Chf
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chfData == null)
            {
                return NotFound();
            }

            return View(chfData);
        }

        // GET: ChfDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChfDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Long,Short,PercentLong,PercentShort,NetPositions,Id")] ChfData chfData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chfData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chfData);
        }

        // GET: ChfDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chfData = await _context.Chf.FindAsync(id);
            if (chfData == null)
            {
                return NotFound();
            }
            return View(chfData);
        }

        // POST: ChfDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,Long,Short,PercentLong,PercentShort,NetPositions,Id")] ChfData chfData)
        {
            if (id != chfData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chfData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChfDataExists(chfData.Id))
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
            return View(chfData);
        }

        // GET: ChfDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chfData = await _context.Chf
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chfData == null)
            {
                return NotFound();
            }

            return View(chfData);
        }

        // POST: ChfDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chfData = await _context.Chf.FindAsync(id);
            _context.Chf.Remove(chfData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChfDataExists(int id)
        {
            return _context.Chf.Any(e => e.Id == id);
        }
    }
}
