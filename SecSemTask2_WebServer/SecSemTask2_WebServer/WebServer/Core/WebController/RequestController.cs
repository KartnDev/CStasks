using NLog;
using SecSemTask2_WebServer.WebServer.Core.Handlers;
using SecSemTask2_WebServer.WebServer.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.WebController
{
    public class RequestController
    {

        private string contentPath;
        private string secretToken;
        private readonly Encoding charEncoder = Encoding.UTF8;
        private readonly Logger logger;

        public RequestController(string contentPath, string secretToken, Logger instanceLogger)
        {
            this.logger = instanceLogger;
            this.contentPath = contentPath;
            this.secretToken = secretToken;
        }

        private string ParseReqString(Socket clientSocket, int reqLen)
        {
            byte[] buffer = new byte[reqLen];
            int receivedBCount = clientSocket.Receive(buffer);
            return charEncoder.GetString(buffer, 0, receivedBCount);
        }


        public int RedirectToHttpHandler(Socket clientSocket)
        {
            var strRecieved = this.ParseReqString(clientSocket, 10240);

            if(strRecieved.Contains("stop" + secretToken))
            {
                return 1;
            }

            HttpStringParser httpMsgParser = new HttpStringParser(strRecieved);

            IWebHandler handler = null;

            if (httpMsgParser.isCorrect(new string[] { "GET", "POST" }))
            {

                var httpMethod = httpMsgParser.GetHttpMethod();
                var requestedFile = contentPath + httpMsgParser.GetRequestedFile().Replace('/', '\\');

                bool fileExists = File.Exists(requestedFile) || (httpMsgParser.GetRequestedFile() == '/'.ToString());

                if (!fileExists)
                {
                    handler = new ClientErrorHandler(clientSocket, logger);
                }
                else if (httpMethod.Equals("GET") && fileExists)
                {
                    handler = new HttpGetHandler(clientSocket, requestedFile, logger);
                }
                else if (httpMethod.Equals("POST") && fileExists)
                {
                    handler = new HttpPostHandler(clientSocket, requestedFile, logger);
                }
                else
                {
                    handler = new ServerErrorHandler(clientSocket, logger);
                }
            }
            else
            {
                handler = new ClientErrorHandler(clientSocket, logger);
            }
            handler.Handle();

            return 0;
        }
    }
}
