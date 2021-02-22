using System;
using System.Threading.Tasks;
using CoreLibrary.Services;

namespace ServiceLibrary.Interfaces
{
    public interface IProcessDataService
    {
        Task<ServiceResult> SaveRawData(DateTime date);
        ServiceResult SaveRubData(DateTime date);
        ServiceResult SaveChfData(DateTime date);
        ServiceResult SaveBtcData(DateTime date);
        ServiceResult SaveEurData(DateTime date);
        ServiceResult SaveGbpData(DateTime date);
        ServiceResult SaveNzdData(DateTime date);
        ServiceResult SaveAudData(DateTime date);
        ServiceResult SaveJpyData(DateTime date);
        ServiceResult SaveCadData(DateTime date);
        ServiceResult SaveUsdData(DateTime date);
        ServiceResult SaveGoldData(DateTime date);
        ServiceResult SaveSilverData(DateTime date);
        ServiceResult SaveCrudeOilData(DateTime date);
        ServiceResult SaveNatGasData(DateTime date);
    }
}
