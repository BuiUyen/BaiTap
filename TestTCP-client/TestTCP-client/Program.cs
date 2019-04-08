using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestTCP_client
{
    class Program
    {
        private const int PORT_NUMBER = 9999;
        static ASCIIEncoding encoding = new ASCIIEncoding();

        public static void Main()
        {
            TcpClient client = new TcpClient();

            // 1. connect
            client.Connect("192.168.5.95", PORT_NUMBER);
            Stream stream = client.GetStream();

            Console.WriteLine("Connected to Server.");
            while (true)
            {
                Console.Write("Nhap du lieu:   ");
                String str = File.ReadAllText(@"C:\Users\ADMIN\Desktop\DanhSachHocSinh.xml");
                Console.Write(str);
                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                // 2. send
                writer.WriteLine(str);

                // 3. receive
                string kq = reader.ReadLine();
                Console.WriteLine(kq);
                break;
            }
            // 4. close
            stream.Close();
            client.Close();
            Console.ReadKey();
        }
    }

}