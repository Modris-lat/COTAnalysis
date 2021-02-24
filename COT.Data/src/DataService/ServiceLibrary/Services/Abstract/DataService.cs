using CoreLibrary.Interfaces;
using ServiceLibrary.Interfaces;

namespace ServiceLibrary.Services.Abstract
{
    public abstract class DataService
    {
        protected readonly IDownloadRawCotData _downloadData;
        protected readonly IRawCotDataService _rawDataService;
        protected readonly IFilterData _filter;
        protected readonly IRubDataService _rubDataService;
        protected readonly IChfDataService _chfDataService;
        protected readonly IBtcDataService _btcDataService;
        protected readonly IEurDataService _eurDataService;
        protected readonly IGbpDataService _gbpDataService;
        protected readonly IAudDataService _audDataService;
        protected readonly INzdDataService _nzdDataService;
        protected readonly ICadDataService _cadDataService;
        protected readonly IJpyDataService _jpyDataService;
        protected readonly IGoldDataService _goldDataService;
        protected readonly ISilverDataService _silverDataService;
        protected readonly ICrudeOilDataService _crudeOilDataService;
        protected readonly INatGasDataService _natGasDataService;
        protected readonly IUsdDataService _usdDataService;

        public DataService(
            IRawCotDataService rawDataService,
            IDownloadRawCotData downloadData,
            IFilterData filter,
            IRubDataService rubDataService,
            IChfDataService chfDataService,
            IBtcDataService btcDataService,
            IEurDataService eurDataService,
            IGbpDataService gbpDataService,
            IAudDataService audDataService,
            INzdDataService nzdDataService,
            ICadDataService cadDataService,
            IJpyDataService jpyDataService,
            IGoldDataService goldDataService,
            ISilverDataService silverDataService,
            ICrudeOilDataService crudeOilDataService,
            INatGasDataService natGasDataService,
            IUsdDataService usdDataService)
        {
            _rawDataService = rawDataService;
            _downloadData = downloadData;
            _filter = filter;
            _rubDataService = rubDataService;
            _chfDataService = chfDataService;
            _btcDataService = btcDataService;
            _eurDataService = eurDataService;
            _gbpDataService = gbpDataService;
            _audDataService = audDataService;
            _nzdDataService = nzdDataService;
            _cadDataService = cadDataService;
            _jpyDataService = jpyDataService;
            _goldDataService = goldDataService;
            _silverDataService = silverDataService;
            _crudeOilDataService = crudeOilDataService;
            _natGasDataService = natGasDataService;
            _usdDataService = usdDataService;
        }
    }
}
