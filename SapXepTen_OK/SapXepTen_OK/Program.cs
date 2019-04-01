using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SapXepTen_OK
{
    public class Program
    {
        public static void Main()
        {            
            IList<HocSinh> DanhSach = new List<HocSinh>()
            {
                new HocSinh ("0045","Nguyen Van Nam",14,"nam"),
                new HocSinh ("0532","Nguyen Hoang N",18,"nam"),
                new HocSinh ("5123","Giu Tuan Anh",5, "nam"),
                new HocSinh ("0321","Bui Thi Linh",10,"nu"),
                new HocSinh ("0958","Vu Binh Nam",16, "nam"),
                new HocSinh ("0335","Pham Thi Linh", 20,"nu"),
                new HocSinh ("6521","Nguyen Thi Chinh",11, "nu"),
                new HocSinh ("0009","Phai Thi Yen",10, "nu"),
                new HocSinh ("1165","Dinh Thi Hong Anh", 18, "nu"),
                new HocSinh ("3651","Pham Duc H",5, "nam"),
                new HocSinh ("9652","Nguyen Thi Huyen", 8, "nu"),
                new HocSinh ("5410","Pham Thi Chinh",22, "nam"),
            };

            //Cat lay ten de sap xep theo ten
            foreach (HocSinh HS in DanhSach)
            {
                string[] cut = HS.HoTen.Split(' ');
                HS.Ten = cut[cut.Length - 1];
            }
            SapXep.InDanhSach(DanhSach);

            //---------------------List lua chon sap xep--------------------------------------------------------------
            string lc;
            do
            {
                Console.WriteLine("\nLua chon cach sap xep: ");
                Console.WriteLine("1. Sap xep theo tuoi.");
                Console.WriteLine("2. Sap xep theo ten.");
                Console.WriteLine("3. Sap xep theo ho va ten.");
                Console.WriteLine("4. Sap xep theo gioi tinh.");
                Console.WriteLine("5. Sap xep theo gioi tinh roi theo ten.");
                Console.WriteLine("6. Thoat.");
                Console.Write(" =======> Lua chon:");
                lc = Console.ReadLine();
                IList<HocSinh> KetQua = new List<HocSinh>();
                switch (lc)
                {
                    case "1":
                        SapXep.SortNum(DanhSach, KetQua);
                        SapXep.InDanhSach(KetQua);
                        break;
                    case "2":
                        SapXep.SortChar(DanhSach, KetQua, "Ten");
                        SapXep.InDanhSach(KetQua);
                        break;
                    case "3":
                        SapXep.SortChar(DanhSach, KetQua, "HoTen");
                        SapXep.InDanhSach(KetQua);
                        break;
                    case "4":
                        SapXep.SortChar(DanhSach, KetQua, "GioiTinh");
                        SapXep.InDanhSach(KetQua);
                        break;
                    case "5":
                        SapXep.SX2L(DanhSach, KetQua);
                        SapXep.InDanhSach(KetQua);                        
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Khong hop le!!!");
                        Console.ReadKey();
                        break;
                }
            }
            while (lc != "0");
            Console.ReadKey();
        }

        
    }
}

