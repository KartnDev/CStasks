using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Routers
{
    public enum HttpMethodTypes
    {
        HttpGet,
        HttpPost,
        HttpServerError,
        HttpClientError
    }
}
