using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;

namespace ServiceLibrary.Services
{
    public class SilverDataService: EntityService<SilverData>, ISilverDataService
    {
        private readonly ICotDataContext _ctx;
        public SilverDataService(ICotDataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
