using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Handlers
{
    public abstract class BaseHandler : IWebHandler
    {
        protected Socket clientSocket;
        protected string filePath;

        private readonly Encoding charEncoder = Encoding.UTF8;

        public BaseHandler(Socket clientSocket, string filePath)
        {
            this.clientSocket = clientSocket;
            this.filePath = filePath;
        }

        public abstract void Handle();



        protected void SendOkResponse(Socket clientSocket, byte[] bContent, string contentType)
        {
            SendResponse(clientSocket, bContent, "200 OK", contentType);
        }

        protected void SendResponse(Socket clientSocket, string strContent, string responseCode,
                                  string contentType)
        {
            byte[] bContent = charEncoder.GetBytes(strContent);
            SendResponse(clientSocket, bContent, responseCode, contentType);
        }

        protected void SendResponse(Socket clientSocket, byte[] bContent, string responseCode, string contentType)
        {
            try
            {
                byte[] bHeader = charEncoder.GetBytes(
                                    "HTTP/1.1 " + responseCode + "\r\n"
                                  + "Server: Cherkasov Simple Web Server\r\n"
                                  + "Content-Length: " + bContent.Length.ToString() + "\r\n"
                                  + "Connection: close\r\n"
                                  + "Content-Type: " + contentType + "\r\n\r\n");
                clientSocket.Send(bHeader);
                clientSocket.Send(bContent);
                clientSocket.Close();
            }
            catch (SocketException e)
            {
                // LOG EXCEPTION
            }
            catch (Exception e)
            {
                // LOG EXCEPTION
                throw;
            }
        }

        public void Interrupt()
        {
            clientSocket.Disconnect(true);
            clientSocket.Close();
            clientSocket.Dispose();
        }
    }
}
