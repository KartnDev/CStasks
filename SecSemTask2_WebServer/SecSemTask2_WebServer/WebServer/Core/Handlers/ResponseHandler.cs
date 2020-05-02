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

// ReSharper disable PossibleNullReferenceException

namespace SecSemTask2_WebServer.WebServer.Core.Handlers
{
    internal class ResponseHandler : IReqHandler
    {
        private readonly string filePath;
        private readonly IEnumerable<Type> stateful;
        private readonly IEnumerable<Controller> stateless;
        private readonly Logger logger;
        private readonly IHttpWriter httpWriter;
        private readonly string projectDir;


        private IDictionary<string, string> redirectMap = null;

        public ResponseHandler(Socket clientSocket, string filePath, IEnumerable<Type> stateful,
            IEnumerable<Controller> stateless, Logger logger)
        {
            this.logger = logger;
            this.filePath = filePath;
            this.stateful = stateful;
            this.stateless = stateless;
            this.projectDir = Helper.GetProjectDir();
            httpWriter = new AsyncHttpWriter(clientSocket, logger);
        }

        private async void SendPage(string response, string pageUrl)
        {
            using (var reader = File.OpenText(projectDir + "\\View\\" + pageUrl.Replace('/', '\\')))
            {
                var onAsRead = reader.ReadToEndAsync();
                var fileText = await onAsRead;
                
                
                var cookies = new Dictionary<string, string>();
                cookies.Add("first", "12345667898");
                cookies.Add("second", "1");
                
                
                httpWriter.SendResponse(Encoding.UTF8.GetBytes(fileText),
                    response,
                    "text/" + pageUrl.Split('.')[1],
                    cookies);
            }
        }


        private void HandleClientError(string message = "")
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


        private Controller FindAndGetInstance()
        {
            var split = filePath.Split('/');

            foreach (var controller in stateless)
            {
                if (split[1].ToLower().Equals(controller.GetType().Name.ToLower().Replace("controller", "")))
                {
                    foreach (var methodOfController in controller.GetType().GetMethods())
                    {
                        if (split[2].Split('.')[0].ToLower().Equals(methodOfController.Name.ToLower()))
                        {
                            return controller;
                        }
                    }
                }
            }

            foreach (var controllerType in stateful)
            {
                if (split[1].ToLower().Equals(controllerType.Name.ToLower().Replace("controller", "")))
                {
                    foreach (var methodOfController in controllerType.GetMethods())
                    {
                        if (split[2].Split('.')[0].ToLower().Equals(methodOfController.Name.ToLower()))
                        {
                            return (Controller) Activator.CreateInstance(controllerType);
                        }
                    }
                }
            }

            return null;
        }


        public void InvokeRouteHandler()
        {
            var controllerName = filePath.Split('/')[1].FirstCharToUpper() + "Controller";
            var methodName = filePath.Split('/')[2].Split('.')[0].FirstCharToUpper();

            var controller = FindAndGetInstance();

            if (controller != null)
            {
                if (controller.GetType().GetMethod(methodName).GetParameters().Length != 0)
                {
                    HandleClientError("This request must have params!");
                    return;
                }

                IActionResult result =
                    (IActionResult) controller.GetType().GetMethod(methodName).Invoke(controller, new Object[] { });


                SendPage("200 OK", filePath);
            }
            else
            {
                logger.Info("doesnt find controller to url " + filePath);
                httpWriter.WriteClientError();
            }
        }

        // TOO BIG 
        public void InvokeRouteHandler(IDictionary<string, object> urlParams)
        {
            var controllerName = filePath.Split('/')[1].FirstCharToUpper() + "Controller";
            var methodName = filePath.Split('/')[2].Split('.')[0].Split('?')[0].FirstCharToUpper();

            var controller = FindAndGetInstance();
            if (controller != null)
            {
                if (urlParams.Keys.Count() == controller.GetType().GetMethod(methodName).GetParameters().Length)
                {
                    foreach (var parameter in controller.GetType().GetMethod(methodName).GetParameters().ToArray())
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
                foreach (var param in controller.GetType().GetMethod(methodName).GetParameters())
                {
                    var key = urlParams.Keys.First(u => u.Equals(param.Name));
                    parameters[iter] = urlParams[key];
                    iter++;
                }

                try
                {
                    IActionResult result =
                        (IActionResult) controller.GetType().GetMethod(methodName).Invoke(controller, parameters);
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
            else
            {
                logger.Info("doesnt find controller to url " + filePath);
                httpWriter.WriteClientError();
            }
        }
    }
}