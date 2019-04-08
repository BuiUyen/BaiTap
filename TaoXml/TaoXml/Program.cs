using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaoXml
{
    class Program
    {
        [XmlRoot(ElementName = "DanhSachHocSinh")]
        public class LopHS
        {
            [XmlElement(ElementName = "HocSinh")]
            public List<HocSinh> DanhSachHocSinh { get; set; }
        }

        [XmlRoot(ElementName = "HocSinh")]
        public class HocSinh
        {
            [XmlElement(ElementName = "ID")]
            public int ID { get; set; }
            [XmlElement(ElementName = "HoTen")]
            public string HoTen { get; set; }
            [XmlElement(ElementName = "Tuoi")]
            public int Tuoi { get; set; }
            [XmlElement(ElementName = "GioiTinh")]
            public string GioiTinh { get; set; }
            public string Ten { get; set; }

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

            static void Main(string[] args)
            {
                List<HocSinh> DanhSach = new List<HocSinh>();

                for (int x = 1; x <= 10000; x++)
                {
                    DanhSach.Add(new HocSinh(x, HoTen_(), Tuoi_(), GioiTinh_()));
                }

                string Kqxml = "<?xml version='1.0'?>" + "\n<DanhSachHocSinh>";
                int i = 0;
                foreach (HocSinh HS in DanhSach)
                {
                    Kqxml += "\n    <HocSinh>" + "\n         <ID>" + DanhSach[i].ID + "</ID>" + "\n         <HoTen>" + DanhSach[i].HoTen + "</HoTen>" + "\n         <Tuoi>" + DanhSach[i].Tuoi + "</Tuoi>" + "\n         <GioiTinh>" + DanhSach[i].GioiTinh + "</GioiTinh>" + "\n    </HocSinh>";
                    i++;
                }
                Kqxml += "\n</DanhSachHocSinh>";
                Console.WriteLine(Kqxml);
                File.WriteAllText(@"C:\Users\ADMIN\Desktop\DanhSach.xml", Kqxml);
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
}
