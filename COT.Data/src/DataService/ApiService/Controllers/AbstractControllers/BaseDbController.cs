using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLibrary.Interfaces;
using DataLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers.AbstractControllers
{
    public class BaseDbController: ControllerBase
    {
        protected readonly ICotDataContext _dbService;
        protected readonly IDownloadRawCotData _getRawCotData;

        public BaseDbController(ICotDataContext dbService, IDownloadRawCotData getRawCotData)
        {
            _dbService = dbService;
            _getRawCotData = getRawCotData;
        }
    }
}
