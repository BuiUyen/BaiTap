using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace TaoJson
{
    class Program
    {
        public class LopHS
        {
            public int SoLuong { get; set; }
            public List<HocSinh> DanhSachHocSinh { get; set; }
        }
        public class HocSinh
        {
            public int ID { get; set; }
            public string HoTen { get; set; }
            public int Tuoi { get; set; }
            public string GioiTinh { get; set; }

            public HocSinh()
            {

            }
            public HocSinh(int id, String hoten, int tuoi, string gioitinh)
            {
                ID = id;
                HoTen = hoten;
                Tuoi = tuoi;
                GioiTinh = gioitinh;
            }
        }

        static void Main(string[] args)
        {
            List<HocSinh> DanhSach = new List<HocSinh>();

            for (int i = 1; i <= 10000; i++)
            {
                DanhSach.Add(new HocSinh(i, HoTen_(), Tuoi_(), GioiTinh_()));
            }

            LopHS Output = new LopHS();
            Output.SoLuong = 10000;
            Output.DanhSachHocSinh = DanhSach;

            string json = JsonConvert.SerializeObject(Output);//Tao ra file json

            File.WriteAllText(@"C:\Users\ADMIN\Desktop\DanhSach.json", json);
            
            //foreach (HocSinh HS in DanhSach)
            //{
            //    Console.WriteLine(HS.ID + "." + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh);
            //}
            Console.ReadKey();
        }

        static Random rnd = new Random();

        static string HoTen_()
        {
            string HoTen;
            List<string> ListHo = new List<string> { "Nguyen", "Tran", "Le", "Pham", "Huynh", "Phan", "Vu", "Dang", "Bui", "Do", "Ho", "Ngo", "Duong", "Ly" };
            int h = rnd.Next(ListHo.Count);

            List<string> ListDem = new List<string> { "Van", "Ba", "Manh", "Thi", "Dieu", "Duc", "Mau", "Xuan", "Thu", "Cam", "Chau", "Hong", "Hoang", "Hanh", "Dinh", "Dai", "Tien" };
            int d = rnd.Next(ListDem.Count);

            List<string> ListTen = new List<string> { "An", "Anh", "Bang", "Bao", "Han", "Hieu", "Huy", "Khoa", "Kiet", "Lam", "Linh", "My", "Ngoc", "Nhi", "Oanh", "Quang", "Quyen", "Tam", "Thuy", "Tram", "Tung", "Vy", "Uyen", "Trang" };
            int t = rnd.Next(ListTen.Count);

            HoTen = ListHo[h] + " " + ListDem[d] + " " + ListTen[t];

            return HoTen;
        }

        static int Tuoi_()
        {
            int T = rnd.Next(5, 40);
            return T;
        }

        static string GioiTinh_()
        {
            int GT = rnd.Next(0, 2);
            if (GT == 0)
            {
                return "nam";
            }
            return "nu";
        }
    }
}
