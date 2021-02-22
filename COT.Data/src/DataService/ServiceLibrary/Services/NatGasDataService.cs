using System;
using System.Collections.Generic;
using System.Text;
using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;

namespace ServiceLibrary.Services
{
    public class NatGasDataService: EntityService<NatGasData>, INatGasDataService
    {
        private readonly ICotDataContext _ctx;
        public NatGasDataService(ICotDataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
