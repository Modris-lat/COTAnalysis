using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;

namespace ServiceLibrary.Services
{
    public class UsdDataService: EntityService<UsdData>, IUsdDataService
    {
        private readonly ICotDataContext _ctx;
        public UsdDataService(ICotDataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
