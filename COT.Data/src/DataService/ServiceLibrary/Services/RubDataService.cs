using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;

namespace ServiceLibrary.Services
{
    public class RubDataService: EntityService<RubData>, IRubDataService
    {
        private readonly ICotDataContext _ctx;

        public RubDataService(ICotDataContext ctx): base(ctx)
        {
            _ctx = ctx;
        }
    }
}
