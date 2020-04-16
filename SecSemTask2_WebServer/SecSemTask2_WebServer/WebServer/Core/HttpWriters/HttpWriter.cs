using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.HttpWriters
{
    public class HttpWriter : IHttpWriter
    {
        private Socket clientSocket;

        private readonly Encoding charEncoder = Encoding.UTF8;
        private readonly Logger logger;
        public HttpWriter(Socket clientSocket, Logger logger)
        {
            this.logger = logger;
            this.clientSocket = clientSocket;
        }



        public void SendResponse(string strContent, string responseCode,
                                  string contentType)
        {
            byte[] bContent = charEncoder.GetBytes(strContent);
            SendResponse(bContent, responseCode, contentType);
        }


        public void WriteClientError(string exceptionMessage, string responseCode)
        {
            SendResponse("<html><head><meta" +
                         "http - equiv =\"Content-Type\" content=\"text/html;" +
                         "charset = utf - 8\">" +
                         "</head><body><h2> Hello Web!" +
                         "Client Error </h2><div>" + exceptionMessage +
                         "</div></body></html>",

                responseCode, "text/html");
        }

        public void SendResponse(byte[] bContent, string responseCode, string contentType)
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
                if (bContent.Length > 10240)
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
                logger.Error(e, "Send response error..");
            }
            catch (Exception e)
            {
                logger.Error(e, "Send response unhandled error..");
                throw;
            }
            finally
            {
                Interrupt();
            }
        }

        public void WriteServerError()
        {
            SendResponse("<html><head><meta" +
                     "http - equiv =\"Content-Type\" content=\"text/html;" +
                     "charset = utf - 8\">" +
                     "</head><body><h2> Hello Web!" +
                     "Server Error </h2><div> 501 - Method Not" +
                     "Implemented </div></body></html>",

                     "501 Not Implemented", "text/html");
        }

        public void WriteServerError(string exceptionMessage, string responseCode)
        {
            SendResponse("<html><head><meta" +
                         "http - equiv =\"Content-Type\" content=\"text/html;" +
                         "charset = utf - 8\">" +
                         "</head><body><h2> Hello Web!" +
                         "Server </h2><div>" + exceptionMessage +
                         "</div></body></html>",

                responseCode, "text/html");
        }

        public void Redirect(string url)
        {
            try
            {
                byte[] bHeader = charEncoder.GetBytes(
                    "HTTP/1.1 " + "301	Moved Permanently" + "\r\n"
                    + "Location: "+ url + "\r\n" 
                    + "Server: Cherkasov Simple Web Server\r\n"
                    + "Connection: close\r\n");
                clientSocket.Send(bHeader);
            }
            catch (SocketException e)
            {
                logger.Error(e, "Send response error..");
            }
            catch (Exception e)
            {
                logger.Error(e, "Send response unhandled error..");
                throw;
            }
            finally
            {
                Interrupt();
            }
        }

        public void WriteClientError()
        {
            SendResponse("<html><head><meta" +
                      "http - equiv =\"Content-Type\" content=\"text/html;" +
                      "charset = utf - 8\">" +
                      "</head><body><h1> Hello Web!" +
                      "Server </h1><div> 404 - Method Not" +
                      "Found </div></body></html>",

                      "404 Not Found", "text/html");
        }

        public void Interrupt()
        {
            if (clientSocket != null)
            {
                clientSocket.Disconnect(true);
                clientSocket.Close();
                clientSocket.Dispose();
            }
        }

        
    }
}
