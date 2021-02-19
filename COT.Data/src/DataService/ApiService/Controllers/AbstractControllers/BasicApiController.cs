using Microsoft.AspNetCore.Mvc;
using ServiceLibrary.Interfaces;

namespace ApiService.Controllers.AbstractControllers
{
    public abstract class BasicApiController : Controller
    {
        protected readonly IRawCotDataService _rawCotDataService;
        protected readonly IRubDataService _rubDataService;
        public BasicApiController(IRawCotDataService rawCotDataService)
        {
            _rawCotDataService = rawCotDataService;
        }

        public BasicApiController(IRubDataService rubDataService)
        {
            _rubDataService = rubDataService;
        }
    }
}
