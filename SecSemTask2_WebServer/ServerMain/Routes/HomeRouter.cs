using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Routers
{
    public class HomeRouter
    {
        [Router("/home/index.html", HttpMethodTypes.HttpGet)]
        public string Route()
        {
            return "HelloWorld";
        }

    }
}
