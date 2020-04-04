using SecSemTask2_WebServer.WebServer.Core.Routers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Engine
{
    internal class ActionResult : IActionResult
    {
        public Object[] Params { get; private set; } = null;
        internal ActionResult(object[] args = null)
        {
            Params = args;
        }

        public object[] GetParams()
        {
            return Params;
        }
    }
}
