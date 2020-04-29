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
        private readonly string filePath;
        private readonly Logger logger;
        private readonly IHttpWriter httpWriter;
        private readonly string projectDir;

        private readonly IEnumerable<Type> controllers;
        
        private IDictionary<string, string> redirectMap = null;
        
        public ResponseHandler(Socket clientSocket, string filePath, IEnumerable<Type> stateful, 
            IEnumerable<Controller> stateless, Logger logger)
        {
            this.controllers = controllers;
            this.logger = logger;
            this.filePath = filePath;
            this.projectDir = Helper.GetProjectDir();
            httpWriter = new HttpWriter(clientSocket, logger);
            
            

            
        }
        public void SendPage(string response, string pageUrl)
        {
            httpWriter.SendResponse(File.ReadAllBytes(projectDir + "\\View\\" + pageUrl.Replace('/', '\\')), 
                response, 
                "text/" + pageUrl.Split('.')[1]);
        }

        

        private void HandleClientError(string message="")
        {
            if (redirectMap["DefaultClientErrorPage"] != null)
            {
                SendPage("405 Method not allowed", redirectMap["DefaultClientErrorPage"]);
            }
            else
            {
                httpWriter.WriteClientError(message, "405 Method Not allowed");
            }
        }

        private void HandleServerError(string message)
        {
            if (redirectMap["DefaultServerErrorPage"] != null)
            {
                SendPage("501 Probably method not implemented", redirectMap["DefaultServerErrorPage"]);
            }
            else
            {
                httpWriter.WriteServerError(message, "501 method Not Implemented");
            }
        }

        public void RedirectToDefPage()
        {
            if (redirectMap["DefaultRedirectPage"] != null)
            {
                //SendPage("200 OK", redirectMap["DefaultRedirectPage"]);
                httpWriter.Redirect("/" + redirectMap["DefaultRedirectPage"]);
            }
            else
            {
                httpWriter.WriteClientError("Bad gateway!", "404 Bag Gateway");
            }
        }

        public void SetRedirectionMapWithCheckParams(IDictionary<string, string> redirectMap)
        {
            this.redirectMap = redirectMap;
        }



        
        
        
        
        //TODO Simplify Code 


        public void InvokeRouteHandler()
        {

            var controllerName = filePath.Split('/')[1].FirstCharToUpper() + "Controller";
            var methodName = filePath.Split('/')[2].Split('.')[0].FirstCharToUpper();

            var controller = controllers.First(contr => contr.Name == controllerName);

            Object instance = Activator.CreateInstance(controller);
            

            if (controller.GetMethod(methodName).GetParameters().Length != 0)
            {
                HandleClientError("This request must have params!");
                return;
            }

            IActionResult result = (IActionResult)controller.GetMethod(methodName).Invoke(instance, new Object[] { });


            SendPage("200 OK", filePath);

        }

        // TOO BIG 
        public void InvokeRouteHandler(IDictionary<string, object> urlParams)
        {


            var controllerName = filePath.Split('/')[1].FirstCharToUpper() + "Controller";
            var methodName = filePath.Split('/')[2].Split('.')[0].Split('?')[0].FirstCharToUpper();

            var controller = controllers.First(contr => contr.Name == controllerName);

            Object instance = Activator.CreateInstance(controller);
            
            
            if (urlParams.Keys.Count() == controller.GetMethod(methodName).GetParameters().Length)
            {
                foreach (var parameter in controller.GetMethod(methodName).GetParameters().ToArray())
                {
                    if (!urlParams.Keys.Contains(parameter.Name))
                    {
                        HandleClientError("Wrong names of params");
                        return;
                    }
                }
            }
            else
            {
                HandleClientError("You used wrong count params");
                return;
            }
            var parameters = new object[urlParams.Count];
            
            //creating sequence of parameters 
            int iter = 0;
            foreach (var param in controller.GetMethod(methodName).GetParameters())
            {
                var key = urlParams.Keys.First(u => u.Equals(param.Name));
                parameters[iter] = urlParams[key];
                iter++;
            }

            
            try
            {
                IActionResult result = (IActionResult)controller.GetMethod(methodName).Invoke(instance, parameters);
            }
            catch (ArgumentException e)
            {
                logger.Error(e, "Handle error - 404 error - created 400 response");
                HandleClientError("");
            }
            catch (Exception e)
            {
                logger.Error(e, "Unhandled error while handling reques - created 500 response ");
                HandleServerError("Server cannot response it");
            }
            SendPage("200 OK", filePath);
        }
        
    }

}
