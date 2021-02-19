using System;
using System.Threading.Tasks;
using CoreLibrary.Services;

namespace ServiceLibrary.Interfaces
{
    public interface IProcessDataService
    {
        Task<ServiceResult> SaveRawData(DateTime date);
        ServiceResult SaveRubData(DateTime date);
        Task<ServiceResult> SaveChfData(DateTime date);
        Task<ServiceResult> SaveBtcData(DateTime date);
        Task<ServiceResult> SaveEurData(DateTime date);
        Task<ServiceResult> SaveGbpData(DateTime date);
        Task<ServiceResult> SaveNzdData(DateTime date);
        Task<ServiceResult> SaveAudData(DateTime date);
        Task<ServiceResult> SaveJpyData(DateTime date);
        Task<ServiceResult> SaveCadData(DateTime date);
        Task<ServiceResult> SaveUsdData(DateTime date);
        Task<ServiceResult> SaveGoldData(DateTime date);
        Task<ServiceResult> SaveSilverData(DateTime date);
        Task<ServiceResult> SaveCrudeOilData(DateTime date);
        Task<ServiceResult> SaveNatGasData(DateTime date);
    }
}
