using NLog;
using SecSemTask2_WebServer.WebServer.Core.HttpWriters;
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
using SecSemTask2_WebServer.WebServer.SDK;
using static SecSemTask2_WebServer.WebServer.Core.Utils.Helper;

namespace SecSemTask2_WebServer.WebServer.Core.Handlers
{
    public class ResponseHandler : IReqHandler
    {
        private string filePath;
        private readonly Logger logger;
        private IHttpWriter httpWriter;

        public ResponseHandler(Socket clientSocket, string filePath, Logger logger)
        {
            this.logger = logger;
            this.filePath = filePath;
            httpWriter = new HttpWriter(clientSocket, logger);
        }


        //TODO Simplify Code 


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

            var controller = contollers.First(contr => contr.Name == controllerName);

            Object instance = Activator.CreateInstance(controller);

            //var HttpMethod = controller.GetMethod(methodName).CustomAttributes.First().AttributeType.;

            IActionResult result = (IActionResult)controller.GetMethod(methodName).Invoke(instance, new Object[] { });


            httpWriter.SendResponse(File.ReadAllBytes(projectDir + "\\View\\" + filePath), "200 OK", "text/" + filePath.Split('.')[1]);

        }


        public void InvokeRouteHandler(IDictionary<string, object> urlParams)
        {

            string projectDir = Helper.GetProjectDir();

            string assemblyName = (new FileInfo(projectDir + "\\bin\\Debug\\ServerMain.exe")).FullName;
            byte[] assemblyBytes = File.ReadAllBytes(assemblyName);
            Assembly assembly = Assembly.Load(assemblyBytes);

            var contollers = assembly.GetTypes()
                .Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(Controller))).ToArray();


            var controllerName = filePath.Split('/')[1].FirstCharToUpper() + "Controller";
            var methodName = filePath.Split('/')[2].Split('.')[0].Split('?')[0].FirstCharToUpper();

            var controller = contollers.First(contr => contr.Name == controllerName);

            Object instance = Activator.CreateInstance(controller);
            
            // Check for params in uri
            
            if (urlParams.Keys.Count() == controller.GetMethod(methodName).GetParameters().Length)
            {
                foreach (var parameter in controller.GetMethod(methodName).GetParameters().ToArray())
                {
                    if (!urlParams.Keys.Contains(parameter.Name))
                    {
                        httpWriter.WriteClientError("Wrong names of params", "405 Method Not Allowed");
                        return;
                    }
                }
            }
            else
            {
                httpWriter.WriteClientError("You used wrong count params", "405 Method Not Allowed");
                return;
            }
            List<object> parameters = new List<object>();
            
            //creating sequence of parameters 
            foreach (var param in controller.GetMethod(methodName).GetParameters())
            {
                var key = urlParams.Keys.First(u => u.Equals(param.Name));
                parameters.Insert(parameters.Count, urlParams[key]);
            }

            
            try
            {
                IActionResult result = (IActionResult)controller.GetMethod(methodName).Invoke(instance, parameters.ToArray());
            }
            catch (ArgumentException e)
            {
                logger.Error(e, "Handle error - 404 error - created 400 response");
                httpWriter.WriteClientError();
            }
            catch (Exception e)
            {
                logger.Error(e, "Unhandled error while handling reques - created 500 response ");
                httpWriter.WriteServerError();
            }
            httpWriter.SendResponse(File.ReadAllBytes(projectDir + "\\View\\" + filePath), "200 OK", "text/" + filePath.Split('.')[1]);
        }

        public void Abort()
        {
            
        }
    }

}
