using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApiService.Controllers.AbstractControllers;
using ServiceLibrary.Interfaces;

namespace ApiService.Controllers
{
    public class RubDataController : BasicApiController
    {
        public RubDataController(IRubDataService rubDataService) : base(rubDataService)
        {
        }
        public IActionResult Index()
        {
            return View(_rubDataService.Get());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rubData = await _rubDataService.GetById(id.Value);
            if (rubData == null)
            {
                return NotFound();
            }

            return View(rubData);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
