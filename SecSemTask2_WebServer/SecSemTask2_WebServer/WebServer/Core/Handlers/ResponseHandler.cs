using NLog;
using SecSemTask2_WebServer.WebServer.Core.Engine;
using SecSemTask2_WebServer.WebServer.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Handlers
{
    public class ResponseHandler
    {
        public ResponseHandler(Socket clientSocket, string filePath, Logger logger,
            Dictionary<string, string> contollerMethodPathes, HttpMethod httpMethod)
        {
            string projectDir = FileHelper.GetProjectDir();


            string assemblyName = (new FileInfo(projectDir + "\\bin\\server\\ServerMain.exe")).FullName;
            byte[] assemblyBytes = File.ReadAllBytes(assemblyName);
            Assembly assembly = Assembly.Load(assemblyBytes);

            var contollers = assembly.GetTypes()
                .Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(Controller))).ToArray();




        private Dictionary<string, List<string>> mapPath;


            if(contollers.Length != 0)
            {
                foreach (var contoller in contollers)
                {
                    contoller.GetMethods();
                }
            }

        else
        {
            // ERROR
        }



        Console.WriteLine(attr.HttpPath + " " + attr.MethodType.ToString());
        }

}

}
