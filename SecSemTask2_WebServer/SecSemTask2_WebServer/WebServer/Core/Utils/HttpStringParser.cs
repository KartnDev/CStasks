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


        public string GetHttpMethod()
        {
            string httpMethod = clientReq.Substring(0, clientReq.IndexOf(" "));

            int start = clientReq.IndexOf(httpMethod) + httpMethod.Length + 1;
            int length = clientReq.LastIndexOf("HTTP") - start - 1;

            return clientReq.Substring(start, length);
        }

        public string GetRequestedFile()
        {
            int start = clientReq.IndexOf(GetHttpMethod()) + GetHttpMethod().Length + 1;
            int length = clientReq.LastIndexOf("HTTP") - start - 1;
            string requestedUrl = clientReq.Substring(start, length);

            string requestedFile = requestedUrl.Split('?')[0];
            return requestedFile.Replace("/", "\\").Replace("\\..", "");   
        }

        public bool isCorrect(string[] methods)
        {
            var words = clientReq.Split(' ');
            if(words.Length > 3)
            {
                return methods.Contains(words[0]) && words[1][1] == '/' && words[2].Contains("HTTP");
            }
            else
            {
                return false;
            }



            
        }
    }
}
