using Microsoft.AspNetCore.Mvc;
using ServiceLibrary.Interfaces;

namespace ApiService.Controllers.AbstractControllers
{
    public abstract class BasicApiController : Controller
    {
        protected readonly IRawCotDataService _rawCotDataService;
        protected readonly IRubDataService _rubDataService;
        protected readonly IChfDataService _chfDataService;
        protected readonly IBtcDataService _btcDataService;
        protected readonly IEurDataService _eurDataService;
        protected readonly IGbpDataService _gbpDataService;
        protected BasicApiController(IRawCotDataService rawCotDataService)
        {
            _rawCotDataService = rawCotDataService;
        }

        protected BasicApiController(IRubDataService rubDataService)
        {
            _rubDataService = rubDataService;
        }

        protected BasicApiController(IChfDataService chfDataService)
        {
            _chfDataService = chfDataService;
        }
        protected BasicApiController(IBtcDataService btcDataService)
        {
            _btcDataService = btcDataService;
        }
        protected BasicApiController(IEurDataService eurDataService)
        {
            _eurDataService = eurDataService;
        }
        protected BasicApiController(IGbpDataService gbpDataService)
        {
            _gbpDataService = gbpDataService;
        }
    }
}
