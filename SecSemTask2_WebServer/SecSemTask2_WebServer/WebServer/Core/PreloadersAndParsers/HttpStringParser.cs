using SecSemTask2_WebServer.WebServer.Core.Routers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Utils
{
    public class HttpStringParser
    {
        private string clientReq;

        public HttpStringParser(string reqeast)
        {
            this.clientReq = reqeast;
        }

        public bool HavingRoute(IDictionary<string, IEnumerable<string>> routeMap)
        {
            var path = GetRequestedFile().Split('/');
            if (path.Length == 3)
            {
                foreach (var item in routeMap)
                {
                    if (!IsContainsParams())
                    {
                        if (item.Key == path[1].ToLower() + "controller" &&
                            item.Value.Contains(path[2].Split('.')[0].ToLower()))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (item.Key == path[1].ToLower() + "controller" &&
                            item.Value.Contains(path[2].Split('.')[0].ToLower()))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public IDictionary<string, object> GetParams()
        {
            var paramStr = clientReq.Split(' ')[1].Split('?')[1];

            var resultParamDict = new Dictionary<string, object>();

            if (paramStr.Contains('&'))
            {
                foreach (var item in paramStr.Split('&'))
                {
                    resultParamDict.Add(item.Split('=')[0], item.Split('=')[1]);
                }
            }
            else
            {
                resultParamDict.Add(paramStr.Split('=')[0], paramStr.Split('=')[1]);
            }

            return resultParamDict;
        }

        public bool IsContainsParams()
        {
            return clientReq.Split(' ')[1].Contains('?');
        }


        public HttpMethodTypes GetHttpMethod()
        {
            //TODO other http methods return clientReq.Split(' ')[0];
            return HttpMethodTypes.HttpGet;
        }

        public string GetRequestedFile()
        {
            return IsContainsParams() ? clientReq.Split(' ')[1].Split('?')[0] : clientReq.Split(' ')[1];
        }

        public bool IsCorrectUrl()
        {
            var file = GetRequestedFile();
            return GetRequestedFile().Contains('/') &&
                   GetRequestedFile().Split('/').Length == 3 &&
                   (GetRequestedFile().Contains(".html") || GetRequestedFile().Contains(".css"));
        }
        
        public bool IsCorrect(string[] methods)
        {
            var words = clientReq.Split(' ');
            if (words.Length >= 3)
            {
                return methods.Contains(words[0])
                       && words[1].Contains('/')
                       && words[2].Contains("HTTP");
            }
            else
            {
                return false;
            }
        }
    }
}