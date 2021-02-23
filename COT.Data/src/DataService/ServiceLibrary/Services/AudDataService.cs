using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;

namespace ServiceLibrary.Services
{
    public class AudDataService: EntityService<AudData>, IAudDataService
    {
        private readonly ICotDataContext _ctx;
        public AudDataService(ICotDataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
