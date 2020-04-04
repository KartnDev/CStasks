using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.Utils
{
    public static class Helper
    {

        public static string GetProjectDir()
        {
            string projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            return projectDir;
        }



        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }



    }

}

