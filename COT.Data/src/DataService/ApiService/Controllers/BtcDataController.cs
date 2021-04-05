using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceLibrary.Interfaces;

namespace ApiService.Controllers
{
    public class BtcDataController : Controller
    {
        private readonly IBtcDataService _btcDataService;

        public BtcDataController(IBtcDataService btcDataService)
        {
            _btcDataService = btcDataService;
        }

        // GET: BtcData
        public IActionResult Index()
        {
            return View(_btcDataService.Get().ToList());
        }

        // GET: BtcData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var btcData = await _btcDataService.GetById(id.Value);
            if (btcData == null)
            {
                return NotFound();
            }

            return View(btcData);
        }
    }
}
