using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Configuration
{
    public class ConfigModel
    {
        public int port;
        public string ip;
        public ushort numConnections;
        public string secretToken;
        public bool localPath;
        public string contentPath;
        public string logPath;
    }
}
