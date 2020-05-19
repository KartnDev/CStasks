using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using SecSemTask3.Utils.CustomExceptions;
using NLog;
using SecSemTask3.Configs;
using SecSemTask3.Handlers;

namespace SecSemTask3
{
    public class Server : IServer
    {
        private volatile bool _status = false;

        private readonly int _port;
        private readonly string _ipAddrStr;
        private const int ConnMaxValue = ushort.MaxValue;
        private const int Timeout = -1;

        private readonly string _appToken;
        
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private Socket _serverSocket;

        
        public Server()
        {
            var directoryInfo = Directory.GetParent(Environment.CurrentDirectory).Parent;
            if (directoryInfo != null)
            {
                string projectDir = directoryInfo.FullName;

                ConfigModel jsonConfig;

                var path = projectDir + "\\Configuration\\Config.JSON";
                if (!File.Exists(path))
                {
                    Exception ex = new FileNotFoundException("Cannot find config file! path:" + path);
                    _logger.Fatal(ex);
                    throw ex;
                }
                
                using (var r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    jsonConfig = JsonConvert.DeserializeObject<ConfigModel>(json);
                }

                this._ipAddrStr = jsonConfig.Addr["ip"];
                
                if (!int.TryParse(jsonConfig.Addr["port"], out _port))
                {
                    Exception ex = new ConfigException("Bad port");
                    _logger.Fatal(ex, "Bad port");
                    throw ex;
                }

                this._appToken = jsonConfig.AppToken;
            }
            else
            {
                _logger.Fatal("Cannot find directory");
                throw new ArgumentException("Directory was wrong");
            }

            ConfigLogger("log.txt");
        }

        private static void ConfigLogger(string filename)
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") {FileName = filename};
            var logConsole = new NLog.Targets.ConsoleTarget("logconsole");

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logConsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
        }


        public bool Serve()
        {
            if (!IPAddress.TryParse(_ipAddrStr, out var ipAddr)) //WTF RIDER ??????
            {
                Exception ex = new ConfigException("Cannot parse IPAddr");
                _logger.Fatal(ex);
                throw ex;
            }

            try
            {
                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Bind(new IPEndPoint(ipAddr, _port));
                _serverSocket.Listen(ConnMaxValue);

                _serverSocket.ReceiveTimeout = Timeout;
                _serverSocket.SendTimeout = Timeout;
                _status = true;
            }
            catch (SocketException e)
            {
                _logger.Error(e, "Cannot initialize server socket... ");
                return false;
            }
            catch (Exception e)
            {
                _logger.Fatal(e, "Unhandled server socket ititialize error..");
                throw;
            }

            Thread clientListenLoop = new Thread(ClientLoop);
            clientListenLoop.Start();


            return true;
        }

        private void ClientLoop()
        {
            while (_status)
            {
                Socket clientSocket = null;
                
                try
                {
                    clientSocket = _serverSocket.Accept();
                }
                catch (SocketException e)
                {
                    _logger.Error(e, "Accept the client serversocket-error..");
                }
                catch (Exception e)
                {
                    _logger.Error(e, "While accepting the client was an unhandled-error..");
                    //throw; Should i throw here???? Is it fatal??????
                }

                if (clientSocket != null)
                {
                    Thread requestHandler = new Thread(() =>
                    {
                        clientSocket.ReceiveTimeout = Timeout;
                        clientSocket.SendTimeout = Timeout;
                        
                        IHandler handler = new SyncBaseHandler(_appToken, _logger);
                        handler.Handle(clientSocket);
                    });
                    requestHandler.Start();
                }
            }
        }


        public void Shutdown()
        {
            throw new System.NotImplementedException();
        }

        public void Abort()
        {
            throw new System.NotImplementedException();
        }
    }
}