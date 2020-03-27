using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Handlers
{
    public class ServerErrorHandler : BaseHandler
    {
        public ServerErrorHandler(Socket clientSocket, string filePath) : base(clientSocket, filePath)
        {
        }

        public override void Handle()
        {
            throw new NotImplementedException();
        }



        private void NotImplemented(Socket clientSocket)
        {
            SendResponse(clientSocket, "<html><head><meta" +
                    "http - equiv =\"Content-Type\" content=\"text/html;" +
                    "charset = utf - 8\">" +
                    "</head><body><h2> Hello Web!" +
                    "Server </h2><div> 501 - Method Not" +
                    "Implemented </div></body></html>",

                    "501 Not Implemented", "text/html");
        }




    }
}
