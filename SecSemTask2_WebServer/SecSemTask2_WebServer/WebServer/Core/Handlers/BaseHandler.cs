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
    public abstract class BaseHandler : IWebHandler
    {
        protected Socket clientSocket;
        protected string filePath;

        private readonly Encoding charEncoder = Encoding.UTF8;
        protected readonly Logger logger;
        public BaseHandler(Socket clientSocket, string filePath, Logger logger)
        {
            this.logger = logger;
            this.clientSocket = clientSocket;
            this.filePath = filePath;
        }

        public abstract void Handle(List<string> avaliableRoots = null);



        protected void SendOkResponse(byte[] bContent, string contentType)
        {
            SendResponse(bContent, "200 OK", contentType);
        }

        protected void SendResponse(string strContent, string responseCode,
                                  string contentType)
        {
            byte[] bContent = charEncoder.GetBytes(strContent);
            SendResponse( bContent, responseCode, contentType);
        }

        protected void SendResponse(byte[] bContent, string responseCode, string contentType)
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
                if(bContent.Length > 10240)
                {
                    for (int i = 0; i < bContent.Length; i += 10240)
                    {
                        clientSocket.Send(bContent.Skip(i).Take(10240).ToArray());
                    }
                }
                else
                {
                    clientSocket.Send(bContent);
                }
                
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
            finally
            {
                Interrupt();
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
