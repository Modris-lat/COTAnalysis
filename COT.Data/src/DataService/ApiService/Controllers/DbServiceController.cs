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
using ServiceLibrary.Interfaces;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbServiceController : BaseDbController
    {
        public DbServiceController(IProcessDataService processData): 
            base(processData){ }

        [HttpPost("{input}")]
        public async Task<IActionResult> Post(string input)
        {
            if (input == "download")
            {
                var result = await _processData.SaveRawData();
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
