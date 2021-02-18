using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary.Services;

namespace ServiceLibrary.Interfaces
{
    public interface IProcessDataService
    {
        Task<ServiceResult> SaveRawData();
        Task<ServiceResult> SaveRubData();
        Task<ServiceResult> SaveChfData();
        Task<ServiceResult> SaveBtcData();
        Task<ServiceResult> SaveEurData();
        Task<ServiceResult> SaveGbpData();
        Task<ServiceResult> SaveNzdData();
        Task<ServiceResult> SaveAudData();
        Task<ServiceResult> SaveJpyData();
        Task<ServiceResult> SaveCadData();
        Task<ServiceResult> SaveUsdData();
        Task<ServiceResult> SaveGoldData();
        Task<ServiceResult> SaveSilverData();
        Task<ServiceResult> SaveCrudeOilData();
        Task<ServiceResult> SaveNatGasData();
    }
}
