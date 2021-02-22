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
    public class ProcessDataService: IProcessDataService
    {
        private readonly IDownloadRawCotData _downloadData;
        private readonly IRawCotDataService _rawDataService;
        private readonly IFilterData _filter;
        private readonly IRubDataService _rubDataService;
        public ProcessDataService(
            IRawCotDataService rawDataService, 
            IDownloadRawCotData downloadData,
            IFilterData filter,
            IRubDataService rubDataService)
        {
            _rawDataService = rawDataService;
            _downloadData = downloadData;
            _filter = filter;
            _rubDataService = rubDataService;
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

        public ServiceResult SaveRubData(DateTime date)
        {
            var data = GetData(date, DataType.Currency, Symbols.Rub);
            RubData rubData = GetData(data, new RubData());
            var result = _rubDataService.Create(rubData);
            return result;
        }

        public Task<ServiceResult> SaveChfData(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveBtcData(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveEurData(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveGbpData(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveNzdData(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveAudData(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveJpyData(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveCadData(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveUsdData(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveGoldData(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveSilverData(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveCrudeOilData(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveNatGasData(DateTime date)
        {
            throw new NotImplementedException();
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
