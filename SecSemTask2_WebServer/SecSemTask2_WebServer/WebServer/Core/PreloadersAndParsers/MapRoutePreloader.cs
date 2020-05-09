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


        public IDictionary<string, Controller> LoadStatelessControllers()
        {
            IDictionary<string, Controller> statelessControllers = new Dictionary<string, Controller>();

            foreach (Type anyCont in controllers)
            {
                var attributes = anyCont.GetCustomAttributes();
                if (attributes.Count(u => u.GetType() == typeof(StatelessAttribute)) == 1
                    && attributes.Count(u => u.GetType() == typeof(StatefulAttribute)) == 0)
                {
                    Controller ctr = Activator.CreateInstance(anyCont) as Controller;

                    statelessControllers.Add(anyCont.Name, ctr);
                }
            }

            
            return statelessControllers;
        }

        public IDictionary<string, Type> LoadStatefulControllers()
        {
            IDictionary<string, Type> statefulControllers = new Dictionary<string, Type>();

            foreach (var anyCont in controllers)
            {
                var attributes = anyCont.GetCustomAttributes();
                if (attributes.Count(u => u.GetType() == typeof(StatefulAttribute)) == 0
                    && attributes.Count(u => u.GetType() == typeof(StatelessAttribute)) == 1)
                {
                    statefulControllers.Add(anyCont.Name, anyCont);
                }
            }

            return statefulControllers;
        }
    }
}