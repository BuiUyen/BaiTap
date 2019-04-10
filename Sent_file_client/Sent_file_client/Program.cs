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
            Console.WriteLine("Dang cho nhan tin hieu:");
            IPAddress[] ipAddress = Dns.GetHostAddresses("192.168.5.95");
            IPEndPoint ipEnd = new IPEndPoint(ipAddress[0], 5656);

            Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            clientSock.Connect(ipEnd);

            byte[] clientData = new byte[1024 * 15000];
            string receivedPath = "C:/";
            
            int receivedBytesLen = clientSock.Receive(clientData);//Receive: nhan du lieu byte[] vao clientData, tra ve so byte nhan duoc

            int fileNameLen = clientData[0];
            string fileName = Encoding.ASCII.GetString(clientData, 1, fileNameLen);
            Console.WriteLine("Client:{0} connected & File {1} started received.", clientSock.RemoteEndPoint, fileName);

            BinaryWriter bWrite = new BinaryWriter(File.Open(receivedPath + fileName, FileMode.Append)); ;
            bWrite.Write(clientData, 1 + fileNameLen, receivedBytesLen - 1 - fileNameLen);
            Console.WriteLine("File: {0} received & saved at path: {1}", fileName, receivedPath);
            bWrite.Close();

            clientSock.Send(Send_file.clientData("DanhSachHocSinh.xml", @"C:\Users\ADMIN\Desktop\"));
            Console.Write("hoantat");

            clientSock.Close();
            Console.ReadLine();
            Console.ReadKey();
        }
    }
}