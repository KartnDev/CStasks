using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Handlers
{
    public interface IReqHandler
    {
        void InvokeRouteHandler();
        void InvokeRouteHandler(IDictionary<string, object> urlParams);
    }
}
