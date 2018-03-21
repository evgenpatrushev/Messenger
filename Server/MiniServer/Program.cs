using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace MiniServer
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[256];
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(new IPEndPoint(IPAddress.Parse("192.168.11.104"), 8080));
            listenSocket.Listen(10);

            while (true)
            {
                Console.WriteLine("Waiting for connections...");
                Socket clientSocket = listenSocket.Accept();
                Console.WriteLine(String.Format("New user - {0}", clientSocket));
                while (true)
                {
                    Console.Write("Enter message - ");
                    String message = Console.ReadLine();
                    clientSocket.Send(System.Text.Encoding.UTF8.GetBytes(message));
                    clientSocket.Receive(data);
                    Console.WriteLine(System.Text.Encoding.UTF8.GetString(data));
                }
            }
        }
    }
}
