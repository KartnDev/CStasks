using NLog;
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

namespace SecSemTask2_WebServer.WebServer.Core.Handlers
{
    public class HttpGetHandler : BaseHandler
    {
        public HttpGetHandler(Socket clientSocket, string fileName, Logger logger) : base(clientSocket, fileName, logger)
        {
        }

        public override void Handle()
        {

            string projectDir = FileHelper.GetProjectDir();


            string assemblyName = (new FileInfo(projectDir + "\\bin\\server\\ServerMain.exe")).FullName;
            byte[] assemblyBytes = File.ReadAllBytes(assemblyName);
            Assembly assembly = Assembly.Load(assemblyBytes);
            var methods = assembly.GetTypes()
                      .SelectMany(t => t.GetMethods())
                      .Where(m => m.GetCustomAttributes(typeof(RouterAttribute), false).Length > 0)
                      .ToArray();

            var attr = (RouterAttribute)methods[0].GetCustomAttributes(typeof(RouterAttribute), false).First();


            Console.WriteLine(attr.HttpPath + " " + attr.MethodType.ToString());
            

            if (filePath.Contains('.'))
            {
                this.SendOkResponse(File.ReadAllBytes(filePath), "text/" + filePath.Split('.')[1]);
            }
            else
            {
                this.SendOkResponse(File.ReadAllBytes(filePath + "index.html"), "text/html");
            }
        }
    }
}
