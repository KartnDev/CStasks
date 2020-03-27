using Newtonsoft.Json;
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

namespace SecSemTask2_WebServer.WebServer.Core
{
    public class Server
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly int connectionsNum;
        private readonly string contentPath;

        public bool running = false;

        private int timeout = 200;
        private Socket serverSocket;


        public Server()
        {
            string projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            projectDir = projectDir.Substring(0, projectDir.Length - 4);

            ConfigModel jsonConfig; // == null ?? throw Exception 

            using (StreamReader r = new StreamReader(projectDir + "\\Configuration\\Config.JSON"))
            {
                string json = r.ReadToEnd();
                jsonConfig = JsonConvert.DeserializeObject<ConfigModel>(json);
            }


            this.ipAddress = IPAddress.Parse(jsonConfig.ip);
            this.port = jsonConfig.port;
            this.connectionsNum = jsonConfig.numConnections;
            if (jsonConfig.localPath)
            {
                this.contentPath = projectDir + jsonConfig.contentPath;
            }
            else
            {
                this.contentPath = jsonConfig.contentPath;
            }

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
                // LOG EXCEPTION
                return false;
            }
            catch (Exception e)
            {
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


                            var controller = new RequestController(contentPath);
                            controller.HandleAsync(clientSocket);

                        });
                        requestHandler.Start();
                    }
                    catch (SocketException e)
                    {
                        // LOG EXCEPTION  
                    }
                    catch (Exception e)
                    {
                        // LOG EXCEPTION
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
                    // LOG EXCEPTION
                }
                catch (Exception e)
                {
                    // LOG EXCEPTION
                    throw;
                }
                serverSocket = null;
            }
        }
    }
}

