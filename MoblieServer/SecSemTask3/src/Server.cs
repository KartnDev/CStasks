using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
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
        
        private Thread _clientListenLoop;
        
        private readonly string _sqlServerName;
        private readonly string _appToken;
        
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private Socket _serverSocket;


        public Server()
        {
            var directoryInfo = Directory.GetParent(Environment.CurrentDirectory).Parent;
            if (directoryInfo != null)
            {
                string projectDir = directoryInfo.Parent.FullName;

                ConfigModel jsonConfig;

                var path = projectDir + "\\Configs\\ServerConfig.JSON";
                if (!File.Exists(path))
                {
                    if(File.Exists("ServerConfig.JSON"))
                    {
                        path = "ServerConfig.JSON";
                    }
                    else
                    {
                        Exception ex = new FileNotFoundException("Cannot find config file! path:" + path);
                        _logger.Fatal(ex);
                        throw ex;
                    }
                }
                
                _logger.Info("Reading configurations..");
                using (var r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    jsonConfig = JsonConvert.DeserializeObject<ConfigModel>(json);
                }

                _ipAddrStr = jsonConfig.Addr["ip"];
                
                if (!int.TryParse(jsonConfig.Addr["port"], out _port))
                {
                    Exception ex = new ConfigException("Bad port");
                    _logger.Fatal(ex, "Bad port");
                    throw ex;
                }

                _appToken = jsonConfig.AppToken;
                _sqlServerName = jsonConfig.MSSQLName;
            }
            else
            {
                _logger.Fatal("Cannot find directory");
                throw new ArgumentException("Directory was wrong");
            }

            ConfigLogger("log.txt");
            _logger.Info("Start listening..");
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

            
            _clientListenLoop = new Thread(ClientLoop);
            _clientListenLoop.Priority = ThreadPriority.Highest;
            _clientListenLoop.Start();


            return _status;
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
                        
                        IHandler handler = new SyncBaseHandler(_appToken, _sqlServerName, _logger);
                        handler.Handle(clientSocket);
                    });
                    requestHandler.Start();
                    if (!_status)
                    {
                        requestHandler.Interrupt();
                    }
                }
            }
        }

        
        
        

        public void Shutdown()
        {
            _status = false;
            _clientListenLoop.Interrupt();
            GC.Collect();
            _logger.Info("Client loop was stopped normally");
        }
        


        public void Abort()
        {
            _status = false;
            _clientListenLoop.Abort();
            _logger.Info($"Client event loop was aborted critically!");
        }
    }
}