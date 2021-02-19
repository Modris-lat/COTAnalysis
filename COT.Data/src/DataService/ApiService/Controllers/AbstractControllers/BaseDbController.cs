using Microsoft.AspNetCore.Mvc;
using ServiceLibrary.Interfaces;

namespace ApiService.Controllers.AbstractControllers
{
    public class BaseDbController: ControllerBase
    {
        protected readonly IProcessDataService _processData;
        public BaseDbController(IProcessDataService processData)
        {
            _processData = processData;
        }
    }
}
