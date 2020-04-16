using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecSemTask2_WebServer.WebServer.Core.HttpWriters
{
    public interface IHttpWriter
    {
        void Interrupt();
        void WriteServerError();
        void WriteServerError(string exceptionMessage, string responseCode);
        void WriteClientError();
        void WriteClientError(string exceptionMessage, string responseCode);
        void SendResponse(byte[] bContent, string responseCode, string contentType);
        void Redirect(string url);
    }
}
