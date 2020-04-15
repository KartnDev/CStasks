using System;
using SecSemTask2_WebServer.WebServer.Core.Routers;

namespace SecSemTask2_WebServer.WebServer.SDK
{
    internal class ActionResult : IActionResult
    {
        internal Object[] Params { get; private set; } = null;
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
