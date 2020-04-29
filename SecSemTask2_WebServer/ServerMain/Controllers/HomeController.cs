using SecSemTask2_WebServer.WebServer.Core.Routers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecSemTask2_WebServer.WebServer.SDK;
using SecSemTask2_WebServer.WebServer.SDK.ControllerAttributes;
using SecSemTask2_WebServer.WebServer.SDK.HttpMethods;

namespace ServerMain.Controllers
{
    [Stateless]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Home(string name, string surname)
        {
            Console.WriteLine($"Зашел на Home/home с параметрами name-{name} и surname-{surname}" );
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
