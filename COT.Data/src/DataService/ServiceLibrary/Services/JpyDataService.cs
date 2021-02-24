using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Services.Abstract;

namespace ServiceLibrary.Services
{
    public class JpyDataService: EntityService<JpyData>, IJpyDataService
    {
        private readonly ICotDataContext _ctx;
        public JpyDataService(ICotDataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
