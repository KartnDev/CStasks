using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Handlers
{
    public class HttpGetHandler : BaseHandler
    {
        public HttpGetHandler(Socket clientSocket, string fileName) : base(clientSocket, fileName)
        {
        }

        public override void Handle()
        {
            File.ReadAllBytes(filePath);


            this.SendOkResponse(clientSocket, null, "text/html");
        }
    }
}
