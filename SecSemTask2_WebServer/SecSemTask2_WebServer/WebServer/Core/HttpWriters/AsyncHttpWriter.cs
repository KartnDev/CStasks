using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using NLog;

namespace SecSemTask2_WebServer.WebServer.Core.HttpWriters
{
    internal class AsyncHttpWriter : IHttpWriter
    {
        private Socket clientSocket;

        private readonly Encoding charEncoder = Encoding.UTF8;
        private readonly Logger logger;

        private readonly SocketFlags flags = SocketFlags.Partial;
        public AsyncHttpWriter(Socket clientSocket, Logger logger)
        {
            this.logger = logger;
            this.clientSocket = clientSocket;
        }



        private void SendResponse(string strContent, string responseCode,
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

        
        public void SendResponse(byte[] bContent, string responseCode, string contentType, 
            Dictionary<string, string> cookies)
        {
            try
            {
                byte[] bHeader = charEncoder.GetBytes(WriterUtils.CreateStringHeader(contentType, 
                                                            responseCode, bContent.Length, cookies));
                
                clientSocket.Send(bHeader);
                if (bContent.Length > 10240)
                {
                    for (int i = 0; i < bContent.Length; i += 10240)
                    {
                        clientSocket.BeginSend(bContent.Skip(i).Take(10240).ToArray(), 
                            0, bContent.Length, flags, 
                            ar => logger.Info("End async (responsing)"), null);
                    }
                }
                else
                {
                    clientSocket.BeginSend(bContent, 0, bContent.Length, flags, 
                        ar => logger.Info("End async (responsing)"), null);
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
        
        
        public void SendResponse(byte[] bContent, string responseCode, string contentType)
        {
            try
            {
                byte[] bHeader = charEncoder.GetBytes(WriterUtils.CreateStringHeader(contentType, 
                                                            responseCode, 
                                                            bContent.Length));
                
                clientSocket.Send(bHeader);
                if (bContent.Length > 10240)
                {
                    for (int i = 0; i < bContent.Length; i += 10240)
                    {
                        clientSocket.BeginSend(bContent.Skip(i).Take(10240).ToArray(), 
                            0, bContent.Length, flags, 
                            ar => logger.Info("End async (responsing)"), null);
                    }
                }
                else
                {
                    clientSocket.BeginSend(bContent, 0, bContent.Length, flags, 
                        ar => logger.Info("End async (responsing)"), null);
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

                byte[] bHeader = charEncoder.GetBytes(WriterUtils.CreateStringHeader("text/html","300 Moved"));
                clientSocket.BeginSend(bHeader, 0, bHeader.Length, flags,
                    ar => logger.Info("End async send (redirect)"), null);
                
            }
            catch (SocketException e)
            {
                logger.Error(e, "Send response error..");
            }
            catch (Exception e)
            {
                logger.Fatal(e, "Send response unhandled error..");
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
                clientSocket.Disconnect(false);
                clientSocket.Close();
            }
        }
    }
}