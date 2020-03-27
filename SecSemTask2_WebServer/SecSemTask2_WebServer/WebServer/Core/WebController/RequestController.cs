using SecSemTask2_WebServer.WebServer.Core.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.WebController
{
    public class RequestController
    {

        private string contentPath;
        private Encoding charEncoder = Encoding.UTF8;


        public RequestController(string contentPath)
        {
            this.contentPath = contentPath;
        }

        public void HandleTheRequest(Socket clientSocket)
        {
            byte[] buffer = new byte[10240];
            int receivedBCount = clientSocket.Receive(buffer);
            string strReceived = charEncoder.GetString(buffer, 0, receivedBCount);

            string httpMethod = strReceived.Substring(0, strReceived.IndexOf(" "));

            int start = strReceived.IndexOf(httpMethod) + httpMethod.Length + 1;
            int length = strReceived.LastIndexOf("HTTP") - start - 1;
            string requestedUrl = strReceived.Substring(start, length);

            string requestedFile;

            IWebHandler handler = null; 

            if (httpMethod.Equals("GET"))
            {
                handler = new HttpGetHandler();
                requestedFile = requestedUrl.Split('?')[0];
            }
            if (httpMethod.Equals("POST"))
            {
                handler = new HttpPostHandler();
            }
            else
            {
                handler = new ServerErrorHandler()

                NotImplemented(clientSocket);
                return;
            }

            requestedFile = requestedFile.Replace("/", "\\").Replace("\\..", ""); // Not to go back
            start = requestedFile.LastIndexOf('.') + 1;
            if (start > 0)
            {
                length = requestedFile.Length - start;
                string extension = requestedFile.Substring(start, length);

                if (extensions.ContainsKey(extension))
                {
                    if (File.Exists(contentPath + requestedFile))
                    {
                        SendOkResponse(clientSocket, File.ReadAllBytes(contentPath + requestedFile), extensions[extension]);
                    }
                    else
                    {
                        NotFound(clientSocket);
                    }
                }
            }
            else
            {
                // Если файл не указан, пробуем послать index.html
                // Вы можете добавить больше(например "default.html")
                if (requestedFile.Substring(length - 1, 1) != "\\")
                {
                    requestedFile += "\\";
                }
                if (File.Exists(contentPath + requestedFile + "index.html"))
                {
                    SendOkResponse(clientSocket, File.ReadAllBytes(contentPath + requestedFile + "\\index.htm"), "text/html");
                }
                else if (File.Exists(contentPath + requestedFile + "index.html"))
                {
                    SendOkResponse(clientSocket, File.ReadAllBytes(contentPath + requestedFile + "\\index.html"), "text/html");
                }
                else
                {
                    NotFound(clientSocket);
                }
            }
        }
}
