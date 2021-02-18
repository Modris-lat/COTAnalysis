using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary.Interfaces;
using CoreLibrary.Models;
using CoreLibrary.Services;
using CoreLibrary.Static;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;

namespace ServiceLibrary.Services
{
    public class ProcessDataService: IProcessDataService
    {
        private readonly IDownloadRawCotData _downloadData;
        private readonly IRawCotDataService _rawDataService;

        public ProcessDataService(
            IRawCotDataService rawDataService, 
            IDownloadRawCotData downloadData)
        {
            _rawDataService = rawDataService;
            _downloadData = downloadData;
        }

        public async Task<ServiceResult> SaveRawData()
        {
            var data = await _downloadData.Download(RawCotDataUrl.UrlList);
            var rawData = new RawCotData
            {
                Date = DateTime.Now,
                ChicagoExchange = data["currency"],
                CommodityExchange = data["commodity"],
                IceExchange = data["ice"],
                NewYorkExchange = data["energy"]
            };
            return _rawDataService.Create(rawData);
        }

        public Task<ServiceResult> SaveRubData()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveChfData()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveBtcData()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveEurData()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveGbpData()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveNzdData()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveAudData()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveJpyData()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveCadData()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveUsdData()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveGoldData()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveSilverData()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveCrudeOilData()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SaveNatGasData()
        {
            throw new NotImplementedException();
        }
    }
}
