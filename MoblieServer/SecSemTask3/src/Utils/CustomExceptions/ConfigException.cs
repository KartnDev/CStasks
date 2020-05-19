using System;

namespace SecSemTask3.Utils.CustomExceptions
{
    public class ConfigException : Exception
    {
        public ConfigException(string msg) : base(msg)
        {
        }
    }
}