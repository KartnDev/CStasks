using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Handlers
{
    public class HttpPostHandler : BaseHandler
    {
        public HttpPostHandler(Socket clientSocket, string fileName) : base(clientSocket, fileName)
        {
        }

        public override void Handle()
        {
            throw new NotImplementedException();
        }
    }
}
