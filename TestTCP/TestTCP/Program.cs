using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TestTCP
{
    public class Program
    {
        private const int PORT = 9999;

        static ASCIIEncoding encoding = new ASCIIEncoding();

        public static void Main()
        {
            IPAddress DiaChi = IPAddress.Parse("192.168.5.95");
            TcpListener listener = new TcpListener(DiaChi, PORT);

            // 1. Khoi tao
            listener.Start();

            Console.WriteLine("Dia chi ket noi: " + listener.LocalEndpoint);
            Console.WriteLine("Dang cho ket noi..............");
            Socket socket = listener.AcceptSocket();
            Console.WriteLine("Da ket noi voi mach khach:  " + socket.RemoteEndPoint);

            var stream = new NetworkStream(socket);
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            while (true)
            {
                // 2. Nhan du lieu               
                string str = reader.ReadToEnd();
                //Console.WriteLine(Sapxep.SX(str, 3));

                // 3. Gui ket qua
                writer.WriteLine(str);
                Console.WriteLine(str);
                break;
            }
            // 4. close
            stream.Close();
            socket.Close();
            listener.Stop();


            Console.ReadKey();
        }
    }
}
