using SecSemTask2_WebServer.WebServer.Core.Routers;

namespace SecSemTask2_WebServer.WebServer.SDK
{
    public class Controller
    {
        protected IActionResult View(object[] args = null)
        {
            return new ActionResult(args);
        }
    }


}
