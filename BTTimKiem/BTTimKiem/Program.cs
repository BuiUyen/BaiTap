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
    public class Ten
    {
        public List<string> Name = new List<string>();
    }

    class BT
    {
        static void Main(string[] args)
        {
            String json_data = File.ReadAllText(@"C:\Users\ADMIN\Desktop\DanhSach.json");
            LopHS mLopHS = JsonConvert.DeserializeObject<LopHS>(json_data);
            List<HocSinh> List = mLopHS.DanhSachHocSinh;
            Console.OutputEncoding = Encoding.UTF8;
            TachTen(List);
            //In ra danh sach hoc sinh
            Console.WriteLine("----------Danh Sách Học Sinh Ban Đầu------------");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(List[i].ID + "." + List[i].HoTen + " ....... " + List[i].Tuoi + " ....... " + List[i].GioiTinh);
            }
            Console.WriteLine("...");            
            Console.WriteLine(List[List.Count - 1].ID + "." + List[List.Count - 1].HoTen + " ....... " + List[List.Count - 1].Tuoi + " ....... " + List[List.Count - 1].GioiTinh);
            Console.WriteLine("\n=> Danh Sách Có {0} Học Sinh.", List.Count);
            Console.WriteLine("\n- - - Chương trình tìm kiếm - - -" +
               "\n* Tìm kiếm theo tên hoặc tuổi: " +
               "\n-) Có thể nhập vào một tên." +
               "\n-) Có thể nhập vào một số tuổi." +
               "\n-) Có thể nhập vào > , >= , < , <= kèm theo số tuổi để tìm kiếm." +
               "\n-) Có thể nhập vào cấu trúc 'a - b' để tìm kiếm HS trong khoảng tuổi từ a đến b." +
               "\n-) Cos thể nhập vào giới tính.");
            //Thuat toan chinh
            Thuc_hien(List);
            Console.ReadKey();
        }

        static void Thuc_hien(List<HocSinh> Input)
        {
            List<HocSinh> Output = new List<HocSinh>();
            Console.Write("\n\n***Nhập vào giá trị tìm kiếm: ");
            string str = Console.ReadLine();
            foreach (char i in str)
            {
                if (!Char.IsLetterOrDigit(i) || str.Contains("-"))
                {
                    Output = STuoi2(Input, str);
                    break;
                }
                else
                {
                    if (Int32.TryParse(str, out int t))
                    {
                        Output = STuoi1(Input, t);
                        break;
                    }
                    else
                    {
                        Ten T = new Ten();
                        mTen(Input, T);

                        if (str.ToLower() == "nam" || str.ToLower() == "nu")
                        {
                            Console.Write("Bạn muốn tìm: \n +)HS có giới tính {0} (Nhấn phím A). \n +)HS tên '{1}'(Nhấn phím bất kì trong các phím còn lại):  ", str.ToLower(), str);
                            var key = Console.ReadKey().Key;
                            if ( key == ConsoleKey.A)
                            {
                                Console.WriteLine("\n=>Tìm kiếm HS có giới tính : " + str.ToLower());
                                Output = SGioiTinh(Input, str.ToLower());
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\n=>Tìm kiếm HS có tên : " + str.ToLower());
                            }
                        }
                        Console.WriteLine("\n=>Tìm kiếm HS có tên : " + str);
                        Output = SName(Input, T, str);
                        break;
                    }
                }
            }

            if (Output.Count > 1)
            {
                Console.Write("\nBạn muốn tiếp tục tìm kiếm trong danh sách trên: (y/n)?  ");
                var yn = Console.ReadKey().Key;
                do
                {
                    if (yn != ConsoleKey.Y)
                    {
                        if (yn == ConsoleKey.N)
                        {
                            Console.WriteLine("\n###Kết thúc chương trình###");
                            break;
                        }
                        Console.WriteLine("\n!!!Bạn nhập chưa đúng!!! ");
                        Console.Write("\nBạn muốn tiếp tục tìm kiếm trong danh sách trên: (y/n)?  ");
                        yn = Console.ReadKey().Key;
                    }

                    if (yn == ConsoleKey.Y)
                    {
                        Thuc_hien(Output);
                    }
                }
                while (yn != ConsoleKey.Y);
            }

            if (Output.Count == 1)
            {
                Console.WriteLine("\n===>Đã ra kết quả cần tìm.");
            }

            if (Output.Count == 0)
            {
                Console.WriteLine("Thực hiện lại tìm kiếm với danh sách ban đầu.");
                Thuc_hien(Input);
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

        static void mTen(List<HocSinh> Input, Ten T)
        {
            foreach (HocSinh HS in Input)
            {
                if (!T.Name.Contains(HS.Ten.ToLower()))
                {
                    T.Name.Add(HS.Ten.ToLower());
                }

            }
        }

        static List<HocSinh> STuoi1(List<HocSinh> Input, int tuoi)//Tim mot gi tri tuoi
        {
            List<HocSinh> Output = new List<HocSinh>();
            Console.WriteLine("\n=> Bạn muốn tìm các HS có tuổi là {0}", tuoi);
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
                if (char_array[1] == '=')
                {
                    int a = Convert.ToInt32(str.Remove(0, 2));
                    Console.WriteLine("\n=> Bạn muốn tìm các HS có độ tuổi lớn hơn hoặc bằng {0}.", a);
                    foreach (HocSinh HS in Input)
                    {
                        if (HS.Tuoi >= a)
                        {
                            Output.Add(HS);
                        }
                    }
                }
                else
                {
                    int a = Convert.ToInt32(str.Remove(0, 1));
                    Console.WriteLine("\n=> Bạn muốn tìm các HS có độ tuổi lớn hơn {0}.", a);
                    foreach (HocSinh HS in Input)
                    {
                        if (HS.Tuoi > a)
                        {
                            Output.Add(HS);
                        }
                    }
                }
            }

            if (char_array[0] == '<')
            {
                if (char_array[1] == '=')
                {
                    int a = Convert.ToInt32(str.Remove(0, 2));
                    Console.WriteLine("\n=> Bạn muốn tìm các HS có độ tuổi nhỏ hơn hoặc bằng {0}.", a);
                    foreach (HocSinh HS in Input)
                    {
                        if (HS.Tuoi <= a)
                        {
                            Output.Add(HS);
                        }
                    }
                }
                else
                {
                    int a = Convert.ToInt32(str.Remove(0, 1));
                    Console.WriteLine("\n=> Bạn muốn tìm các HS có độ tuổi nhỏ hơn {0}.", a);
                    foreach (HocSinh HS in Input)
                    {
                        if (HS.Tuoi < a)
                        {
                            Output.Add(HS);
                        }
                    }
                }
            }

            if (str.Contains("-"))
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
                Console.WriteLine("\n=> Bạn muốn tìm các HS có độ tuổi từ: {0} đến {1}.", a, b);
                foreach (HocSinh HS in Input)
                {
                    if (a <= HS.Tuoi && HS.Tuoi <= b)
                    {
                        Output.Add(HS);
                    }
                }
            }

            InDanhSach(Output);
            return Output;
        }

        static List<HocSinh> SName(List<HocSinh> Input, Ten T, string str)//Tim ten co chua thanh phan tim kiem
        {
            List<HocSinh> Output = new List<HocSinh>();
            if (T.Name.Contains(str.ToLower()))
            {
                foreach (HocSinh HS in Input)
                {
                    if (HS.Ten.ToLower() == str.ToLower())
                    {
                        Output.Add(HS);
                    }
                }
            }
            else
            {
                foreach (HocSinh HS in Input)
                {
                    if (HS.HoTen.ToLower().Contains(str.ToLower()))
                    {
                        Output.Add(HS);
                    }
                }
            }
            InDanhSach(Output);
            return Output;
        }

        static List<HocSinh> SGioiTinh(List<HocSinh> Input, string str)
        {            
            List<HocSinh> Output = new List<HocSinh>();
            foreach (HocSinh HS in Input)
            {
                if (HS.GioiTinh == str)
                {
                    Output.Add(HS);
                }
            }
            InDanhSach(Output);
            return Output;
        }

        static void InDanhSach(List<HocSinh> Input)
        {
            int IC = Input.Count();
            if (IC == 0)
            {
                Console.WriteLine("\n!!!Không có giá trị cần tìm!!!");
                Console.WriteLine("-----------------------------------");
            }
            else
            {
                Console.WriteLine("\n-------------------Danh Sách Học Sinh--------------------------------------");
                if (IC > 8)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Console.WriteLine(Input[i].ID + "." + Input[i].HoTen + " ....... " + Input[i].Tuoi + " ....... " + Input[i].GioiTinh);
                    }
                    Console.WriteLine("...");                    
                    Console.WriteLine(Input[IC - 1].ID + "." + Input[IC - 1].HoTen + " ....... " + Input[IC - 1].Tuoi + " ....... " + Input[IC - 1].GioiTinh);
                    Console.Write("\n=> Có {0} kết quả cần tìm.", Input.Count);
                    Console.WriteLine(" Nhấm phím 'F1' để in đầy đủ danh sách.");
                    if (Console.ReadKey().Key == ConsoleKey.F1)
                    {
                        foreach (HocSinh HS in Input)
                        {
                            Console.WriteLine(HS.ID + "." + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh);
                        }
                    }
                }
                else
                {
                    foreach (HocSinh HS in Input)
                    {
                        Console.WriteLine(HS.ID + "." + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh);
                    }
                    Console.WriteLine("\n=> Có {0} kết quả cần tìm.", IC);
                }
            }
        }
    }
}