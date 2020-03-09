using SecSemTask2_WebServer.WebServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerMain
{
    public class ServerMain
    {
        public static void Main(string[] args)
        {
            Server server = new Server(@"C:\Users\dmutp\source\CStasks\SecSemTask2_WebServer\ServerMain\Content");
            server.Start();
        }
    }
}
