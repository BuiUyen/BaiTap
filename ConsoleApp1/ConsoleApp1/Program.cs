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
            List<HocSinh> DanhSach1 = new List<HocSinh>();
            List<HocSinh> DanhSach2 = new List<HocSinh>();
            List<HocSinh> DanhSach3 = new List<HocSinh>();
            List<HocSinh> DanhSach4 = new List<HocSinh>();
            foreach (HocSinh HS in DanhSach)
            {
                DanhSach1.Add(HS);
                DanhSach2.Add(HS);
                DanhSach3.Add(HS);
                DanhSach4.Add(HS);
            }
            TachTen(DanhSach);
            InDanhSach(DanhSach);

            start:
            int ThuocTinh = LuaChon();
            if (ThuocTinh == 6)
            {
                Console.WriteLine("\n------------Close!!!------------");
                goto end;
            }                
            if (ThuocTinh == 5)
            {
                InDanhSach(SapXepGTvaT(DanhSach4, ThuocTinh));
                goto end;
            }
            Stopwatch tg = new Stopwatch();
            //------------------------------Do thoi gian----------------------------------------------------------
            tg.Start();
            InDanhSach( SapXep(DanhSach1, ThuocTinh));
            tg.Stop();
            Console.WriteLine("\nThoi gian thuc hien sap xep qua List moi: " + tg.ElapsedMilliseconds + "ms.");
            ////-------------------------------Sap xep noi bot------------------------------------------------------
            //tg.Start();
            //InDanhSach(SapXepNoiBot(DanhSach2, ThuocTinh));
            //tg.Stop();
            //Console.WriteLine("\nThoi gian thuc hien sap xep noi bot: " + tg.ElapsedMilliseconds+ "ms.");
            ////----------------------------------------------------------------------------------------------------
            //tg.Start();
            //InDanhSach(SapXepLinq(DanhSach3, ThuocTinh));
            //tg.Stop();
            //Console.WriteLine("\nThoi gian thuc hien sap xep Linq: " + tg.ElapsedMilliseconds + "ms.");
            ////----------------------------------------------------------------------------------------------------
            goto start;
            end:
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

        //----------------------------------Sap xep LinQ----------------------------------------------------------
        static List<HocSinh> SapXepLinq(List<HocSinh> Input, int ThuocTinh)
        {
            switch (ThuocTinh)
            {
                case (int)HocSinh.Quydoi.Tuoi:
                    Input = Input.OrderBy(x => x.Tuoi).ToList();
                    break;

                case (int)HocSinh.Quydoi.HoTen:
                    Input = Input.OrderBy(x => x.HoTen).ToList();
                    break;

                case (int)HocSinh.Quydoi.Ten:
                    Input = Input.OrderBy(x => x.Ten).ToList();
                    break;

                case (int)HocSinh.Quydoi.GioiTinh:
                    Input = Input.OrderBy(x => x.GioiTinh).ToList();
                    break;
            }            
            return Input;
        }

        //----------------------------------Tach nam va nu va sap xep theo ten------------------------------------
        static List<HocSinh> NamHocSinh(List<HocSinh> Input)
        {
            List<HocSinh> Output = new List<HocSinh>();

            foreach(HocSinh HS in Input)
            {
                if (HS.GioiTinh == "nam")
                {
                    Output.Add(HS);
                }
            }
            return Output;
        }
        static List<HocSinh> NuHocSinh(List<HocSinh> Input)
        {
            List<HocSinh> Output = new List<HocSinh>();

            foreach (HocSinh HS in Input)
            {
                if (HS.GioiTinh == "nu")
                {
                    Output.Add(HS);
                }
            }
            return Output;
        }
        static List<HocSinh> SapXepGTvaT(List<HocSinh> Input,int ThuocTinh)
        {
            List<HocSinh> Output = SapXep(NamHocSinh(Input), 3);

            foreach (HocSinh HS in SapXep(NuHocSinh(Input),3))
            {
                Output.Add(HS);
            }
            return Output;
        }

        //----------------------------------So sanh hai phan tu cung thuoc tinh-----------------------------------
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
                default:
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