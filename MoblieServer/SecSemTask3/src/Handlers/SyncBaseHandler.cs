using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using NLog;

namespace SecSemTask3.Handlers
{
    public class SyncBaseHandler : IHandler
    {
        private readonly string _appToken;
        private readonly Logger _logger;
        private const int ReceiveMaxLen = 1024;
        
        private readonly Encoding _charEncoder = Encoding.UTF8;

        public SyncBaseHandler(string appToken, Logger logger)
        {
            _appToken = appToken;
            _logger = logger;
        }
        
        
        
        private string ParseReqString(Socket clientSocket, int reqLen)
        {
            var buffer = new byte[reqLen];
            var receivedBCount = clientSocket.Receive(buffer);
            return _charEncoder.GetString(buffer, 0, receivedBCount);
        }
        
        
        
        public void Handle(Socket clientSocket)
        {
            var requestStr = ParseReqString(clientSocket, ReceiveMaxLen);

            var resultParse = RequestProtocolParser(requestStr);
            if (requestStr.Length == 2)
            {
                var methodName = resultParse["methodName"];
                var @params = resultParse["params"];

                switch (methodName)
                {
                    case "register":
                    {
                        
                    } break;
                    
                    default:
                        return;
                }
                
            }
            else
            {
                return;
            }
        }

        public void Interrupt()
        {
            throw new System.NotImplementedException();
        }

        public void Abort()
        {
            throw new System.NotImplementedException();
        }

        // Example application_token?register?username=<>&surname=<>&password=<>
        private IDictionary<string, object> RequestProtocolParser(string req)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            
            var split = req.Split('?');
            
            
            var boundaryToken = split[0];
            if (boundaryToken.Equals(_appToken))
            {
                var method = split[1];
                var @params = split[2].Split('&');
                IDictionary<string, string> paramMap = new Dictionary<string, string>();
                foreach (var paramPairString in @params)
                {
                    var splitParam = paramPairString.Split('=');
                    paramMap.Add(splitParam[0], splitParam[1]);
                }

                
                result.Add("methodName", method);
                result.Add("params", paramMap);
            }
            else
            {
                _logger.Info("Was request without app token");
            }

            return result;
        }
        
    }
}