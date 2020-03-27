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
            return clientReq.Split(' ')[0];
        }

        public string GetRequestedFile()
        {
            return clientReq.Split(' ')[1];   
        }

        public bool isCorrect(string[] methods)
        {
            var words = clientReq.Split(' ');
            if(words.Length >= 3)
            {
                return methods.Contains(words[0]) && words[1].Contains('/') && words[2].Contains("HTTP");
            }
            else
            {
                return false;
            }



            
        }
    }
}
