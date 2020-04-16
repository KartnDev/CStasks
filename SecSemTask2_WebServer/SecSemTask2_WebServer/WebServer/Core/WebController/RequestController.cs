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

namespace SecSemTask2_WebServer.WebServer.Core.WebController
{
    public class RequestController
    {
        private string contentPath;
        private string secretToken;
        private readonly Encoding charEncoder = Encoding.UTF8;
        private readonly Logger logger;

        private IDictionary<string, string> redirectionMap;

        private IDictionary<string, IEnumerable<string>> routeMap;


        public RequestController(string contentPath, string secretToken, Logger instanceLogger,
            IDictionary<string, IEnumerable<string>> routeMap)
        {
            this.logger = instanceLogger;
            this.contentPath = contentPath;
            this.secretToken = secretToken;
            this.routeMap = routeMap;
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
            var strRecieved = this.ParseReqString(clientSocket, 10240);

            if (strRecieved.Contains("stop" + secretToken))
            {
                return 1;
            }

            HttpStringParser httpMsgParser = new HttpStringParser(strRecieved);


            bool isHavingRoute = httpMsgParser.HavingRoute(routeMap) && httpMsgParser.IsCorrectUrl();

            if (httpMsgParser.IsCorrect(new string[] {"GET", "POST"}))
            {
                var requestedUrl = "/" + redirectionMap["DefaultRedirectPage"];
                //var httpMethod = HttpMethodTypes.HttpGet;
                if (isHavingRoute)
                {
                    requestedUrl = httpMsgParser.GetRequestedFile();
                    //httpMethod = httpMsgParser.GetHttpMethod();
                }
                
                ResponseHandler handler = new ResponseHandler(clientSocket, requestedUrl, logger);
                
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
                    handler.RedirectToDefPage(requestedUrl);
                }
            }

            return 0;
        }
    }
}