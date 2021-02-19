using System.Threading.Tasks;
using ApiService.Controllers.AbstractControllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreLibrary.Models;
using ServiceLibrary.Interfaces;

namespace ApiService.Controllers
{
    public class RawCotDatasController : BasicApiController
    {
        public RawCotDatasController(IRawCotDataService rawCotDataService): base(rawCotDataService) { }

        // GET: RawCotDatas
        public IActionResult Index()
        {
            return View(_rawCotDataService.Get());
        }

        // GET: RawCotDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rawCotData = await _rawCotDataService.GetById(id.Value);
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
                _rawCotDataService.Create(rawCotData);
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

            var rawCotData = await _rawCotDataService.GetById(id.Value);
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
                    _rawCotDataService.Update(rawCotData);
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

            var rawCotData = await _rawCotDataService.GetById(id.Value);
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
            var rawCotData = await _rawCotDataService.GetById(id);
            _rawCotDataService.Delete(rawCotData);
            return RedirectToAction(nameof(Index));
        }

        private bool RawCotDataExists(int id)
        {
            return _rawCotDataService.Exists(id);
        }
    }
}
