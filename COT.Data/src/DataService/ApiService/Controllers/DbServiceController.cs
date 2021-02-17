using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiService.Controllers.AbstractControllers;
using CoreLibrary.Interfaces;
using CoreLibrary.Models;
using CoreLibrary.Static;
using DataLibrary.Interfaces;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbServiceController : BaseDbController
    {
        public DbServiceController(ICotDataContext dbService, IDownloadRawCotData getRawCotData): 
            base(dbService, getRawCotData){ }

        [HttpPost("{input}")]
        public async Task<IActionResult> Post(string input)
        {
            if (input == "download")
            {
                var data = await GetData();
                await _dbService.RawCotData.AddAsync(data);
                await _dbService.SaveAsync();
                return Ok(data);
            }

            return BadRequest();
        }

        async Task<RawCotData> GetData()
        {
            var data = await _getRawCotData.Download(RawCotDataUrl.UrlList);
            return new RawCotData
            {
                Date = DateTime.Now,
                ChicagoExchange = data["currency"],
                CommodityExchange = data["commodity"],
                IceExchange = data["ice"],
                NewYorkExchange = data["energy"]
            };
        }
    }
}
