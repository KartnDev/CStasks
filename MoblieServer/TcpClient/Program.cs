using System;
using System.Net.Sockets;
using System.Text;

namespace TcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 3305;
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient("localhost", port);

                Console.WriteLine("Type the method name (register or etc)");
                string method = "register"; //Console.ReadLine();
                Console.WriteLine("Type the args passing this rule (name=Dmitry&surname=Cherkasov&password=123&phone_num=9221330");
                string @params = "name=ads3ry&surname=Casd43sov&password=1123434gfd5423&phone_num=861318761"; //Console.ReadLine();

                var s = $"98F1EJJDa4fjwD2fUIHWUd2dsaAsS289IFFFadde3A8213HFI7" +
                        $"?{method}?" + @params;
                       
                
                
                
                
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(s);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", s);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
                if (!responseData.Contains("error=100"))
                {
                    String uuid = responseData.Split("UUID=")[1].Split(" ")[0];

                    Console.WriteLine("Sent: {0}", uuid);
                    stream.Write(Encoding.UTF8.GetBytes(uuid));


                    responseData = String.Empty;

                    // Read the first batch of the TcpServer response bytes.
                    bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received status: {0}", responseData);
                }
                else
                {
                    Console.WriteLine("User exists!");
                }
                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
    }
}