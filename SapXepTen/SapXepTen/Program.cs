using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapXepTen
{
    public class HocSinh
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public string Ten { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            List<HocSinh> mHocSinh = new List<HocSinh>()
            {

            new HocSinh () { HoTen= "Nguyen Hoang Nam", Tuoi = 18, GioiTinh="nam"},
            new HocSinh () { HoTen= "Le Tuan Anh", Tuoi =5, GioiTinh = "nam"},
            new HocSinh () { HoTen= "Nguyen Thi Huyen",Tuoi = 10, GioiTinh= "nu"},
            new HocSinh () { HoTen= "Vu Binh Duong", Tuoi =16,GioiTinh= "nam"},
            new HocSinh () { HoTen= "Pham Thi Hue",Tuoi = 20,GioiTinh= "nu"},
            new HocSinh () { HoTen= "Nguyen Thi Chinh",Tuoi = 11,GioiTinh= "nu"},
            new HocSinh () { HoTen= "Le Thi Hoai",Tuoi = 10,GioiTinh= "nu"},
            new HocSinh () { HoTen= "Phan Thi Hong Hao",Tuoi = 18,GioiTinh= "nu"},
            new HocSinh () { HoTen= "Pham Duc Huy",Tuoi = 5,GioiTinh= "nam"},
            new HocSinh () { HoTen= "Nguyen Thi Huyen",Tuoi = 8,GioiTinh= "nu"},
            new HocSinh () { HoTen= "Pham Thi Chinh",Tuoi = 22,GioiTinh= "nu"},
            };

            //Cat lay ten de sap xep theo ten
            foreach (HocSinh HS in mHocSinh)
            {
                string[] cut = HS.HoTen.Split(' ');
                HS.Ten = cut[cut.Length - 1];
            }
            //Sap xep
            List<HocSinh> sd = mHocSinh.OrderBy(x => x.Ten).ThenBy(x => x.Tuoi).ToList();

            Console.WriteLine("\nDanh sach hoc sinh: ");
            foreach (HocSinh HS in sd)
            {
                Console.WriteLine("\n" + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh);
            }
            Console.ReadKey();


        }
    }
}

