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
        internal string CurrentMethodName { get; private set; }
        internal string CurrentControllerName { get; private set; }

        internal ActionResult(string currentMethodName, string currentControllerName)
        {
            this.CurrentMethodName = currentMethodName;
            this.CurrentControllerName = currentControllerName;
        }

        public string GetHtmlName()
        {
            return CurrentControllerName + "\\" + CurrentMethodName + ".html";
        }

    }
}
