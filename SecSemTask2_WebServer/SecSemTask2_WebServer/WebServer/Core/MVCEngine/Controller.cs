using SecSemTask2_WebServer.WebServer.Core.Routers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SecSemTask2_WebServer.WebServer.Core.Engine
{
    public class Controller
    {
        protected IActionResult View(object[] args = null)
        {
            return new ActionResult(args);
        }
    }


}
