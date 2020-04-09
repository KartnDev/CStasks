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
        void WriteClientError();
        void SendResponse(byte[] bContent, string responseCode, string contentType);
    }
}
