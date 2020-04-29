namespace SecSemTask2_WebServer.WebServer.Core.HttpWriters
{
    public class AsyncHttpWriter : IHttpWriter
    {
        public void Interrupt()
        {
            throw new System.NotImplementedException();
        }

        public void WriteServerError()
        {
            throw new System.NotImplementedException();
        }

        public void WriteServerError(string exceptionMessage, string responseCode)
        {
            throw new System.NotImplementedException();
        }

        public void WriteClientError()
        {
            throw new System.NotImplementedException();
        }

        public void WriteClientError(string exceptionMessage, string responseCode)
        {
            throw new System.NotImplementedException();
        }

        public void SendResponse(byte[] bContent, string responseCode, string contentType)
        {
            throw new System.NotImplementedException();
        }

        public void Redirect(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}