using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreLibrary.Models;
using DataLibrary.Models;

namespace ApiService.Controllers
{
    public class CrudeOilDatasController : Controller
    {
        private readonly CotDataContext _context;

        public CrudeOilDatasController(CotDataContext context)
        {
            _context = context;
        }

        // GET: CrudeOilDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CrudeOil.ToListAsync());
        }

        // GET: CrudeOilDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crudeOilData = await _context.CrudeOil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crudeOilData == null)
            {
                return NotFound();
            }

            return View(crudeOilData);
        }

        // GET: CrudeOilDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CrudeOilDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Long,Short,PercentLong,PercentShort,NetPositions,Id")] CrudeOilData crudeOilData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crudeOilData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crudeOilData);
        }

        // GET: CrudeOilDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crudeOilData = await _context.CrudeOil.FindAsync(id);
            if (crudeOilData == null)
            {
                return NotFound();
            }
            return View(crudeOilData);
        }

        // POST: CrudeOilDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,Long,Short,PercentLong,PercentShort,NetPositions,Id")] CrudeOilData crudeOilData)
        {
            if (id != crudeOilData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crudeOilData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrudeOilDataExists(crudeOilData.Id))
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
            return View(crudeOilData);
        }

        // GET: CrudeOilDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crudeOilData = await _context.CrudeOil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crudeOilData == null)
            {
                return NotFound();
            }

            return View(crudeOilData);
        }

        // POST: CrudeOilDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crudeOilData = await _context.CrudeOil.FindAsync(id);
            _context.CrudeOil.Remove(crudeOilData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrudeOilDataExists(int id)
        {
            return _context.CrudeOil.Any(e => e.Id == id);
        }
    }
}
