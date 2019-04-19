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
            public DateTime NamSinh { get; set; }
            public string HanhKiem { get; set; }
            public Diem mDiem { get; set; }

            public HocSinh()
            {

            }
            public HocSinh(int id, String hoten, int tuoi, string gioitinh, DateTime namsinh,string hanhkiem, Diem diem)
            {
                ID = id;
                HoTen = hoten;
                Tuoi = tuoi;
                GioiTinh = gioitinh;
                NamSinh = namsinh;
                mDiem = diem;
                HanhKiem = hanhkiem;
            }
        }
        public class Diem
        {
            public int DiemToan { get; set; }
            public int DiemVan { get; set; }
            public int DiemLi { get; set; }
            public int DiemHoa { get; set; }
        }

        static void Main(string[] args)
        {
            List<HocSinh> DanhSach = new List<HocSinh>();

            for (int i = 1; i <= 10000; i++)
            {
                int t = Tuoi_();
                DanhSach.Add(new HocSinh(i, HoTen_(), t, GioiTinh_(), NamSinh_(t),HanhKiem_(), Diem_()));
            }

            LopHS Output = new LopHS();
            Output.SoLuong = DanhSach.Count;
            Output.DanhSachHocSinh = DanhSach;

            string json = JsonConvert.SerializeObject(Output);//Tao ra file json

            File.WriteAllText(@"C:\Users\ADMIN\Desktop\DanhSach.json", json);

            foreach (HocSinh HS in DanhSach)
            {
                Console.WriteLine(HS.ID + "." + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh + " ....... " + HS.NamSinh.ToShortDateString());
            }
            Console.ReadKey();
        }

        static Random rnd = new Random();

        static string HoTen_()
        {
            string HoTen;
            List<string> ListHo = new List<string> { "Nu", "Nguyen", "Tran", "Le", "Pham", "Huynh", "Phan", "Vu", "Dang", "Bui", "Do", "Ho", "Ngo", "Duong", "Ly" };
            int h = rnd.Next(ListHo.Count);

            List<string> ListDem = new List<string> { "Van", "Ba", "Manh", "Thi", "Dieu", "Duc", "Mau", "Xuan", "Thu", "Cam", "Chau", "Hong", "Hoang", "Hanh", "Dinh", "Dai", "Tien" };
            int d = rnd.Next(ListDem.Count);

            List<string> ListTen = new List<string> { "Nam", "An", "Anh", "Bang", "Bao", "Han", "Hieu", "Huy", "Khoa", "Kiet", "Lam", "Linh", "My", "Ngoc", "Nhi", "Oanh", "Quang", "Quyen", "Tam", "Thuy", "Tram", "Tung", "Vy", "Uyen", "Trang" };
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

        static DateTime NamSinh_(int tuoi)
        {
            int nam = 2019 - tuoi;
            int thang = rnd.Next(1, 13);
            int ngay;
            if (thang == 1 || thang == 3 || thang == 5 || thang == 7 || thang == 8 || thang == 10 || thang == 12)
            {
                ngay = rnd.Next(1, 32);
            }
            else
            {
                if(thang!=2)
                {
                    ngay = rnd.Next(1, 31);
                }
                else
                {
                    if (nam % 4 == 0 && nam != 2000)
                    {
                        ngay = rnd.Next(1 , 30);
                    }
                    else
                    {
                        ngay = rnd.Next(1 , 29);
                    }
                }
            }
            DateTime mNamSinh = new DateTime(nam, thang, ngay);
            return mNamSinh;
        }

        static Diem Diem_()
        {
            Diem mDiem = new Diem();
            mDiem.DiemToan = rnd.Next(5, 11);
            mDiem.DiemVan = rnd.Next(5, 11);
            mDiem.DiemLi = rnd.Next(5, 11);
            mDiem.DiemHoa = rnd.Next(5, 11);
            return mDiem;
        }

        static string HanhKiem_()
        {
            List<string> HK = new List<string> { "Tot","Kha","Trung Binh","Yeu" };
            int hk = rnd.Next(0, 4);
            string mHanhKiem = HK[hk];
            return mHanhKiem;
        }
    }
}