using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTimKiem
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

    class BT
    {
        static void Main(string[] args)
        {
            String json_data = File.ReadAllText(@"C:\Users\ADMIN\Desktop\DanhSach.json");
            LopHS mLopHS = JsonConvert.DeserializeObject<LopHS>(json_data);
            List<HocSinh> List = mLopHS.DanhSachHocSinh;
            TachTen(List);
            foreach (HocSinh HS in List)
            {
                Console.WriteLine(HS.ID + "." + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh);
            }
            Thuc_hien(List);
            //InDanhSach(Nhi_Phan(List, 20));

            Console.ReadKey();
        }

        static void Thuc_hien(List<HocSinh> Input)
        {
            List<HocSinh> Output = new List<HocSinh>();
            Console.WriteLine("\nNhap vao gia tri tim kiem:");
            string str = Console.ReadLine();

            foreach (char i in str)
            {
                if (!Char.IsLetterOrDigit(i))
                {
                    Output = STuoi2(Input, str);                    
                }
            }

            if (Int32.TryParse(str, out int t))
            {
                Output = STuoi1(Input, t);
            }
            else
            {
                Output = SName(Input, str);
            }

            if (Output.Count > 1)
            {
                Thuc_hien(Output);
            }
        }

        static void TachTen(List<HocSinh> Input)
        {
            foreach (HocSinh HS in Input)
            {
                string[] cut = HS.HoTen.Split(' ');
                HS.Ten = cut[cut.Length - 1];
            }
        }

        static List<HocSinh> STuoi1(List<HocSinh> Input, int tuoi)//Tim mot gi tri tuoi
        {
            List<HocSinh> Output = new List<HocSinh>();
            foreach (HocSinh HS in Input)
            {
                if (HS.Tuoi == tuoi)
                {
                    Output.Add(HS);
                }
            }
            InDanhSach(Output);
            return Output;
        }

        static List<HocSinh> STuoi2(List<HocSinh> Input, string str)//Tim khoang gi tri tuoi
        {
            List<HocSinh> Output = new List<HocSinh>();
            var char_array = str.ToCharArray();
            if (char_array[0] == '>')
            {
                int b = Convert.ToInt32(str.Remove(0, 1));
                foreach (HocSinh HS in Input)
                {
                    if (HS.Tuoi > b)
                    {
                        Output.Add(HS);
                    }
                }
            }

            if (char_array[0] == '<')
            {
                int a = Convert.ToInt32(str.Remove(0, 1));
                foreach (HocSinh HS in Input)
                {
                    if (HS.Tuoi < a)
                    {
                        Output.Add(HS);
                    }
                }
            }

            if (Array.IndexOf(char_array, '-') > 0)
            {
                {
                    int char_ = Array.IndexOf(char_array, '-');
                    int a = (Convert.ToInt32(str.Substring(0, char_)));
                    int b = (Convert.ToInt32(str.Substring(char_ + 1, str.Length - char_ - 1)));
                    if (b < a)
                    {
                        int tg = b;
                        b = a;
                        a = tg;
                    }

                    foreach (HocSinh HS in Input)
                    {
                        if (a <= HS.Tuoi & HS.Tuoi <= b)
                        {
                            Output.Add(HS);
                        }
                    }
                }
            }
    
            InDanhSach(Output);
            return Output;
        }

        static List<HocSinh> SName(List<HocSinh> Input, string a)//Tim ten co chua thanh phan tim kiem
        {
            List<HocSinh> Output = new List<HocSinh>();
            foreach (HocSinh HS in Input)
            {
                string test = HS.HoTen;
                if (test.ToLower().Contains(a.ToLower()))
                {
                    Output.Add(HS);
                }
            }
            InDanhSach(Output);
            return Output;
        }

        static void InDanhSach(List<HocSinh> Input)
        {
            if (Input.Count == 0)
            {
                Console.WriteLine("\n=>Khong co gia tri can tim!!!");                
            }
            else
            {
                Console.WriteLine("\n\n-------------------Ket Qua----------------------------------------");
                if (Input.Count > 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine(Input[i].ID + "." + Input[i].HoTen + " ....... " + Input[i].Tuoi + " ....... " + Input[i].GioiTinh);
                    }
                    Console.WriteLine("...");
                }
                else
                {
                    foreach (HocSinh HS in Input)
                    {
                        Console.WriteLine(HS.ID + "." + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh);
                    }
                }
            }
        }

        static List<HocSinh> Nhi_Phan(List<HocSinh> Input, int tuoi)
        {
            List<HocSinh> List = new List<HocSinh>();
            foreach(HocSinh HS in List)
            {
                List.Add(HS);
            }
            int minNum = 0;
            int maxNum = List.Count - 1;
            List<HocSinh> Output = new List<HocSinh>();
            
            while (minNum <= maxNum)
            {
                int mid = (minNum + maxNum) / 2;
                if (tuoi == List[mid].Tuoi)
                {
                    Output.Add(List[mid]);
                    List.Remove(List[mid]);
                }
                else if (tuoi < List[mid].Tuoi)
                {
                    maxNum = mid - 1;
                }
                else
                {
                    minNum = mid + 1;
                }
            }
            return Output;
        }
    }
}
