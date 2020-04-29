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
        
        private readonly IEnumerable<Controller> stateless;
        private readonly IEnumerable<Type> stateful;

        private IDictionary<string, string> redirectionMap;

        public RequestController(string contentPath, string secretToken, Logger logger,
            IEnumerable<Controller> stateless, IEnumerable<Type> stateful)
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

        public void SetRedirectionMap(IDictionary<string, string> urlRedirectingMap)
        {
            this.redirectionMap = urlRedirectingMap;
        }


        public int RedirectToHttpHandler(Socket clientSocket)
        {
            var strReceived = this.ParseReqString(clientSocket, 10240);

            if (strReceived.Contains("stop" + secretToken))
            {
                return 1;
            }

            HttpStringParser httpMsgParser = new HttpStringParser(strReceived);

            if (strReceived.Equals("") || strReceived == null)
            {
                return 0;
            }
            

            bool isHavingRoute = httpMsgParser.HavingRoute(stateless, stateful) && httpMsgParser.IsCorrectUrl();

            if (httpMsgParser.IsCorrect(new string[] {"GET", "POST"}))
            {
                var requestedUrl = "/" + redirectionMap["DefaultRedirectPage"];
                if (isHavingRoute)
                {
                    requestedUrl = httpMsgParser.GetRequestedFile();
                }


                ResponseHandler handler = new ResponseHandler(clientSocket, requestedUrl, stateful, stateless, logger);
                
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

            return 0;
        }
    }
}