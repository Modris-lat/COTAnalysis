using System;
using System.Collections.Generic;
using System.Text;
using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;

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
