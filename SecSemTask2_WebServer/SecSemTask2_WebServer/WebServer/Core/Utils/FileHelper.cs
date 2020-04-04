using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Utils
{
    public static class FileHelper
    {
        public static string GetProjectDir()
        {
            string projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            return projectDir;
        }

    }
}
