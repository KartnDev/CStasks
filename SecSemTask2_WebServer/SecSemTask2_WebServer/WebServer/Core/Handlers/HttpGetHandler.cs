using NLog;
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
        public HttpGetHandler(Socket clientSocket, string fileName, Logger logger) : base(clientSocket, fileName, logger)
        {
        }

        public override void Handle()
        {
            if (filePath.Contains('.'))
            {
                this.SendOkResponse(File.ReadAllBytes(filePath), "text/" + filePath.Split('.')[1]);
            }
            else
            {
                this.SendOkResponse(File.ReadAllBytes(filePath + "index.html"), "text/html");
            }
        }
    }
}
