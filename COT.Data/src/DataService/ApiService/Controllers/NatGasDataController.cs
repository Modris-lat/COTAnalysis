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
    public class NatGasDataController : Controller
    {
        private readonly CotDataContext _context;

        public NatGasDataController(CotDataContext context)
        {
            _context = context;
        }

        // GET: NatGasData
        public async Task<IActionResult> Index()
        {
            return View(await _context.NaturalGas.ToListAsync());
        }

        // GET: NatGasData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natGasData = await _context.NaturalGas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (natGasData == null)
            {
                return NotFound();
            }

            return View(natGasData);
        }

        // GET: NatGasData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NatGasData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,NonCommercialsLong,NonCommercialsShort,NonCommercialsPercentLong,NonCommercialsPercentShort,NonCommercialsNetPositions,CommercialsLong,CommercialsShort,CommercialsPercentLong,CommercialsPercentShort,CommercialsNetPositions,TotalLong,TotalShort,TotalNetPositions,Id")] NatGasData natGasData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(natGasData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(natGasData);
        }

        // GET: NatGasData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natGasData = await _context.NaturalGas.FindAsync(id);
            if (natGasData == null)
            {
                return NotFound();
            }
            return View(natGasData);
        }

        // POST: NatGasData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,NonCommercialsLong,NonCommercialsShort,NonCommercialsPercentLong,NonCommercialsPercentShort,NonCommercialsNetPositions,CommercialsLong,CommercialsShort,CommercialsPercentLong,CommercialsPercentShort,CommercialsNetPositions,TotalLong,TotalShort,TotalNetPositions,Id")] NatGasData natGasData)
        {
            if (id != natGasData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(natGasData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NatGasDataExists(natGasData.Id))
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
            return View(natGasData);
        }

        // GET: NatGasData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natGasData = await _context.NaturalGas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (natGasData == null)
            {
                return NotFound();
            }

            return View(natGasData);
        }

        // POST: NatGasData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var natGasData = await _context.NaturalGas.FindAsync(id);
            _context.NaturalGas.Remove(natGasData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NatGasDataExists(int id)
        {
            return _context.NaturalGas.Any(e => e.Id == id);
        }
    }
}
