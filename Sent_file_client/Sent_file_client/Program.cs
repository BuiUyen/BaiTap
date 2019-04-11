using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Sent_file_client
{
    class Program
    {
        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 9999;

        static void Main(string[] args)
        {
            Console.WriteLine("Waiting to connect:");
            IPAddress[] ipAddress = Dns.GetHostAddresses("192.168.5.95");
            IPEndPoint ipEnd = new IPEndPoint(ipAddress[0], 5656);
            Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            clientSock.Connect(ipEnd);
            //-------------------Gui file------------------------------
            string fileName = "DanhSachHocSinh.xml";
            string filePath = @"C:\Users\ADMIN\Desktop\";
            clientSock.Send(Send_file.clientData(fileName, filePath));//gui gile cho serve
            Console.WriteLine("File:{0} da duoc gui.  ", fileName);
            //--------------------Nhan file ket qua--------------------
            byte[] clientData = new byte[1024 * 5000];
            clientSock.Receive(clientData);
            Receive_file.clientData(clientData, @"D:\");

            clientSock.Close();
            Console.ReadLine();
            Console.ReadKey();
        }
    }
}