using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Sent_file_sever
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Waiting to connect:");
            Console.WriteLine("--------------------");
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 5656);// khoi tao IP client
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            socket.Bind(ipEnd);
            socket.Listen(10);
            Socket client_socket = socket.Accept();
            
            Console.WriteLine("\n-----Connected--------");
            string fileName = "DanhSach.xml";
            string filePath = @"C:\Users\ADMIN\Desktop\";
            

            
            client_socket.Send(Send_file.clientData(fileName, filePath));

            Console.WriteLine("File:{0} da duoc gui.", fileName);

            byte[] clientData = new byte[1024 * 15000];
            socket.Receive(clientData);

            Receive_file.clientData(clientData, @"D:\");







            client_socket.Close();
            Console.ReadLine();
            Console.ReadKey();
        }
    }
}