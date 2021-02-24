using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Services.Abstract;

namespace ServiceLibrary.Services
{
    public class CrudeOilDataService: EntityService<CrudeOilData>, ICrudeOilDataService
    {
        private readonly ICotDataContext _ctx;
        public CrudeOilDataService(ICotDataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
