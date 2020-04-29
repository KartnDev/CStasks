using SecSemTask2_WebServer.WebServer.SDK;
using SecSemTask2_WebServer.WebServer.SDK.ControllerAttributes;
using SecSemTask2_WebServer.WebServer.SDK.HttpMethods;

namespace ServerMain.Controllers
{
    
    [Stateless]
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult ClientErrorPage()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult ServerErrorPage()
        {
            return View();
        }
    }
}