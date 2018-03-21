using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using System.Data.OleDb;


namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server("192.168.11.104", 8080);
            server.Run();

            //String[] attributes = new String[] { "id", "username", "chats" };
            //int val = 100;
            //Wrap obj = new Wrap("Users");
            //String a = obj.Select(attributes, val);
            //Console.WriteLine(a);


            Console.ReadKey();
            
        }
    }
}
