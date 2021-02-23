using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;

namespace ServiceLibrary.Services
{
    public class GbpDataService: EntityService<GbpData>, IGbpDataService
    {
        private readonly ICotDataContext _ctx;
        public GbpDataService(ICotDataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
