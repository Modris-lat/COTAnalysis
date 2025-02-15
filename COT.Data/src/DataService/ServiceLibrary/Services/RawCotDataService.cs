﻿using CoreLibrary.Models;
using DataLibrary.Interfaces;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Services.Abstract;

namespace ServiceLibrary.Services
{
    public class RawCotDataService: EntityService<RawCotData>, IRawCotDataService
    {
        private readonly ICotDataContext _ctx;
        public RawCotDataService(ICotDataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
