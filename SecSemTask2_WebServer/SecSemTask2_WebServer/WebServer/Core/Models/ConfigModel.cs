using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Configuration
{
    public class ConfigModel
    {
        public int Port;
        public string Ip;
        public ushort NumConnections;
        public string SecretToken;
        public bool LocalPath;
        public string ContentPath;
        public string LogPath;
        public string DefaultClientErrorPage;
        public string DefaultServerErrorPage;
        public string DefaultRedirectPage;
    }
}
