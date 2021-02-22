using System;
using System.Collections.Generic;
using System.Text;
using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;

namespace ServiceLibrary.Services
{
    public class EurDataService: EntityService<EurData>, IEurDataService
    {
        private readonly ICotDataContext _ctx;
        public EurDataService(ICotDataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
