using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapXepTen_OK
{
    public static class SapXep
    {
        //------------------------------------In danh sach hoc sinh----------------------------------------------------
        public static void InDanhSach(IList<HocSinh> Input)
        {
            int i = 1;
            Console.WriteLine("\n\n-------------------Danh sach hoc sinh----------------------------------------");
            foreach (HocSinh HS in Input)
            {
                Console.WriteLine(i + "." + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh);
                i++;
            }
            Console.ReadKey();
        }
        //------------------------------------Sap xep theo tuoi--------------------------------------------------------        
        public static void SortNum(IList<HocSinh> Input, IList<HocSinh> Output)
        {
            int dem;
            for (int i = 0; i < Input.Count; i++)
            {
                dem = -1;
                for (int j = 0; j < Output.Count; j++)
                {
                    if (Input[i].Tuoi < Output[j].Tuoi)
                    {
                        dem = j;
                        break;
                    }
                }
                if (dem >= 0)
                {
                    Output.Insert(dem, Input[i]);
                }
                else
                {
                    Output.Add(Input[i]);
                }
            }
        }
        //------------------------------------Sap xep theo thuoc tinh chuoi ki tu--------------------------------------
        public static void SortChar(IList<HocSinh> Input, IList<HocSinh> Output, string ThuocTinh)
        {
            foreach (HocSinh HS in Input)
            {
                if (ThuocTinh == "ID")
                {
                    HS.VAR = HS.ID;
                }
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

            int dem, i;
            for (i = 0; i < Input.Count; i++)
            {
                dem = -1;
                for (int j = 0; j < Output.Count; j++)
                {
                    for (int v = 0; v < Math.Min(Input[i].VAR.Length, Output[j].VAR.Length); v++)
                    {
                        if (Input[i].VAR[v] < Output[j].VAR[v])
                        {
                            dem = j;
                            break;
                        }

                        if (Input[i].VAR[v] > Output[j].VAR[v])
                        {
                            break;
                        }

                        if (Input[i].VAR[v] == Output[j].VAR[v] && v == Input[i].VAR.Length - 1)
                        {
                            dem = j;
                            break;
                        }
                    }
                    if (dem >= 0) break;
                }
                if (dem >= 0)
                {
                    Output.Insert(dem, Input[i]);
                }
                else
                {
                    Output.Add(Input[i]);
                }
            }
        }
        //------------------------------------Sap xep gioi tinh roi sap xep theo ten-----------------------------------
        public static void SX2L(IList<HocSinh> Input, IList<HocSinh> Result)
        {
            IList<HocSinh> Input2 = new List<HocSinh>();

            for (int i = 0; i < Input.Count; i++)
            {
                if (Input[i].GioiTinh == "nu")
                {
                    Input2.Add(Input[i]);
                    Input.Remove(Input[i]);
                    i--;
                    // Tach danh sach hoc sinh ra nam va nu de sap xep roi gop lai
                }
            }
            IList<HocSinh> Result2 = new List<HocSinh>();
            SortChar(Input, Result, "Ten");
            SortChar(Input2, Result2, "Ten");
            foreach (HocSinh HS in Result2)
            {
                Result.Add(HS);
            }
        }
    }
}
