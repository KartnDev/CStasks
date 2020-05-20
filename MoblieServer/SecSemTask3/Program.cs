using System;
using System.Threading;

namespace SecSemTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "On startup the server... To stop server type \"shutdown()\" To critical abort type \"abort()\"");
            Server server = new Server();
            server.Serve();


            while (true)
            {
                var t = Console.ReadLine();
                
                if (t == "shutdown()")
                {
                    server.Shutdown();
                    break;
                }

                if (t == "abort()")
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    break;
                }
            }

            Console.WriteLine("Server closed. Press any key to exit console...");

            Console.Read();
        }
    }
}