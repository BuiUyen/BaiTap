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
        public char[] kitu;

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
            List<HocSinh> Input = new List<HocSinh>()
            {
                new HocSinh ("Nguyen Van X",14,"nam"),
                new HocSinh ("Nguyen Hoang Nam",18,"nam"),
                new HocSinh ("Dinh Tuan Anh",5, "nam"),
                new HocSinh ("Bui Thi Huyen",10,"nu"),
                new HocSinh ("Vu Binh Duong",16, "nam"),
                new HocSinh ("Pham Thi Hue", 20,"nu"),
                new HocSinh ("Nguyen Thi Chinh",11, "nu"),
                new HocSinh ("Phan Thi Hong",10, "nu"),
                new HocSinh ("Phan Thi Hong Hao", 18, "nu"),
                new HocSinh ("Pham Duc Huy",5, "nam"),
                new HocSinh ("Nguyen Thi Huyen", 8, "nu"),
                new HocSinh ("Pham Thi Chinh",22, "nu"),
            };

            //Cat lay ten de sap xep theo ten
            foreach (HocSinh HS in Input)
            {
                string[] cut = HS.HoTen.Split(' ');
                HS.Ten = cut[cut.Length - 1];

                Char[] arr = HS.HoTen.ToCharArray(0, HS.HoTen.Length);
                HS.kitu = arr;
            }
            //Sap xep

            //List<HocSinh> Output = new List<HocSinh>();

            //for (int i = 0; i< Input.Count; i++)
            //{
            //    int x = Input[i].Tuoi;
            //    int dem = -1;
            //    for ( int j=0; j<Output.Count;j++)
            //    {
            //        int y = Output[j].Tuoi;
            //        if(x < y)
            //        {
            //            dem = j;
            //            break;
            //        }
            //    }
            //    if (dem>=0)
            //    {
            //        Output.Insert(dem, Input[i]);
            //    }
            //    else
            //    {
            //        Output.Add(Input[i]);
            //    }
            //}

            //for (int i = 0; i<Input.Count; i++)
            //{
            //    for (int j=i+1; j<Input.Count; j++)
            //    {
            //        if (Input[i].Tuoi>Input[j].Tuoi)
            //        {
            //            HocSinh tg = Input[i];
            //            Input[i] = Input[j];
            //            Input[j] = tg;
            //        }
            //    }
            //}

            for (int i = 0; i < Input.Count; i++)
            {
                for (int j = i + 1; j < Input.Count; j++)
                {
                    if (Input[i].kitu[0] > Input[j].kitu[0])
                    {
                        HocSinh tg = Input[i];
                        Input[i] = Input[j];
                        Input[j] = tg;
                    }

                }
            }

            for (int i = 0; i < Input.Count; i++)
            {
                for (int j = i + 1; j < Input.Count; j++)
                {
                    for (int v = 1; v < Input[i].kitu.Length && v < Input[j].kitu.Length; v++)
                    {
                        if (Input[i].kitu[v - 1] == Input[j].kitu[v - 1])
                        {
                            if (Input[i].kitu[v] > Input[j].kitu[v])
                            {
                                HocSinh tg = Input[i];
                                Input[i] = Input[j];
                                Input[j] = tg;
                                break;
                            }
                        }
                        else break;

                    }
                }
            }

            //List<HocSinh> sd = mHocSinh.OrderBy(x => x.HoTen).ToList();

            Console.WriteLine("\nDanh sach hoc sinh: ");
            foreach (HocSinh HS in Input)
            {
                Console.WriteLine("\n" + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh);
            }
            Console.ReadKey();
        }
    }
}

