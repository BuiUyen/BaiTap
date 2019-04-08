using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("___________________ SERVER ________________");
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep;
            Console.Write("Please Choose mode <1> Receive Mode, <2> Send Mode : ");
            int t = int.Parse(Console.ReadLine());
            if (t == 1)  //receive mode
            {
                Console.WriteLine("______________< RECEIVE MODE >_______________");

                //____________ Dong vai tro server nhan du lieu ___________________
                ep = new IPEndPoint(IPAddress.Any, 9999);
                sck.Bind(ep);
                sck.Listen(5);
                Console.WriteLine("San sang ket noi..");
                Socket sckClient = sck.Accept(); 
                Console.WriteLine("Da ket noi! San sang nhan file");
                //________________ receive _____________________
                int size;
                while (true)
                {
                    byte[] data = new byte[1024];
                    size = sckClient.Receive(data);
                    string[] s = Encoding.ASCII.GetString(data, 0, size).Split(new char[] { ',' }); // nhan ten file, duong dan, size.
                    Console.WriteLine("file Name: {0} ", s[0]);
                    Console.WriteLine("Path to store: {0} ", s[1]);
                    long length = long.Parse(s[2]);
                    byte[] buffer = new byte[1024];
                    byte[] fsize = new byte[length]; //khai bao mang byte de chua du lieu
                    long n = length / buffer.Length;  // tính số frame được gửi qua
                    for (int i = 0; i < n; i++)
                    {
                        size = sckClient.Receive(fsize, fsize.Length, SocketFlags.None);
                        Console.WriteLine("Received frame {0}/{1}", i, n);
                    }
                    FileStream fs = new FileStream(s[1] +"/"+ s[0], FileMode.Create);  // luu file s[0] vao duong dan s[1]
                    fs.Write(fsize, 0, fsize.Length);
                    fs.Close();
                    Console.WriteLine("Done."); break;
                }
                sckClient.Close();
                //______________________________________________
            }
            else if (t == 2) // send mode
            {
                Console.WriteLine("______________< SEND MODE >_______________");
                //__________________ Dong vai tro client gui du lieu ____________________
                Console.Write("Enter file to send : "); //nhap đường dẫn tên file
                string path = Console.ReadLine();
                FileInfo file = new FileInfo(path);
                if (!file.Exists)  //kiểm tra file có tồn tại k
                {
                    Console.WriteLine("Not exist file {0}!", path);
                }
                string filename = path.Substring(path.LastIndexOf("/") + 1); // tách tên file khỏi đường dẫn
                Console.Write("Path on store to server : "); // nhập đường dẫn lưu file
                string save = Console.ReadLine();
                Console.Write("Send to IP : ");
                string ip = Console.ReadLine();
                ep = new IPEndPoint(IPAddress.Parse(ip), 9999);
                sck.Connect(ep);
                Console.WriteLine("Connected! Sending file {0} to {1} on Server {2}", path, save, ip);
                //________________ send ________________________
                byte[] data = new byte[1024];
                byte[] fsize = new byte[file.Length]; // tạo mảng chứa dữ liệu
                FileStream fs = new FileStream(path, FileMode.Open); // đọc thông tin file đã nhập
                fs.Read(fsize, 0, fsize.Length);
                fs.Close();
                while (true)
                {
                    string s = filename + "," + save + "," + file.Length.ToString();
                    sck.Send(Encoding.ASCII.GetBytes(s));
                    long n = file.Length / data.Length;  //tính số frame phải gửi
                    for (int i = 0; i < n; i++)
                    {

                        Console.WriteLine("Sending frame {0}/{1}", i, n);
                        sck.Send(fsize, fsize.Length, 0);
                    }
                    Console.WriteLine("Done."); break;
                }
                //______________________________________________

            }
            else
            {
                Console.WriteLine("Wrong request!!");
            }
            sck.Close();
            Console.ReadLine();
        }
    }
}
