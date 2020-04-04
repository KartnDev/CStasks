using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SecSemTask2_WebServer.WebServer.Core.Routers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RouterAttribute : Attribute
    {

        public string HttpPath { get; private set; }
        public HttpMethodTypes MethodType { get; private set; }
        public RouterAttribute(string httpPath, HttpMethodTypes httpMethod)
        {
            this.HttpPath = httpPath;
            this.MethodType = httpMethod;
        }


    }
}
