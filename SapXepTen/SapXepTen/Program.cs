using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SapXepTen
{
    public class HocSinh
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public string Ten { get; set; }
        public string VAR { get; set; }

        public HocSinh()
        {

        }
        public HocSinh(String hoten, int tuoi, string gioitinh)
        {
            HoTen = hoten;
            Tuoi = tuoi;
            GioiTinh = gioitinh;
        }
    }

    public class Program
    {
        public static void Main()
        {
            List<HocSinh> DanhSach = new List<HocSinh>()
            {
                new HocSinh ("Nguyen Van X",14,"nam"),
                new HocSinh ("Nguyen Hoang Nam",18,"nam"),
                new HocSinh ("Ninh Tuan Anh",5, "nam"),
                new HocSinh ("Bui Thi Huyen",10,"nu"),
                new HocSinh ("Vu Binh Duong",16, "nam"),
                new HocSinh ("Pham Thi Hue", 20,"nu"),
                new HocSinh ("Nguyen Thi Chinh",11, "nu"),
                new HocSinh ("Phan Thi Yen",10, "nu"),
                new HocSinh ("Phan Thi Hong Anh", 18, "nu"),
                new HocSinh ("Pham Duc Huy",5, "nam"),
                new HocSinh ("Nguyen Thi Huyen", 8, "nu"),
                new HocSinh ("Pham Thi Chinh",22, "nu"),
            };

            //Cat lay ten de sap xep theo ten
            foreach (HocSinh HS in DanhSach)
            {
                string[] cut = HS.HoTen.Split(' ');
                HS.Ten = cut[cut.Length - 1];
            }

            //SapXepTuoi(DanhSach);  Ham sap xep tuoi

            //Sort(DanhSach,"GioiTinh"); // Ham sap xep  Sort(DanhSach,"x") voi x la thuoc tinh can sap xep
            SX2L(DanhSach);            
            
            //DanhSach = DanhSach.OrderBy(x => x.Ten).ToList(); //Sap xep Linq

            Console.WriteLine("\n\nDanh sach hoc sinh: ");
            foreach (HocSinh HS in DanhSach)
            {
                Console.WriteLine("\n" + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh);
            }
            Console.ReadKey();
        }

        // Sap xep theo tuoi
        static void SapXepTuoi(List<HocSinh> Input)
        {
            for (int i = 0; i < Input.Count; i++)
            {
                for (int j = i+1; j < Input.Count; j++)
                {
                    if (Input[i].Tuoi > Input[j].Tuoi)
                    {
                        HocSinh tg = Input[i];
                        Input[i] = Input[j];
                        Input[j] = tg;
                    }                    
                }                
            }            
        }

        // Sap xep theo thuoc tinh chuoi ki tu
        static void Sort(List<HocSinh> Input, string ThuocTinh)
        {
            foreach (HocSinh HS in Input)
            {
                if (ThuocTinh == "HoTen")
                {
                    HS.VAR = HS.HoTen;
                }
                if (ThuocTinh == "Ten")
                {
                    HS.VAR = HS.Ten;
                }
                if (ThuocTinh == "GioiTinh")
                {
                    HS.VAR = HS.GioiTinh;
                }
            }

            for (int i = 0; i < Input.Count; i++)
            {
                for (int j = i + 1; j < Input.Count; j++)
                {
                    for (int v = 0; v < Math.Min(Input[i].VAR.Length, Input[j].VAR.Length); v++)
                    {
                        if (Input[i].VAR[v] > Input[j].VAR[v])
                        {
                            HocSinh tg = Input[i];
                            Input[i] = Input[j];
                            Input[j] = tg;
                        }
                        else
                        {
                            if (Input[i].VAR[v] < Input[j].VAR[v]) break;
                        }
                    }
                }
            }            
        }

        static void SX2L(List<HocSinh> Input)
        {            
            List<HocSinh> NuHocSinh = new List<HocSinh>();
            for (int i = 0; i < Input.Count ; i++)
            {
                if (Input[i].GioiTinh == "nu")
                {
                    NuHocSinh.Add(Input[i]);
                    Input.Remove(Input[i]);
                    i--;
                }
            }           

            Sort(Input,"Ten");
            Sort(NuHocSinh,"HoTen");

            foreach (HocSinh HS in NuHocSinh)
            {
                Input.Add(HS);
            }

            foreach (HocSinh HS in Input)
            {
                Console.WriteLine("\n" + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh);
            }
        }
    }
}

