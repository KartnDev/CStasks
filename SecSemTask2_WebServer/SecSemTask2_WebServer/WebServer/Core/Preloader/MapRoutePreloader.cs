using SecSemTask2_WebServer.WebServer.Core.Engine;
using SecSemTask2_WebServer.WebServer.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Preloader
{

    

    public class MapRoutePreloader
    {
        

        public static Dictionary<string, IEnumerable<string>> Load()
        {
            var mapPath = new Dictionary<string, IEnumerable<string>>();

            string projectDir = FileHelper.GetProjectDir();

            string assemblyName = (new FileInfo(projectDir + "\\bin\\server\\ServerMain.exe")).FullName;
            byte[] assemblyBytes = File.ReadAllBytes(assemblyName);
            Assembly assembly = Assembly.Load(assemblyBytes);

            var contollers = assembly.GetTypes()
                .Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(Controller))).ToArray();


            if (contollers.Length != 0)
            {
                foreach (var contoller in contollers)
                {

                    var methodsOfController = new List<string>();

                    foreach (var item in contoller.GetMethods())
                    {
                        methodsOfController.Add(item.Name);
                    }

                    mapPath.Add(contoller.Name, methodsOfController);
                }
                return mapPath;
            }
            else
            {
                return null;
                // TODO or Throw Error ?
            }
        }
    }
}
