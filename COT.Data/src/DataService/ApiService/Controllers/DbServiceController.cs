using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApiService.Controllers.AbstractControllers;
using ApiService.Models;
using ApiService.Static;
using ServiceLibrary.Interfaces;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbServiceController : BaseDbController
    {
        public DbServiceController(IProcessDataService processData): 
            base(processData){ }

        [HttpPost("raw")]
        public async Task<IActionResult> PostRawData(SaveRequest request)
        {
            if (request.Command == ControllerCommands.Download)
            {
                var date = DateTime.Parse(request.Date).Date;
                var result = await _processData.SaveRawData(date);
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("rub")]
        public IActionResult PostRubData(SaveRequest request)
        {
            try
            {
                if (request.Command == ControllerCommands.Save)
                {
                    var date = DateTime.Parse(request.Date).Date;
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
        [HttpPost("chf")]
        public IActionResult PostChfData(SaveRequest request)
        {
            try
            {
                if (request.Command == ControllerCommands.Save)
                {
                    var date = DateTime.Parse(request.Date).Date;
                    var result = _processData.SaveChfData(date);
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
