using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace socket_client
{
    public class ReadMessage
    {
        public void Read(object argument)
        {
            TcpClient tcpClient = (TcpClient)argument;
            StreamReader reader = new StreamReader(tcpClient.GetStream());

            while (true)
            {
                try
                {
                    string message = reader.ReadLine();
                    Console.WriteLine(message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }
        }
    }
    class SocketClient
    {
        public static void Main()
        {
            ReadMessage read = new ReadMessage();
            try
            {
                Console.WriteLine(" Client Started ");
                TcpClient clientSocket = new TcpClient();
                clientSocket.Connect("127.0.0.1", 1000);
                Console.WriteLine(" Server Connected ");

                Thread thread = new Thread(read.Read);
                thread.Start(clientSocket);

                StreamWriter writer = new StreamWriter(clientSocket.GetStream());
                
                Console.WriteLine("Input Username");
                string name = Console.ReadLine();
                writer.WriteLine(name);

                Console.WriteLine("Input Message");
                while (true)
                {
                    if (clientSocket.Connected)
                    {
                        //send message 
                        string input = Console.ReadLine();
                        writer.WriteLine(input);
                        writer.Flush();
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            Console.WriteLine("Press any key to exit from client program");

            Console.ReadKey();
        }
    }
}