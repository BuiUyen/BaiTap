using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BaiTap2
{
    public class HocSinh
    {
        public enum Quydoi
        {
            Tuoi = 1,
            HoTen = 2,
            Ten = 3,
            GioiTinh = 4
        };
        public int ID { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
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
    }

    class UYEN
    {
        static void Main()
        {
            List<HocSinh> DanhSach = new List<HocSinh>()
            {
                new HocSinh (1,"Nguyen Van X",14,"nam"),
                new HocSinh (2,"Nguyen Hoang Nam",18,"nam"),
                new HocSinh (3,"Giu Tuan H",5, "nam"),
                new HocSinh (4,"Bui Thi Huyen",10,"nu"),
                new HocSinh (5,"Vu Binh Duong",16, "nam"),
                new HocSinh (6,"Pham Thi Hue", 20,"nu"),
                new HocSinh (7,"Nguyen Thi Chinh",11, "nu"),
                new HocSinh (8,"Phan Thi Yen",10, "nu"),
                new HocSinh (9,"Dinh Thi Hong Anh", 18, "nu"),
                new HocSinh (10,"Pham Duc Huy",5, "nam"),
                new HocSinh (11,"Nguyen Thi Huyen", 8, "nu"),
                new HocSinh (12,"Pham Thi Chi",22, "nam"),
            };
            Stopwatch tg = new Stopwatch();
            tg.Start();
            //------------------------------Do thoi gian---------------------------------------------------------
            TachTen(DanhSach);
            InDanhSach(DanhSach);            
            InDanhSach( SapXepNoiBot(DanhSach, LuaChon()));
            //----------------------------------------------------------------------------------------------------
            tg.Stop();
            Console.WriteLine("\nThoi gian thuc hien: " + tg.ElapsedMilliseconds+ "ms.");
            Console.ReadKey();
        }
        //----------------------------------Phan sap xep chinh----------------------------------------------------
        static List<HocSinh> SapXep( List<HocSinh> Input, int ThuocTinh)
        {
            List<HocSinh> Output = new List<HocSinh>();
            int i, j, dem;
            for (i = 0; i < Input.Count; i++)
            {
                dem = -1;
                for (j = 0; j < Output.Count; j++)
                {
                    if (SoSanhPhanTu(Input[i], Output[j], ThuocTinh) == Input[i].ID)
                    {
                        dem = j;
                        break;
                    }
                }
                if (dem >= 0)
                {
                    Output.Insert(j, Input[i]);
                }
                else Output.Add(Input[i]);
            }
            return Output;
        }
        //----------------------------------Cach sap xep noi bot--------------------------------------------------
        static List<HocSinh> SapXepNoiBot( List<HocSinh> Input, int ThuocTinh)
        {
            for ( int i = 0 ; i < Input.Count ; i++)
            {
                for (int j = i + 1; j < Input.Count; j++)
                {
                    if (SoSanhPhanTu(Input[i], Input[j], ThuocTinh)==Input[j].ID)
                    {
                        HocSinh TG = Input[i];
                        Input[i] = Input[j];
                        Input[j] = TG;
                    }
                }
            }
            return Input;
        }
        //----------------------------------So sanh hai pahn tu cung thuoc tinh-----------------------------------
        static int SoSanhPhanTu(HocSinh a, HocSinh b, int ThuocTinh)
        {
            switch (ThuocTinh)
            {
                case (int)HocSinh.Quydoi.Tuoi:
                    if (SortNum(a.Tuoi, b.Tuoi) == a.Tuoi)
                    {
                        return a.ID;
                    }
                    break;

                case (int)HocSinh.Quydoi.HoTen:
                    if (SortText(a.HoTen, b.HoTen) == a.HoTen)
                    {
                        return a.ID;
                    }
                    break;

                case (int)HocSinh.Quydoi.Ten:
                    if (SortText(a.Ten, b.Ten) == a.Ten)
                    {
                        return a.ID;
                    }
                    break;

                case (int)HocSinh.Quydoi.GioiTinh:
                    if (SortText(a.GioiTinh, b.GioiTinh) == a.GioiTinh)
                    {
                        return a.ID;
                    }
                    break;
            }
            return b.ID;
        }
        //-----------------------------------Tach lay ten tu ho va ten--------------------------------------------
        static void TachTen(List<HocSinh> Input)
        {
            foreach (HocSinh HS in Input)
            {
                string[] cut = HS.HoTen.Split(' ');
                HS.Ten = cut[cut.Length - 1];
            }
        }
        //-----------------------------------Lua chon thuoc tinh sap xep------------------------------------------
        static int LuaChon()
        {
            Console.WriteLine("\nLua chon cach sap xep: ");
            Console.WriteLine("1. Sap xep theo tuoi.");
            Console.WriteLine("2. Sap xep theo ho ten.");
            Console.WriteLine("3. Sap xep theo ten.");
            Console.WriteLine("4. Sap xep theo gioi tinh.");
            Console.WriteLine("5. Sap xep theo gioi tinh roi theo ten.");
            Console.WriteLine("6. Thoat.");
            Console.Write("=======>Lua chon:");
            int TT = Convert.ToInt32(Console.ReadLine());
            return TT;
        }
        //-----------------------------------In danh sach hs------------------------------------------------------
        static void InDanhSach(List<HocSinh> Input)
        {
            Console.WriteLine("\n\n-------------------Danh sach hoc sinh----------------------------------------");
            foreach (HocSinh HS in Input)
            {
                Console.WriteLine(HS.ID + "." + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh);
            }            
        }
        //------------------------------------Chon ra so dung truoc-----------------------------------------------
        static int SortNum(int a, int b)
        {
            if (a < b)
            {
                return a;
            }
            return b;
        }
        //------------------------------------Chon ra string dung truoc-------------------------------------------
        static string SortText(string a, string b)
        {
            for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
            {
                if (a[i] < b[i])
                {                    
                    return a;
                }
                else if(a[i] > b[i])
                {                    
                    return b;
                }

                if (a[i] == b[i])
                {
                    if (i == a.Length - 1)  return a;
                    if (i == b.Length - 1) return b;
                }               
            }
            return b;
        }        
    }
}