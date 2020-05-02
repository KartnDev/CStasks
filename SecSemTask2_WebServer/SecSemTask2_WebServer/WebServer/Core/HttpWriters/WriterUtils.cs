using System.Collections.Generic;
using System.Text;

namespace SecSemTask2_WebServer.WebServer.Core.HttpWriters
{
    internal class WriterUtils
    {
        internal static string CreateStringHeader(string contentType, 
            string responseCode, 
            int? contentLen = null,
            Dictionary<string, string> cookies=null)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("HTTP/1.1 "); 
            stringBuilder.Append(responseCode);
            stringBuilder.Append("\r\n");
            if (cookies != null)
            {
                foreach (var cookiePair in cookies)
                {
                    stringBuilder.Append("Set-Cookie: ");
                    stringBuilder.Append(cookiePair.Key);
                    stringBuilder.Append("=");
                    stringBuilder.Append(cookiePair.Value);
                    stringBuilder.Append(" \r\n");
                }
            }

            stringBuilder.Append("Server: Cherkasov Simple Web Server\r\n");
            if (contentLen != null)
            {
                stringBuilder.Append("Content-Length: ");
                stringBuilder.Append(contentLen.Value);
                stringBuilder.Append("\r\n");
            }
            stringBuilder.Append("Connection: close\r\n");
            stringBuilder.Append("Content-Type: ");
            stringBuilder.Append(contentType);
            stringBuilder.Append("\r\n\r\n");

            return stringBuilder.ToString();
        }
    }
}