using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Linq;

namespace socket_server
{
    class SocketServer
    {
        static TcpListener Listener;
        static TcpClient tcpClients;
        static List<TcpClient> clientsList = new List<TcpClient>();
        private static List<string> messages = new List<string>();
        static Int32 port = 1000;
        static IPAddress localAddress = IPAddress.Parse("127.0.0.1");

        public static void ClientListener(object argument, int num)
        {
            TcpClient tcpClient = (TcpClient)argument;
            StreamReader reader = new StreamReader(tcpClient.GetStream());

            Console.WriteLine("Client " + num.ToString() + " connected...");

            try
            {
                string name = reader.ReadLine();

                while (true)
                {
                    string message = reader.ReadLine();
                    BroadCast(message, name, tcpClient, num);
                    string chat = name + " : " + message;
                    Console.WriteLine(chat);

                    writeMessage(chat);
                }
            }
            catch (IOException)
            {
                Console.WriteLine(" ");
            }
            finally
            {
                clientsList.Remove(tcpClient);
                Console.WriteLine("Client " + num.ToString() + " Disconnected...");

                if (clientsList?.Any() == false)
                {
                    tcpClients.Client.Disconnect(true);
                    tcpClients.Client.Close();
                    Console.WriteLine("Server Closed...");
                    System.Environment.Exit(1);
                }
            }

        }

        public static void BroadCast(string msg, string nam, TcpClient currentClient, int n)
        {
            foreach (TcpClient client in SocketServer.clientsList)
            {
                StreamWriter writer = new StreamWriter(client.GetStream());
                if (client != currentClient)
                {
                    writer.WriteLine(nam + " : " + msg);
                }
                writer.Flush();
            }
        }

        public static void Main()
        {
            Listener = new TcpListener(localAddress, port);
            Listener.Start();
            Console.WriteLine("Server created...");
            int clientCounter = 0;

            try
            {
                while (true)
                {
                    tcpClients = Listener.AcceptTcpClient();
                    clientsList.Add(tcpClients);
                    Console.WriteLine(" New Client Accepted...!");

                    //start listener
                    Thread clientThread = new Thread(() => ClientListener(tcpClients, clientCounter));
                    clientThread.Start();

                    clientCounter++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void writeMessage(string chat)
        {
            messages.Add(chat);
            File.WriteAllLines("D:/jaringan komputer/tugas/chat.txt", messages);
        }
    }
}