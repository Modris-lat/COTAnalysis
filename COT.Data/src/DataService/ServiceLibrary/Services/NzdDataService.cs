using System;
using System.Collections.Generic;
using System.Text;
using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;

namespace ServiceLibrary.Services
{
    public class NzdDataService: EntityService<NzdData>, INzdDataService
    {
        private readonly ICotDataContext _ctx;
        public NzdDataService(ICotDataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
