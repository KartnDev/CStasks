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
        private readonly Encoding charEncoder = Encoding.UTF8;

        public RequestController(string contentPath)
        {
            this.contentPath = contentPath;
        }

        private string ParseReqString(Socket clientSocket, int reqLen)
        {

            byte[] buffer = new byte[reqLen];
            int receivedBCount = clientSocket.Receive(buffer);
            return charEncoder.GetString(buffer, 0, receivedBCount);
        }


        public void HandleAsync(Socket clientSocket)
        {
            var strRecieved = this.ParseReqString(clientSocket, 10240);

            HttpStringParser httpMsgParser = new HttpStringParser(strRecieved);

            IWebHandler handler = null;

            if (httpMsgParser.isCorrect(new string[] { "GET", "POST" }))
            {

                var httpMethod = httpMsgParser.GetHttpMethod();
                var requestedFile = contentPath + httpMsgParser.GetRequestedFile().Replace('/', '\\');

                bool fileExists = File.Exists(requestedFile) || (httpMsgParser.GetRequestedFile() == '/'.ToString());

                if (!fileExists)
                {
                    handler = new ClientErrorHandler(clientSocket);
                }
                else if (httpMethod.Equals("GET") && fileExists)
                {
                    handler = new HttpGetHandler(clientSocket, requestedFile);
                }
                else if (httpMethod.Equals("POST") && fileExists)
                {
                    handler = new HttpPostHandler(clientSocket, requestedFile);
                }
                else
                {
                    handler = new ServerErrorHandler(clientSocket);
                }
            }
            else
            {
                handler = new ClientErrorHandler(clientSocket);
            }

            try
            {
                handler.Handle();
            } 
            catch (SocketException e)
            {

            }
            catch (FileNotFoundException e)
            {

            }
        }
    }
}
