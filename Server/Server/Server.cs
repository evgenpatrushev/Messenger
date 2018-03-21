using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Server
{

    class Request
    {
        public String Type { get; set; }
        public Dictionary<String,String> Data { get; set; }
    }

    class Respond /* ??? */
    {
        public String Status { get; set; }
        public Dictionary<String, String> Data { get; set; }

        public Respond(String status)
        {
            Status = status;
            Data = null;
        }

        public Respond(String status, Dictionary<String, String> data)
        {
            Status = status;
            Data = data;
        } 
    }

    class User
    {

    }

    class Server
    {
        private static List<Socket> clients;
        public static Dictionary<Socket, User> chatActiveClients;

        private String host;
        private int port;    
        private Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private int oneTimeLinstened = 10;

        public Server(String _host,int _port)
        {
            port = _port;
            host = _host;
            listenSocket.Bind(new IPEndPoint(IPAddress.Parse(host), port));
        } 

        public void Run()
        {
            listenSocket.Listen(oneTimeLinstened);
            AcceptIncomingConnections();
            listenSocket.Close();
        }

        private void AcceptIncomingConnections()
        {
            while(true) 
            {
                Console.WriteLine("Waiting for connections...");
                Socket clientSocket = listenSocket.Accept();
                Console.WriteLine(String.Format("New user - {0}", clientSocket));
                ClientHandler client = new ClientHandler(clientSocket);
                Thread currentUserThread = new Thread(client.Handle);
                currentUserThread.Start();
            }

        }

    }

    class ClientHandler
    {
        private Socket socket;
        private byte[] data = new byte[256];

        public ClientHandler(Socket _socket)
        {
            socket = _socket;
        }

        public void Handle()
        {
            while (true)
            {
                Request request = Receive();
                Console.WriteLine(String.Format("Client - {0}", request.Data["Message"]));

                Console.Write("Enter message - ");
                String Message = Console.ReadLine();
                Dictionary<String, String> respondData = new Dictionary<string, string>
                {
                    ["Message"] = Message
                };
                Send(new Respond(status: "It works", 
                                 data: respondData));
            }
        }

        private Request Receive()
        {
            socket.Receive(data);
            String message = System.Text.Encoding.UTF8.GetString(data);
            return JsonConvert.DeserializeObject<Request>(message); ;
        }

        private void Send(Respond respondObject)
        {
            String jsonRespond = JsonConvert.SerializeObject(respondObject);
            socket.Send(System.Text.Encoding.UTF8.GetBytes(jsonRespond));
        }

    }
}
