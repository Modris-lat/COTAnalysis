using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Services.Abstract;

namespace ServiceLibrary.Services
{
    public class BtcDataService: EntityService<BtcData>, IBtcDataService
    {
        private readonly ICotDataContext _ctx;
        public BtcDataService(ICotDataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
