using NLog;
using SecSemTask2_WebServer.WebServer.Core.Engine;
using SecSemTask2_WebServer.WebServer.Core.Routers;
using SecSemTask2_WebServer.WebServer.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static SecSemTask2_WebServer.WebServer.Core.Utils.Helper;

namespace SecSemTask2_WebServer.WebServer.Core.Handlers
{
    public class ResponseHandler
    {


        protected Socket clientSocket;
        protected string filePath;

        private readonly Encoding charEncoder = Encoding.UTF8;
        protected readonly Logger logger;

        public ResponseHandler(Socket clientSocket, string filePath, Logger logger,
            Dictionary<string, IEnumerable<string>> contollerMethodPathes, HttpMethodTypes httpMethod)
        {
            this.logger = logger;
            this.clientSocket = clientSocket;
            this.filePath = filePath;
        }


        public void InvokeRouteHandler()
        {

            string projectDir = Helper.GetProjectDir();

            string assemblyName = (new FileInfo(projectDir + "\\bin\\Debug\\ServerMain.exe")).FullName;
            byte[] assemblyBytes = File.ReadAllBytes(assemblyName);
            Assembly assembly = Assembly.Load(assemblyBytes);

            var contollers = assembly.GetTypes()
                .Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(Controller))).ToArray();


            var controllerName = filePath.Split('/')[1].FirstCharToUpper() + "Controller";
            var methodName = filePath.Split('/')[2].Split('.')[0].FirstCharToUpper();

            var controller = contollers.First(contr => contr.Name  == controllerName);

            Object instance = Activator.CreateInstance(controller);

            //var HttpMethod = controller.GetMethod(methodName).CustomAttributes.First().AttributeType.;
            
            IActionResult result = (IActionResult)controller.GetMethod(methodName).Invoke(instance, null);


            SendResponse(File.ReadAllBytes(projectDir + "\\View\\" + filePath), "200 OK", "text/" + filePath.Split('.')[1]);

        }



        protected void SendResponse(string strContent, string responseCode,
                                  string contentType)
        {
            byte[] bContent = charEncoder.GetBytes(strContent);
            SendResponse(bContent, responseCode, contentType);
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
