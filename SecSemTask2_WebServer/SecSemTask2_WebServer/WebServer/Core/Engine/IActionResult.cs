using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Routers
{
    public interface IActionResult
    {
        Object[] GetParams();
    }
}
