using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Handlers
{
    public class ClientErrorHandler : BaseHandler
    {
        public ClientErrorHandler(Socket clientSocket) : base(clientSocket, null)
        {
        }

        public override void Handle()
        {
            SendResponse("<html><head><meta" +
                "http - equiv =\"Content-Type\" content=\"text/html;" +
                "charset = utf - 8\"></head><body><h2>Bad gateway! " +
                "Server </h2><div> 404 - Not" +
                "Found </div></body></html> ",

                "404 Not Found", "text/html");
        }
    }
}
