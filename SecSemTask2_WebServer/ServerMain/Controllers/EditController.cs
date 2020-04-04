using SecSemTask2_WebServer.WebServer.Core.Engine;
using SecSemTask2_WebServer.WebServer.Core.Routers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMain.Controllers
{
    class EditController : Controller
    {
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
