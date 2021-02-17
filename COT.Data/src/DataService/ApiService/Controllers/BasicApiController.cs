using CoreLibrary.Interfaces;
using DataLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ServiceLibrary.Interfaces;

namespace ApiService.Controllers
{
    public class BasicApiController : Controller
    {
        protected readonly IRawCotDataService _rawCotDataService;

        public BasicApiController(IRawCotDataService rawCotDataService)
        {
            _rawCotDataService = rawCotDataService;
        }
    }
}
