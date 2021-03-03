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
            try
            {
                var date = DateTime.Parse(request.Date).Date;
                if (request.Command == ControllerCommands.Download)
                {
                    var result = await _processData.SaveRawData(date);
                    return Ok(result);
                }
                if (request.Command == $"{ControllerCommands.Download} and {ControllerCommands.SaveAll}")
                {
                    await _processData.SaveRawData(date);
                    var result = _processData.SaveAll(date);
                    return Ok(result);
                }

                return NotFound(ControllerCommands.InvalidCommand);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("all")]
        public IActionResult PostAll(SaveRequest request)
        {
            if (request.Command == ControllerCommands.SaveAll)
            {
                try
                {
                    var date = DateTime.Parse(request.Date).Date;
                    var result = _processData.SaveAll(date);
                    return Ok(result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
                
            }

            return NotFound(ControllerCommands.InvalidCommand);
        }
    }
}
