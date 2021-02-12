using System.Threading.Tasks;
using CoreLibrary.Models;
using CoreLibrary.Services;

namespace CoreLibrary.Interfaces
{
    public interface ICotDataService: IEntityService<CotDataDb>
    {
        Task<ServiceResult> AddData(CotDataDb cotData);
        Task<bool> DataExists(CotDataDb cotData);
        Task<ServiceResult> DeleteData(string date);
        Task<CotDataDb> GetDataByDate(string date);
    }
}
