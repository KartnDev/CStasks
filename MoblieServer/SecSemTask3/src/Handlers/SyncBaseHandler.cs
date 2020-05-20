using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using NLog;
using SecSemTask3.Methods;

namespace SecSemTask3.Handlers
{
    public class SyncBaseHandler : IHandler
    {
        private readonly string _appToken;
        private readonly string  _sqlServerName;
        private readonly Logger _logger;
        private const int ReceiveMaxLen = 1024;
        
        private readonly Encoding _charEncoder = Encoding.UTF8;

        private IMethod _methodWorker = null;
        
        public SyncBaseHandler(string appToken,string sqlServerName, Logger logger)
        {
            _appToken = appToken;
            _sqlServerName = sqlServerName;
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
            _logger.Info("Client accepted, handling the request...");
            var requestStr = ParseReqString(clientSocket, ReceiveMaxLen);

            var resultParse = RequestProtocolParser(requestStr);
            if (resultParse.Count == 2)
            {
                var methodName = resultParse["methodName"];
                var @params = resultParse["params"];

                
                
                switch (methodName)
                {
                    case "register":
                    {
                        _methodWorker = new RegisterMethod(clientSocket, 
                                                          _sqlServerName,
                                                          @params as IDictionary<string, string>,
                                                          _logger);
                        _methodWorker.WorkSync();
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
            _methodWorker.InterruptMethod();
        }

        public void Abort()
        {
            _methodWorker.AbortMethod();
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