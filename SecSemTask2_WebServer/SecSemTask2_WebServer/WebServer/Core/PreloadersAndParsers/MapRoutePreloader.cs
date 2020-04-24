using SecSemTask2_WebServer.WebServer.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SecSemTask2_WebServer.WebServer.SDK;

namespace SecSemTask2_WebServer.WebServer.Core.Preloader
{

    

    public class MapRoutePreloader
    {
        

        public static KeyValuePair<IDictionary<string, IEnumerable<string>>, IEnumerable<Type>> Load()
        {
            var mapPath = new Dictionary<string, IEnumerable<string>>();

            string projectDir = Helper.GetProjectDir();
            
            
            
            string[] files = Directory.GetFiles(projectDir, "*.exe", SearchOption.AllDirectories);

            ISet<Assembly> listOfAssembly = new HashSet<Assembly>();

            foreach (var file in files)
            {
                listOfAssembly.Add(Assembly.Load(File.ReadAllBytes(file)));
            }
            ISet<Type> controllers = new HashSet<Type>();

            foreach (var assembly in listOfAssembly)
            {
                
                // TODO rewrite
                if (assembly.GetTypes().Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(Controller)))
                        .Count() != 0)
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


            if (controllers.Count != 0)
            {
                foreach (var controller in controllers)
                {

                    var methodsOfController = new List<string>();

                    foreach (var item in controller.GetMethods())
                    {
                        methodsOfController.Add(item.Name.ToLower());
                    }

                    mapPath.Add(controller.Name.ToLower(), methodsOfController);
                }
                return new KeyValuePair<IDictionary<string, IEnumerable<string>>, IEnumerable<Type>>(mapPath, controllers);
            }
            else
            {
                return new KeyValuePair<IDictionary<string, IEnumerable<string>>, IEnumerable<Type>>();
                // TODO or Throw Error ?
            }
        }
        
    }
}
