using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLibrary.Exceptions;
using CoreLibrary.Interfaces;
using CoreLibrary.Models;
using CoreLibrary.Services;
using CoreLibrary.Static;
using ServiceLibrary.Interfaces;

namespace ServiceLibrary.Services
{
    public class ProcessDataService: DataService, IProcessDataService
    {
        public ProcessDataService(
            IRawCotDataService rawDataService, IDownloadRawCotData downloadData, IFilterData filter,
            IRubDataService rubDataService, IChfDataService chfDataService, IBtcDataService btcDataService,
            IEurDataService eurDataService, IGbpDataService gbpDataService, IAudDataService audDataService,
            INzdDataService nzdDataService, ICadDataService cadDataService, IJpyDataService jpyDataService,
            IGoldDataService goldDataService, ISilverDataService silverDataService, ICrudeOilDataService crudeOilDataService,
            INatGasDataService natGasDataService, IUsdDataService usdDataService):
            base(rawDataService, downloadData, filter, rubDataService, chfDataService, btcDataService, 
                eurDataService, gbpDataService, audDataService, nzdDataService, cadDataService, 
                jpyDataService, goldDataService, silverDataService, crudeOilDataService, natGasDataService,
                usdDataService)
        {
        }

        public async Task<ServiceResult> SaveRawData(DateTime date)
        {
            var data = await _downloadData.Download(RawCotDataUrl.UrlList);
            var rawData = new RawCotData
            {
                Date = date,
                ChicagoExchange = data[DataType.Currency],
                CommodityExchange = data[DataType.Commodity],
                IceExchange = data[DataType.Ice],
                NewYorkExchange = data[DataType.Energy]
            };
            return _rawDataService.Create(rawData);
        }

        public IEnumerable<ServiceResult> SaveAll(DateTime date)
        {
            var list = new List<ServiceResult> { };
            var resultSaveRubData = SaveRubData(date);
            list.Add(resultSaveRubData);
            var resultSaveChfData = SaveChfData(date);
            list.Add(resultSaveChfData);
            return list;
        }

        public ServiceResult SaveRubData(DateTime date)
        {
            var data = GetData(date, DataType.Currency, Symbols.Rub);
            RubData rubData = GetData(data, new RubData());
            rubData.Date = date;
            var result = _rubDataService.Create(rubData);
            return result;
        }

        public ServiceResult SaveChfData(DateTime date)
        {
            var data = GetData(date, DataType.Currency, Symbols.Chf);
            ChfData chfData = GetData(data, new ChfData());
            chfData.Date = date;
            var result = _chfDataService.Create(chfData);
            return result;
        }

        public ServiceResult SaveBtcData(DateTime date)
        {
            var data = GetData(date, DataType.Currency, Symbols.Btc);
            BtcData btcData = GetData(data, new BtcData());
            btcData.Date = date;
            var result = _btcDataService.Create(btcData);
            return result;
        }

        public ServiceResult SaveEurData(DateTime date)
        {
            var data = GetData(date, DataType.Currency, Symbols.Eur);
            EurData eurData = GetData(data, new EurData());
            eurData.Date = date;
            var result = _eurDataService.Create(eurData);
            return result;
        }

        public ServiceResult SaveGbpData(DateTime date)
        {
            var data = GetData(date, DataType.Currency, Symbols.Gbp);
            GbpData gbpData = GetData(data, new GbpData());
            gbpData.Date = date;
            var result = _gbpDataService.Create(gbpData);
            return result;
        }

        public ServiceResult SaveNzdData(DateTime date)
        {
            var data = GetData(date, DataType.Currency, Symbols.Nzd);
            NzdData nzdData = GetData(data, new NzdData());
            nzdData.Date = date;
            var result = _nzdDataService.Create(nzdData);
            return result;
        }

        public ServiceResult SaveAudData(DateTime date)
        {
            var data = GetData(date, DataType.Currency, Symbols.Aud);
            AudData audData = GetData(data, new AudData());
            audData.Date = date;
            var result = _audDataService.Create(audData);
            return result;
        }

        public ServiceResult SaveJpyData(DateTime date)
        {
            var data = GetData(date, DataType.Currency, Symbols.Jpy);
            JpyData jpyData = GetData(data, new JpyData());
            jpyData.Date = date;
            var result = _jpyDataService.Create(jpyData);
            return result;
        }

        public ServiceResult SaveCadData(DateTime date)
        {
            var data = GetData(date, DataType.Currency, Symbols.Cad);
            CadData cadData = GetData(data, new CadData());
            cadData.Date = date;
            var result = _cadDataService.Create(cadData);
            return result;
        }

        public ServiceResult SaveUsdData(DateTime date)
        {
            var data = GetData(date, DataType.Ice, Symbols.Usd);
            UsdData usdData = GetData(data, new UsdData());
            usdData.Date = date;
            var result = _usdDataService.Create(usdData);
            return result;
        }

        public ServiceResult SaveGoldData(DateTime date)
        {
            var data = GetData(date, DataType.Commodity, Symbols.Gold);
            GoldData goldData = GetData(data, new GoldData());
            goldData.Date = date;
            var result = _goldDataService.Create(goldData);
            return result;
        }

        public ServiceResult SaveSilverData(DateTime date)
        {
            var data = GetData(date, DataType.Commodity, Symbols.Silver);
            SilverData silverData = GetData(data, new SilverData());
            silverData.Date = date;
            var result = _silverDataService.Create(silverData);
            return result;
        }

        public ServiceResult SaveCrudeOilData(DateTime date)
        {
            var data = GetData(date, DataType.Energy, Symbols.CrudeOil);
            CrudeOilData crudeOilData = GetData(data, new CrudeOilData());
            crudeOilData.Date = date;
            var result = _crudeOilDataService.Create(crudeOilData);
            return result;
        }

        public ServiceResult SaveNatGasData(DateTime date)
        {
            var data = GetData(date, DataType.Energy, Symbols.NatGas);
            NatGasData natGasData = GetData(data, new NatGasData());
            natGasData.Date = date;
            var result = _natGasDataService.Create(natGasData);
            return result;
        }

        IList<int> GetData(DateTime date, string exchange, string symbol)
        {
            var rawDataList = _rawDataService.Get();
            var rawData = rawDataList.SingleOrDefault(data => 
                data.Date.Date == date.Date);
            if (rawData == null)
            {
                throw new CotDataNotFoundException($"Data for date {date} not found.");
            }
            if (exchange == DataType.Currency)
            {
                return _filter.Filter(rawData.ChicagoExchange, symbol);
            }

            if (exchange == DataType.Commodity)
            {
                return _filter.Filter(rawData.CommodityExchange, symbol);
            }

            if (exchange == DataType.Ice)
            {
                return _filter.Filter(rawData.IceExchange, symbol);
            }
            if (exchange == DataType.Energy)
            {
                return _filter.Filter(rawData.NewYorkExchange, symbol);
            }
            return new List<int>{};
        }
        double CalculatePercentage(int baseNumber, int addNumber)
        {
            double result = ((double)baseNumber / (baseNumber + addNumber)) * 100;
            return Math.Round(result);
        }

        T GetData<T>(IList<int> data, T entity) where T: CotDataDb
        {
            entity.NonCommercialsLong = data[0];
            entity.NonCommercialsShort = data[1];
            entity.NonCommercialsPercentLong = CalculatePercentage(data[0], data[1]);
            entity.NonCommercialsPercentShort = CalculatePercentage(data[1], data[0]);
            entity.NonCommercialsNetPositions = data[0] - data[1];
            entity.CommercialsLong = data[3];
            entity.CommercialsShort = data[4];
            entity.CommercialsPercentLong = CalculatePercentage(data[3], data[4]);
            entity.CommercialsPercentShort = CalculatePercentage(data[4], data[3]);
            entity.CommercialsNetPositions = data[3] - data[4];
            entity.TotalLong = data[0] + data[3];
            entity.TotalShort = data[1] + data[4];
            entity.TotalNetPositions = entity.TotalLong - entity.TotalShort;

            return entity;
        }
    }
}
