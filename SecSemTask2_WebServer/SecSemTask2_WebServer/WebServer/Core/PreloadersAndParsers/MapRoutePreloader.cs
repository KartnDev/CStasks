using SecSemTask2_WebServer.WebServer.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SecSemTask2_WebServer.WebServer.SDK;
using SecSemTask2_WebServer.WebServer.SDK.ControllerAttributes;

namespace SecSemTask2_WebServer.WebServer.Core.Preloader
{

    

    public class MapRoutePreloader
    {
        private readonly ISet<Type> controllers;
        
        public MapRoutePreloader()
        {
            var mapPath = new Dictionary<string, IEnumerable<string>>();

            string projectDir = Helper.GetProjectDir();
            
            
            
            string[] files = Directory.GetFiles(projectDir, "*.exe", SearchOption.AllDirectories);

            ISet<Assembly> listOfAssembly = new HashSet<Assembly>();

            foreach (var file in files)
            {
                listOfAssembly.Add(Assembly.Load(File.ReadAllBytes(file)));
            }
            controllers = new HashSet<Type>();

            foreach (var assembly in listOfAssembly)
            {

                var listed = assembly.GetTypes()
                    .Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(Controller)));
                
                if (listed.Count() != 0)
                {
                    var loaderControllers = assembly.GetTypes()
                        .Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(Controller)));
                    foreach (var loaded in loaderControllers)
                    {
                        controllers.Add(loaded);
                    }
                    break;
                }
            }
        }
        
        
        public IEnumerable<Controller> LoadStatelessControllers()
        {
            IEnumerable<Controller> statelessControllers = new List<Controller>();

            foreach (var anyCont in controllers)
            {
                var attributes = anyCont.GetCustomAttributes();
                if (attributes.Count(u => u.GetType() == typeof(StatelessAttribute)) == 1
                    && attributes.Count(u => u.GetType() == typeof(StatefulAttribute)) == 0)
                {
                    statelessControllers.Append((Controller) Activator.CreateInstance(anyCont));
                }
            }

            return statelessControllers;
        }

        public IEnumerable<Type> LoadStatefulControllers()
        {
            IEnumerable<Type> statefulControllers = new List<Type>();

            foreach (var anyCont in controllers)
            {
                var attributes = anyCont.GetCustomAttributes();
                if (attributes.Count(u => u.GetType() == typeof(StatelessAttribute)) == 0
                    && attributes.Count(u => u.GetType() == typeof(StatefulAttribute)) == 1)
                {
                    statefulControllers.Append(anyCont);
                }
            }

            return statefulControllers;
        }
        
    }
}
