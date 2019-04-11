using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sent_file_sever
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
        public enum Quydoi
        {
            Tuoi = 1,
            HoTen = 2,
            Ten = 3,
            GioiTinh = 4
        };

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
    }

    public static class Sapxep
    {
        public static string SX(string a, int t)
        {
            XmlSerializer DanhsachHocSinh = new XmlSerializer(typeof(LopHS));
            LopHS LOP_A = new LopHS();

            using (TextReader reader = new StringReader(a))
            {
                LOP_A = (LopHS)DanhsachHocSinh.Deserialize(reader);
            }

            TachTen(LOP_A.DanhSachHocSinh);

            string strGTT;
            int ThuocTinh = t;
            if (ThuocTinh == 5)
            {
                strGTT = "";
                foreach (HocSinh HS in SapXepGTvaT(LOP_A.DanhSachHocSinh))
                {
                    strGTT += "\n\n  " + HS.ID + "." + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh + "\n";

                }
                goto end;
            }

            string str = "";
            foreach (HocSinh HS in SapXep(LOP_A.DanhSachHocSinh, ThuocTinh))
            {
                str += "\n\n  " + HS.ID + "." + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh + "\n";

            }
            return str;
        end:
            return strGTT;
        }

        //----------------------------------Phan sap xep chinh---------------------------------------------------
        static List<HocSinh> SapXep(List<HocSinh> Input, int ThuocTinh)
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

        //----------------------------------Tach nam va nu va sap xep theo ten------------------------------------
        static List<HocSinh> NamHocSinh(List<HocSinh> Input)
        {
            List<HocSinh> Output = new List<HocSinh>();

            foreach (HocSinh HS in Input)
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
        static List<HocSinh> SapXepGTvaT(List<HocSinh> Input)
        {
            List<HocSinh> Output = SapXep(NamHocSinh(Input), 3);

            foreach (HocSinh HS in SapXep(NuHocSinh(Input), 3))
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
            Console.WriteLine("0. Thoat.");
            Console.Write("=======>Lua chon:");
            int TT = Convert.ToInt32(Console.ReadLine());
            return TT;
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
        static string SortText(string _a, string _b)
        {
            string a = _a ?? "";
            string b = _b ?? "";

            for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
            {
                if (a[i] < b[i])
                {
                    return a;
                }
                else if (a[i] > b[i])
                {
                    return b;
                }
                if (a[i] == b[i])
                {
                    if (i == a.Length - 1) return a;
                    if (i == b.Length - 1) return b;
                }
            }
            return b;
        }
    }
}
