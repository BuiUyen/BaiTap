using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NamSinh { get; set; }
        public string HanhKiem { get; set; }
        public Diem mDiem { get; set; }

        public HocSinh()
        {

        }
        public HocSinh(int id, String hoten, int tuoi, string gioitinh, DateTime namsinh, string hanhkiem, Diem diem)
        {
            ID = id;
            HoTen = hoten;
            Tuoi = tuoi;
            GioiTinh = gioitinh;
            NamSinh = namsinh;
            mDiem = diem;
            HanhKiem = hanhkiem;
        }
    }

    public class Diem
    {
        public int DiemToan { get; set; }
        public int DiemVan { get; set; }
        public int DiemLi { get; set; }
        public int DiemHoa { get; set; }
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
            Console.OutputEncoding = Encoding.UTF8;//in ra tiếng việt
            CultureInfo viVn = new CultureInfo("vi-VN");//in ra datetime với văn hóa việt nam
            TachTen(List);//Tách tên từ họ tên

            Console.WriteLine("----------Danh Sách Học Sinh Ban Đầu------------");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(List[i].ID + "." + List[i].HoTen + " ....... " + List[i].Tuoi + " ....... " + List[i].GioiTinh + " ....... " + List[i].NamSinh.ToString("d", viVn));
            }
            Console.WriteLine("...");
            Console.WriteLine(List[List.Count - 1].ID + "." + List[List.Count - 1].HoTen + " ....... " + List[List.Count - 1].Tuoi + " ....... " + List[List.Count - 1].GioiTinh + " ....... " + List[List.Count - 1].NamSinh.ToString("d", viVn));
            Console.WriteLine("\n=> Danh Sách Có {0} Học Sinh.", List.Count);
            Console.WriteLine("\n- - - Chương trình tìm kiếm - - -" +
               "\n* Tìm kiếm theo theo các thuộc tính sau đây: " +
               "\n-) Có thể nhập vào một tên." +
               "\n-) Có thể nhập vào một số tuổi." +
               "\n-) Có thể nhập vào > , >= , < , <= kèm theo số tuổi để tìm kiếm." +
               "\n-) Có thể nhập vào cấu trúc 'a - b' để tìm kiếm HS trong khoảng tuổi từ a đến b." +
               "\n-) Có thể nhập vào giới tính(nam hoặc nữ)" +
               "\n-) Có thể nhập vào ngày tháng năm sinh(dd/mm/yy với dd: ngày, mm: tháng, yy:năm)");

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
                if (str.Contains("/"))
                {
                    DateTime namsinh;
                    try
                    {
                        namsinh = DateTime.ParseExact(str, "dd/MM/yyyy", null);
                    }
                    catch
                    {
                        Console.WriteLine("\n!!!Định dạng ngày tháng năm không đúng!!!");
                        break;
                    }
                    Output = SNamSinh(Input, namsinh);
                    break;
                }

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
                            if (key == ConsoleKey.A)
                            {
                                Console.WriteLine("\n=>Tìm kiếm HS có giới tính : " + str.ToLower());
                                Output = SGioiTinh(Input, str.ToLower());
                                break;
                            }
                        }
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
                Console.WriteLine("\n\n=>Thực hiện lại tìm kiếm với danh sách ban đầu.");
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
            Output = Input.FindAll(delegate (HocSinh HS)
            {
                return HS.Tuoi == tuoi;
            });
            InDanhSach(Output);
            return Output;
        }

        static List<HocSinh> STuoi2(List<HocSinh> Input, string str)//Tim khoang gi tri tuoi
        {
            List<HocSinh> Output = new List<HocSinh>();

            if (str.Contains(">="))
            {
                str = str.Replace(">=", "");
                int Tuoi = Int32.Parse(str);
                Console.WriteLine("\n=> Bạn muốn tìm các HS có độ tuổi lớn hơn hoặc bằng {0}.", Tuoi);
                Output = Input.FindAll(delegate (HocSinh HS)
                {
                    return HS.Tuoi >= Tuoi;
                });
            }

            if (str.Contains(">"))
            {
                str = str.Replace(">", "");
                int Tuoi = Int32.Parse(str);
                Console.WriteLine("\n=> Bạn muốn tìm các HS có độ tuổi lớn hơn {0}.", Tuoi);
                Output = Input.FindAll(delegate (HocSinh HS)
                {
                    return HS.Tuoi > Tuoi;
                });
            }

            if (str.Contains("<="))
            {
                str = str.Replace("<=", "");
                int Tuoi = Int32.Parse(str);
                Console.WriteLine("\n=> Bạn muốn tìm các HS có độ tuổi nhỏ hơn hoặc bằng {0}.", Tuoi);
                Output = Input.FindAll(delegate (HocSinh HS)
                {
                    return HS.Tuoi <= Tuoi;
                });
            }

            if (str.Contains("<"))
            {
                str = str.Replace("<", "");
                int Tuoi = Int32.Parse(str);
                Console.WriteLine("\n=> Bạn muốn tìm các HS có độ tuổi nhỏ hơn {0}.", Tuoi);
                Output = Input.FindAll(delegate (HocSinh HS)
                {
                    return HS.Tuoi < Tuoi;
                });
            }

            if (str.Contains("-"))
            {
                string[] arr = str.Split('-');
                int a = Int32.Parse(arr[0]);
                int b = Int32.Parse(arr[1]);
                Console.WriteLine("\n=> Bạn muốn tìm các HS có độ tuổi từ: {0} đến {1}.", a, b);
                Output = Input.FindAll(delegate (HocSinh HS)
                {
                    return (HS.Tuoi <= b && a <= HS.Tuoi);
                });
            }

            InDanhSach(Output);
            return Output;
        }

        static List<HocSinh> SName(List<HocSinh> Input, Ten T, string str)//Tim ten co chua thanh phan tim kiem
        {
            List<HocSinh> Output = new List<HocSinh>();
            if (T.Name.Contains(str.ToLower()))
            {
                Console.WriteLine("\n=>Tìm kiếm HS có tên : " + str);
                Output = Input.FindAll(delegate (HocSinh HS)
                {
                    return HS.Ten.ToLower() == str.ToLower();
                });
            }
            else
            {
                Console.WriteLine("\n=>Tìm kiếm HS có tên chứa chuỗi kí tự: " + str);
                Output = Input.FindAll(delegate (HocSinh HS)
                {
                    return HS.HoTen.ToLower().Contains(str.ToLower());
                });
            }
            InDanhSach(Output);
            return Output;
        }

        static List<HocSinh> SNamSinh(List<HocSinh> Input, DateTime NamSinh)//Tìm học sinh có ngay thang nam sinh da nhap
        {
            List<HocSinh> Output = new List<HocSinh>();
            CultureInfo viVn = new CultureInfo("vi-VN");
            Console.WriteLine("\n=> Bạn muốn tìm các HS có ngày tháng năm sinh là: {0} ", NamSinh.ToString("d", viVn));
            Output = Input.FindAll(delegate (HocSinh HS)
            {
                return HS.NamSinh == NamSinh;
            });
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
            CultureInfo viVn = new CultureInfo("vi-VN");
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
                        Console.WriteLine(Input[i].ID + "." + Input[i].HoTen + " ....... " + Input[i].Tuoi + " ....... " + Input[i].GioiTinh + " ....... " + Input[i].NamSinh.ToString("d", viVn));
                    }
                    Console.WriteLine("...");
                    Console.WriteLine(Input[IC - 1].ID + "." + Input[IC - 1].HoTen + " ....... " + Input[IC - 1].Tuoi + " ....... " + Input[IC - 1].GioiTinh + " ....... " + Input[IC - 1].NamSinh.ToString("d", viVn));
                    Console.Write("\n=> Có {0} kết quả cần tìm.", Input.Count);
                    Console.WriteLine(" Nhấm phím 'F1' để in đầy đủ danh sách.");
                    if (Console.ReadKey().Key == ConsoleKey.F1)
                    {
                        foreach (HocSinh HS in Input)
                        {
                            Console.WriteLine(HS.ID + "." + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh + " ....... " + HS.NamSinh.ToString("d", viVn));
                        }
                    }
                }
                else
                {
                    foreach (HocSinh HS in Input)
                    {
                        Console.WriteLine(HS.ID + "." + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh + " ....... " + HS.NamSinh.ToString("d", viVn));
                    }
                    Console.WriteLine("\n=> Có {0} kết quả cần tìm.", IC);
                }
            }
        }
    }
}