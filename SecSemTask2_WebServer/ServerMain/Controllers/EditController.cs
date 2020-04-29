using SecSemTask2_WebServer.WebServer.Core.Routers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecSemTask2_WebServer.WebServer.SDK;
using SecSemTask2_WebServer.WebServer.SDK.ControllerAttributes;
using SecSemTask2_WebServer.WebServer.SDK.HttpMethods;

namespace ServerMain.Controllers
{
    [Stateless]
    class EditController : Controller
    {
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
