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
            //-----------------Nhan file xml------------------------------
            byte[] clientData = new byte[1024*5000];
            client_socket.Receive(clientData);
            Receive_file.clientData(clientData, @"C:\");
            Console.WriteLine("\nDa nhan duoc file.");
            //-----------------Thuc hien sap xep--------------------------
            string text = File.ReadAllText(@"C:\file.xml");
            string kq = Sapxep.SX(text, 3);
            File.WriteAllText(@"C:\Ketqua.txt", kq);
            //-----------------Xuat ra ket qua----------------------------
            string fileName = "Ketqua.txt";
            string filePath = @"C:\";
            client_socket.Send(Send_file.clientData(fileName, filePath));//gui gile
            Console.WriteLine("\nFile:{0} da duoc gui.", fileName);
            Console.WriteLine(kq);

            client_socket.Close();
            Console.ReadLine();
            Console.ReadKey();
        }
    }
}