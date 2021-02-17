using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreLibrary.Models;
using DataLibrary.Models;

namespace ApiService.Controllers
{
    public class CadDatasController : Controller
    {
        private readonly CotDataContext _context;

        public CadDatasController(CotDataContext context)
        {
            _context = context;
        }

        // GET: CadDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cad.ToListAsync());
        }

        // GET: CadDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadData = await _context.Cad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadData == null)
            {
                return NotFound();
            }

            return View(cadData);
        }

        // GET: CadDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Long,Short,PercentLong,PercentShort,NetPositions,Id")] CadData cadData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadData);
        }

        // GET: CadDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadData = await _context.Cad.FindAsync(id);
            if (cadData == null)
            {
                return NotFound();
            }
            return View(cadData);
        }

        // POST: CadDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,Long,Short,PercentLong,PercentShort,NetPositions,Id")] CadData cadData)
        {
            if (id != cadData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadDataExists(cadData.Id))
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
            return View(cadData);
        }

        // GET: CadDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadData = await _context.Cad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadData == null)
            {
                return NotFound();
            }

            return View(cadData);
        }

        // POST: CadDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadData = await _context.Cad.FindAsync(id);
            _context.Cad.Remove(cadData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadDataExists(int id)
        {
            return _context.Cad.Any(e => e.Id == id);
        }
    }
}
