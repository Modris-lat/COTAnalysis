using System;
using System.Collections.Generic;
using System.Text;
using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;

namespace ServiceLibrary.Services
{
    public class GoldDataService: EntityService<GoldData>, IGoldDataService
    {
        private readonly ICotDataContext _ctx;
        public GoldDataService(ICotDataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
