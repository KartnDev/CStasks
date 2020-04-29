using Newtonsoft.Json;
using NLog;
using SecSemTask2_WebServer.WebServer.Configuration;
using SecSemTask2_WebServer.WebServer.Core.WebController;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SecSemTask2_WebServer.WebServer.Core.Preloader;
using SecSemTask2_WebServer.WebServer.SDK;

namespace SecSemTask2_WebServer.WebServer.Core
{
    public class Server
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly int connectionsNum;
        private readonly string contentPath;
        private readonly string token;
        private readonly IDictionary<string, string> redirectionMap = new Dictionary<string, string>();
        private readonly IEnumerable<Type> statefulControllers;
        private readonly IEnumerable<Controller> statelessControllers;
        
        public bool running = false;

        private int timeout = -1;
        private Socket serverSocket;

        private readonly Logger logger = LogManager.GetCurrentClassLogger();


        public Server()
        {
            var preloader = new MapRoutePreloader();
            statefulControllers = preloader.LoadStatefulControllers();
            statelessControllers = preloader.LoadStatelessControllers();
            
            var directoryInfo = Directory.GetParent(Environment.CurrentDirectory).Parent;
            if (directoryInfo != null)
            {
                string projectDir = directoryInfo.FullName;

                ConfigModel jsonConfig; 

                using (StreamReader r = new StreamReader(projectDir + "\\Configuration\\Config.JSON"))
                {
                    string json = r.ReadToEnd();
                    jsonConfig = JsonConvert.DeserializeObject<ConfigModel>(json);
                }

                this.ipAddress = IPAddress.Parse(jsonConfig.Ip);
                this.port = jsonConfig.Port;
                this.connectionsNum = jsonConfig.NumConnections;
                this.token = jsonConfig.SecretToken;

                this.redirectionMap.Add("DefaultRedirectPage", jsonConfig.DefaultRedirectPage);
                this.redirectionMap.Add("DefaultClientErrorPage",jsonConfig.DefaultClientErrorPage);
                this.redirectionMap.Add("DefaultServerErrorPage", jsonConfig.DefaultServerErrorPage);
            
            
                if (jsonConfig.LocalPath)
                {
                    this.contentPath = projectDir + jsonConfig.ContentPath;
                }
                else
                {
                    this.contentPath = jsonConfig.ContentPath;
                }
            }
            else
            {
                logger.Fatal("Cannot find directory");
                throw new ArgumentException("Directory was wrong");
            }

            ConfigLogger("log.txt");
        }


        private void ConfigLogger(string filename)
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = filename};
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            NLog.LogManager.Configuration = config;
        }


        public bool Start()
        {
            if (running)
            {
                return false;
            }

            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ipAddress, port));
                serverSocket.Listen(connectionsNum);
                serverSocket.ReceiveTimeout = timeout;
                serverSocket.SendTimeout = timeout;
                running = true;
            }
            catch (SocketException e)
            {
                logger.Error(e, "server socket init error..");
                return false;
            }
            catch (Exception e)
            {
                logger.Error(e, "unhandled server socket itit error..");
                throw;
            }

            Thread requestListenerT = new Thread(() =>
            {
                while (running)
                {
                    Socket clientSocket = null;
                    try
                    {
                        clientSocket = serverSocket.Accept();

                        Thread requestHandler = new Thread(() =>
                        {
                            clientSocket.ReceiveTimeout = timeout;
                            clientSocket.SendTimeout = timeout;


                            var controller = new RequestController(contentPath, token, logger, statelessControllers, statefulControllers);
                            controller.SetRedirectionMap(redirectionMap);
                            if (controller.RedirectToHttpHandler(clientSocket) == 1)
                            {
                                Stop();
                            }
                        });
                        
                        requestHandler.Start();
                    }
                    catch (SocketException e)
                    {
                        logger.Error(e, "accept the client serversocket-error..");
                    }
                    catch (Exception e)
                    {
                        logger.Error(e, "accept the client  unhandled-error..");
                        throw;
                    }
                }
            });
            requestListenerT.Start();

            return true;
        }

        public void Stop()
        {
            if (running)
            {
                running = false;
                try
                {
                    serverSocket.Close();
                }
                catch (SocketException e)
                {
                    logger.Error(e, "close server socket error..");
                }
                catch (Exception e)
                {
                    logger.Error(e, "unhandled stop command error..");
                    throw;
                }
                serverSocket = null;
            }
        }
    }
}

