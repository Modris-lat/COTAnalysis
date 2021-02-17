using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreLibrary.Models;
using DataLibrary.Models;

namespace ApiService.Controllers
{
    public class BtcDatasController : Controller
    {
        private readonly CotDataContext _context;

        public BtcDatasController(CotDataContext context)
        {
            _context = context;
        }

        // GET: BtcDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Btc.ToListAsync());
        }

        // GET: BtcDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var btcData = await _context.Btc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (btcData == null)
            {
                return NotFound();
            }

            return View(btcData);
        }

        // GET: BtcDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BtcDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Long,Short,PercentLong,PercentShort,NetPositions,Id")] BtcData btcData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(btcData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(btcData);
        }

        // GET: BtcDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var btcData = await _context.Btc.FindAsync(id);
            if (btcData == null)
            {
                return NotFound();
            }
            return View(btcData);
        }

        // POST: BtcDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,Long,Short,PercentLong,PercentShort,NetPositions,Id")] BtcData btcData)
        {
            if (id != btcData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(btcData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BtcDataExists(btcData.Id))
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
            return View(btcData);
        }

        // GET: BtcDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var btcData = await _context.Btc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (btcData == null)
            {
                return NotFound();
            }

            return View(btcData);
        }

        // POST: BtcDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var btcData = await _context.Btc.FindAsync(id);
            _context.Btc.Remove(btcData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BtcDataExists(int id)
        {
            return _context.Btc.Any(e => e.Id == id);
        }
    }
}
