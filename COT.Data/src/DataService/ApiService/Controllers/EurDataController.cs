using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreLibrary.Models;
using DataLibrary.Models;
using ServiceLibrary.Interfaces;

namespace ApiService.Controllers
{
    public class EurDataController : Controller
    {
        private readonly IEurDataService _eurDataService;

        public EurDataController(IEurDataService eurDataService)
        {
            _eurDataService = eurDataService;
        }

        // GET: EurData
        public IActionResult Index()
        {
            return View(_eurDataService.Get().ToList());
        }

        // GET: EurData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eurData = await _eurDataService.GetById(id.Value);
            if (eurData == null)
            {
                return NotFound();
            }

            return View(eurData);
        }
    }
}
