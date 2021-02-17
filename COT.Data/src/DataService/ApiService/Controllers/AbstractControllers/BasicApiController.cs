using Microsoft.AspNetCore.Mvc;
using ServiceLibrary.Interfaces;

namespace ApiService.Controllers.AbstractControllers
{
    public abstract class BasicApiController : Controller
    {
        protected readonly IRawCotDataService _rawCotDataService;

        public BasicApiController(IRawCotDataService rawCotDataService)
        {
            _rawCotDataService = rawCotDataService;
        }
    }
}
