using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreLibrary.Interfaces;
using CoreLibrary.Models;
using DataLibrary.Models;

namespace ApiService.Controllers
{
    public class RawCotDatasController : Controller
    {
        private readonly CotDataContext _context;
        private IDownloadRawCotData _downloadData;

        public RawCotDatasController(CotDataContext context)
        {
            _context = context;
        }

        // GET: RawCotDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.RawCotData.ToListAsync());
        }

        // GET: RawCotDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rawCotData = await _context.RawCotData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rawCotData == null)
            {
                return NotFound();
            }

            return View(rawCotData);
        }

        // GET: RawCotDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RawCotDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,ChicagoExchange,CommodityExchange,Ice,NewYork,Id")] RawCotData rawCotData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rawCotData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rawCotData);
        }

        // GET: RawCotDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rawCotData = await _context.RawCotData.FindAsync(id);
            if (rawCotData == null)
            {
                return NotFound();
            }
            return View(rawCotData);
        }

        // POST: RawCotDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,ChicagoExchange,CommodityExchange,Ice,NewYork,Id")] RawCotData rawCotData)
        {
            if (id != rawCotData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rawCotData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RawCotDataExists(rawCotData.Id))
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
            return View(rawCotData);
        }

        // GET: RawCotDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rawCotData = await _context.RawCotData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rawCotData == null)
            {
                return NotFound();
            }

            return View(rawCotData);
        }

        // POST: RawCotDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rawCotData = await _context.RawCotData.FindAsync(id);
            _context.RawCotData.Remove(rawCotData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RawCotDataExists(int id)
        {
            return _context.RawCotData.Any(e => e.Id == id);
        }
    }
}
