using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreLibrary.Models;
using DataLibrary.Models;

namespace ApiService.Controllers
{
    public class BtcDataController : Controller
    {
        private readonly CotDataContext _context;

        public BtcDataController(CotDataContext context)
        {
            _context = context;
        }

        // GET: BtcData
        public async Task<IActionResult> Index()
        {
            return View(await _context.Btc.ToListAsync());
        }

        // GET: BtcData/Details/5
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

        // GET: BtcData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BtcData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,NonCommercialsLong,NonCommercialsShort,NonCommercialsPercentLong,NonCommercialsPercentShort,NonCommercialsNetPositions,CommercialsLong,CommercialsShort,CommercialsPercentLong,CommercialsPercentShort,CommercialsNetPositions,TotalLong,TotalShort,TotalNetPositions,Id")] BtcData btcData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(btcData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(btcData);
        }

        // GET: BtcData/Edit/5
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

        // POST: BtcData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,NonCommercialsLong,NonCommercialsShort,NonCommercialsPercentLong,NonCommercialsPercentShort,NonCommercialsNetPositions,CommercialsLong,CommercialsShort,CommercialsPercentLong,CommercialsPercentShort,CommercialsNetPositions,TotalLong,TotalShort,TotalNetPositions,Id")] BtcData btcData)
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

        // GET: BtcData/Delete/5
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

        // POST: BtcData/Delete/5
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
