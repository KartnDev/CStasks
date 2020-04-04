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

            string assemblyName = (new FileInfo(projectDir + "\\bin\\server\\ServerMain.exe")).FullName;
            byte[] assemblyBytes = File.ReadAllBytes(assemblyName);
            Assembly assembly = Assembly.Load(assemblyBytes);

            var contollers = assembly.GetTypes()
                .Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(Controller))).ToArray();


            var controllerName = filePath.Split('/')[1].FirstCharToUpper() + "Controller";
            var methodName = filePath.Split('/')[2].Split('.')[0].FirstCharToUpper();

            var controller = contollers.First(contr => contr.Name  == controllerName);

            Object instance = Activator.CreateInstance(controller);


            controller.GetMethod(methodName).Invoke(instance, null);
        }
    }

}
