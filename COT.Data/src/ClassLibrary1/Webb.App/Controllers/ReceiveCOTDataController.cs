using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webb.App.Controllers
{
    public class ReceiveCOTDataController : Controller
    {
        [HttpPost]
        public IActionResult ReceiveData()
        {
            return View();
        }
    }
}
