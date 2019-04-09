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
            string fileName = "DanhSachHocSinh.xml";
            string filePath = @"C:\Users\ADMIN\Desktop\";

            byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);

            byte[] fileData = File.ReadAllBytes(filePath + fileName);

            byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];

            byte[] fileNameBit = BitConverter.GetBytes(fileNameByte.Length);

            fileNameBit.CopyTo(clientData, 0);
            fileNameByte.CopyTo(clientData, 4);
            fileData.CopyTo(clientData, 4 + fileNameByte.Length);

            client_socket.Send(clientData);
            Console.WriteLine("File:{0} da duoc gui.", fileName);
            client_socket.Close();
            Console.ReadLine();
            Console.ReadKey();
        }
    }
}