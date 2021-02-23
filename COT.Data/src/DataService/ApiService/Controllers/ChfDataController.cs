using System.Linq;
using System.Threading.Tasks;
using ApiService.Controllers.AbstractControllers;
using Microsoft.AspNetCore.Mvc;
using ServiceLibrary.Interfaces;

namespace ApiService.Controllers
{
    public class ChfDataController : BasicApiController
    {
        public ChfDataController(IChfDataService chfDataService) : base(chfDataService)
        {
        }

        // GET: ChfData
        public IActionResult Index()
        {
            return View(_chfDataService.Get().ToList());
        }

        // GET: ChfData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chfData = await _chfDataService.GetById(id.Value);
            if (chfData == null)
            {
                return NotFound();
            }

            return View(chfData);
        }

        // GET: ChfData/Create
        public IActionResult Create()
        {
            return View();
        }
    }

}
