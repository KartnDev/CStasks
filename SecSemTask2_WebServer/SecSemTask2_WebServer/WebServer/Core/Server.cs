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

        public bool running = false; //Запущено ли?

        private int timeout = 8; // Лиммт времени на приём данных.
        private Encoding charEncoder = Encoding.UTF8; // Кодировка
        private Socket serverSocket; // Нащ сокет

        // Поодерживаемый контент нашим сервером
        private Dictionary<string, string> extensions = new Dictionary<string, string>()
        { 
            //{ "extension", "content type" }
            { "htm", "text/html" },
            { "html", "text/html" },
            { "xml", "text/xml" },
            { "txt", "text/plain" },
            { "css", "text/css" },
            { "png", "image/png" },
            { "gif", "image/gif" },
            { "jpg", "image/jpg" },
            { "jpeg", "image/jpeg" },
            { "zip", "application/zip"}
        };


        public Server(string contentPath, int port = 1337, string ipAddr = "127.0.0.1", int numConnections = 255)
        {
            this.ipAddress = IPAddress.Parse(ipAddr);
            this.port = port;
            this.connectionsNum = numConnections;
            this.contentPath = contentPath;
        }

        public bool Start()
        {
            if (running) // Если уже запущено, то выходим
            {
                return false;
            }

            try
            {
                // tcp/ip сокет (ipv4)
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ipAddress, port));
                serverSocket.Listen(connectionsNum);
                serverSocket.ReceiveTimeout = timeout;
                serverSocket.SendTimeout = timeout;
                running = true;
            }
            catch
            {
                return false;
            }

            // Наш поток ждет новые подключения и создает новые потоки.
            Thread requestListenerT = new Thread(() =>
            {
                while (running)
                {
                    Socket clientSocket;
                    try
                    {
                        clientSocket = serverSocket.Accept();
                        // Создаем новый поток для нового клиента и продолжаем слушать сокет.
                        Thread requestHandler = new Thread(() =>
                        {
                            clientSocket.ReceiveTimeout = timeout;
                            clientSocket.SendTimeout = timeout;
                            try
                            {
                                HandleTheRequest(clientSocket);
                            }
                            catch
                            {
                                try
                                {
                                    clientSocket.Close();
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.Message + "\n\n\n\n" + e.StackTrace);
                                }
                            }
                        });
                        requestHandler.Start();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message + "\n\n\n\n" + e.StackTrace);
                    }
                }
            });
            requestListenerT.Start();

            return true;
        }

        public void stop()
        {
            if (running)
            {
                running = false;
                try { serverSocket.Close(); }
                catch { }
                serverSocket = null;
            }
        }

        private void HandleTheRequest(Socket clientSocket)
        {
            byte[] buffer = new byte[10240]; // 10 kb, just in case
            int receivedBCount = clientSocket.Receive(buffer); // Получаем запрос
            string strReceived = charEncoder.GetString(buffer, 0, receivedBCount);

            // Парсим запрос
            string httpMethod = strReceived.Substring(0, strReceived.IndexOf(" "));

            int start = strReceived.IndexOf(httpMethod) + httpMethod.Length + 1;
            int length = strReceived.LastIndexOf("HTTP") - start - 1;
            string requestedUrl = strReceived.Substring(start, length);

            string requestedFile;
            if (httpMethod.Equals("GET") || httpMethod.Equals("POST"))
                requestedFile = requestedUrl.Split('?')[0];
            else 
            {
                NotImplemented(clientSocket);
                return;
            }

            requestedFile = requestedFile.Replace("/", "\\").Replace("\\..", ""); // Not to go back
            start = requestedFile.LastIndexOf('.') + 1;
            if (start > 0)
            {
                length = requestedFile.Length - start;
                string extension = requestedFile.Substring(start, length);
                if (extensions.ContainsKey(extension)) // Мы поддерживаем это расширение?
                    if (File.Exists(contentPath + requestedFile)) // Если да
                                                                  // ТО отсылаем запрашиваемы контент:
                        SendOkResponse(clientSocket, File.ReadAllBytes(contentPath + requestedFile), extensions[extension]);
                    else
                        NotFound(clientSocket); // Мы не поддерживаем данный контент.
            }
            else
            {
                // Если файл не указан, пробуем послать index.html
                // Вы можете добавить больше(например "default.html")
                if (requestedFile.Substring(length - 1, 1) != "\\")
                    requestedFile += "\\";
                if (File.Exists(contentPath + requestedFile + "index.htm"))
                    SendOkResponse(clientSocket, File.ReadAllBytes(contentPath + requestedFile + "\\index.htm"), "text/html");
                else if (File.Exists(contentPath + requestedFile + "index.html"))
                    SendOkResponse(clientSocket, File.ReadAllBytes(contentPath + requestedFile + "\\index.html"), "text/html");
                else
                    NotFound(clientSocket);
            }
        }
        private void NotImplemented(Socket clientSocket)
        {
            SendResponse(clientSocket, "<html><head><meta" +
                    "http - equiv =\"Content-Type\" content=\"text/html;" +
                    "charset = utf - 8\">" +
                    "</head><body><h2> Hello Web!" +
                    "Server </h2><div> 501 - Method Not" +
                    "Implemented </div></body></html>",

                    "501 Not Implemented",      "text/html");
        }

        private void NotFound(Socket clientSocket)
        {

            SendResponse(clientSocket, "<html><head><meta" +
                "http - equiv =\"Content-Type\" content=\"text/html;" +
                "charset = utf - 8\"></head><body><h2>Bad gateway!" +
                "Server </h2><div> 404 - Not" +
                "Found </div></body></html> ",

                "404 Not Found",        "text/html");
        }

        private void SendOkResponse(Socket clientSocket, byte[] bContent, string contentType)
        {
            SendResponse(clientSocket, bContent, "200 OK", contentType);
        }

        // For strings
        private void SendResponse(Socket clientSocket, string strContent, string responseCode,
                                  string contentType)
        {
            byte[] bContent = charEncoder.GetBytes(strContent);
            SendResponse(clientSocket, bContent, responseCode, contentType);
        }

        // For byte arrays
        private void SendResponse(Socket clientSocket, byte[] bContent, string responseCode, string contentType)
        {
            try
            {
                byte[] bHeader = charEncoder.GetBytes(
                                    "HTTP/1.1 " + responseCode + "\r\n"
                                  + "Server: Cherkasov Simple Web Server\r\n"
                                  + "Content-Length: " + bContent.Length.ToString() + "\r\n"
                                  + "Connection: close\r\n"
                                  + "Content-Type: " + contentType + "\r\n\r\n");
                clientSocket.Send(bHeader);
                clientSocket.Send(bContent);
                clientSocket.Close();
            }
            catch { }
        }
    }
}

