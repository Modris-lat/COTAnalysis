using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApiService.Controllers.AbstractControllers;
using ApiService.Models;
using ServiceLibrary.Interfaces;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbServiceController : BaseDbController
    {
        public DbServiceController(IProcessDataService processData): 
            base(processData){ }

        [HttpPost("{download}")]
        public async Task<IActionResult> PostRawData(string download)
        {
            var date = DateTime.Now;
            if (download == "download")
            {
                var result = await _processData.SaveRawData(date);
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("rub")]
        public IActionResult PostRubData(SaveRequest saveRub)
        {
            try
            {
                var date = DateTime.Parse(saveRub.Date);
                if (saveRub.Command == "save")
                {
                    var result = _processData.SaveRubData(date);
                    return Ok(result);
                }

                return NotFound();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
