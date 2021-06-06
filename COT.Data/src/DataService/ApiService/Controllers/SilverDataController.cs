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
    public class SilverDataController : Controller
    {
        private readonly CotDataContext _context;

        public SilverDataController(CotDataContext context)
        {
            _context = context;
        }

        // GET: SilverData
        public async Task<IActionResult> Index()
        {
            return View(await _context.Silver.ToListAsync());
        }

        // GET: SilverData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var silverData = await _context.Silver
                .FirstOrDefaultAsync(m => m.Id == id);
            if (silverData == null)
            {
                return NotFound();
            }

            return View(silverData);
        }

        // GET: SilverData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SilverData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,NonCommercialsLong,NonCommercialsShort,NonCommercialsPercentLong,NonCommercialsPercentShort,NonCommercialsNetPositions,CommercialsLong,CommercialsShort,CommercialsPercentLong,CommercialsPercentShort,CommercialsNetPositions,TotalLong,TotalShort,TotalNetPositions,Id")] SilverData silverData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(silverData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(silverData);
        }

        // GET: SilverData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var silverData = await _context.Silver.FindAsync(id);
            if (silverData == null)
            {
                return NotFound();
            }
            return View(silverData);
        }

        // POST: SilverData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,NonCommercialsLong,NonCommercialsShort,NonCommercialsPercentLong,NonCommercialsPercentShort,NonCommercialsNetPositions,CommercialsLong,CommercialsShort,CommercialsPercentLong,CommercialsPercentShort,CommercialsNetPositions,TotalLong,TotalShort,TotalNetPositions,Id")] SilverData silverData)
        {
            if (id != silverData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(silverData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SilverDataExists(silverData.Id))
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
            return View(silverData);
        }

        // GET: SilverData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var silverData = await _context.Silver
                .FirstOrDefaultAsync(m => m.Id == id);
            if (silverData == null)
            {
                return NotFound();
            }

            return View(silverData);
        }

        // POST: SilverData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var silverData = await _context.Silver.FindAsync(id);
            _context.Silver.Remove(silverData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SilverDataExists(int id)
        {
            return _context.Silver.Any(e => e.Id == id);
        }
    }
}
