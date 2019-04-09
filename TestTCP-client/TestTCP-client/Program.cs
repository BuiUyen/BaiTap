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
        private const int BUFFER_SIZE = 1024;
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

                //Lua chon thuoc tinh sap xep
                Console.WriteLine("\n\n-----------------------------------------------");
                Console.WriteLine("1. Sap xep theo tuoi.");
                Console.WriteLine("2. Sap xep theo ho ten.");
                Console.WriteLine("3. Sap xep theo ten.");
                Console.WriteLine("4. Sap xep theo gioi tinh.");
                Console.WriteLine("5. Sap xep theo gioi tinh roi theo ten.");
                Console.Write("\n\nNhap vao thuoc tinh sap xep:");
                int lc = Convert.ToInt32(Console.ReadLine());
                // 2. send
                writer.WriteLine(lc);
                writer.WriteLine(str);

                // 3. receive
                string kq = reader.ReadLine();
                while (reader.Peek() >= 0)
                {
                    kq += "\n" + reader.ReadLine();
                }
                Console.WriteLine("\n\n" + "Ket qua tra ve: ");
                Console.WriteLine("\n" + kq);
                break;
            }
            // 4. close
            stream.Close();
            client.Close();
            Console.ReadKey();
        }
    }
}