using NLog;
using SecSemTask2_WebServer.WebServer.Core.Handlers;
using SecSemTask2_WebServer.WebServer.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SecSemTask2_WebServer.WebServer.Core.Routers;
using SecSemTask2_WebServer.WebServer.SDK;

namespace SecSemTask2_WebServer.WebServer.Core.WebController
{
    public class RequestController
    {
        private readonly string contentPath;
        private readonly string secretToken;
        private readonly Encoding charEncoder = Encoding.UTF8;
        private readonly Logger logger;
        
        private readonly IDictionary<string, Controller> stateless;
        private readonly IDictionary<string, Type> stateful;

        private IDictionary<string, string> redirectionMap;

        public RequestController(string contentPath, string secretToken, Logger logger,
            IDictionary<string, Controller> stateless, IDictionary<string, Type> stateful)
        {
            this.logger = logger;
            this.stateless = stateless;
            this.stateful = stateful;
            this.contentPath = contentPath;
            this.secretToken = secretToken;
        }

        private string ParseReqString(Socket clientSocket, int reqLen)
        {
            byte[] buffer = new byte[reqLen];
            int receivedBCount = clientSocket.Receive(buffer);
            return charEncoder.GetString(buffer, 0, receivedBCount);
        }

        internal void SetRedirectionMap(IDictionary<string, string> urlRedirectingMap)
        {
            this.redirectionMap = urlRedirectingMap;
        }


        internal OnExitCode RedirectToHttpHandler(Socket clientSocket)
        {
            var strReceived = this.ParseReqString(clientSocket, 10240);

            if (strReceived.Contains("stop" + secretToken))
            {
                return OnExitCode.OnStop;
            }

            HttpStringParser httpMsgParser = new HttpStringParser(strReceived);

            if (strReceived.Equals("") || string.IsNullOrEmpty(strReceived))
            {
                return OnExitCode.OnNormalExit;
            }
            

            bool isHavingRoute = httpMsgParser.HavingRoute(stateless, stateful) && httpMsgParser.IsCorrectUrl();

            if (httpMsgParser.IsCorrect(new string[] {"GET", "POST"}))
            {
                var requestedUrl = "/" + redirectionMap["DefaultRedirectPage"];
                if (isHavingRoute)
                {
                    requestedUrl = httpMsgParser.GetRequestedFile();
                }

                var controller = FindAndGetInstance(requestedUrl);
                
                
                ResponseHandler handler = new ResponseHandler(clientSocket, controller, requestedUrl, logger);
                
                handler.SetRedirectionMapWithCheckParams(redirectionMap);

                if (isHavingRoute)
                {
                    if (httpMsgParser.IsContainsParams())
                    {
                        var urlParams = httpMsgParser.GetParams();
                        handler.InvokeRouteHandler(urlParams);
                    }
                    else
                    {
                        handler.InvokeRouteHandler();
                    }
                }
                else
                {
                    handler.RedirectToDefPage();
                }
            }

            return OnExitCode.OnNormalExit;
        }
        
        private Controller FindAndGetInstance(string filePath)
        {
            var split = filePath.Split('/');

            foreach (var controller in stateless)
            {
                if (split[1].ToLower().Equals(controller.Key.ToLower().Replace("controller", "")))
                {
                    foreach (var methodOfController in controller.Value.GetType().GetMethods())
                    {
                        if (split[2].Split('.')[0].ToLower().Equals(methodOfController.Name.ToLower()))
                        {
                            return controller.Value;
                        }
                    }
                }
            }

            foreach (var ctrNameType in stateful)
            {
                if (split[1].ToLower().Equals(ctrNameType.Key.ToLower().Replace("controller", "")))
                {
                    foreach (var methodOfController in ctrNameType.Value.GetMethods())
                    {
                        if (split[2].Split('.')[0].ToLower().Equals(methodOfController.Name.ToLower()))
                        {
                            return (Controller) Activator.CreateInstance(ctrNameType.Value);
                        }
                    }
                }
            }

            return null;
        }
    }
}