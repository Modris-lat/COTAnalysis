using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;

namespace ServiceLibrary.Services
{
    public class ChfDataService: EntityService<ChfData>, IChfDataService
    {
        private readonly ICotDataContext _ctx;
        public ChfDataService(ICotDataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
