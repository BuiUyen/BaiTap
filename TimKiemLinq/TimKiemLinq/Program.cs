using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimKiemLinq
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

    class Program
    {
        static void Main(string[] args)
        {
            String json_data = File.ReadAllText(@"C:\Users\ADMIN\Desktop\DanhSach.json");
            LopHS mLopHS = JsonConvert.DeserializeObject<LopHS>(json_data);
            List<HocSinh> List = mLopHS.DanhSachHocSinh;

            foreach (HocSinh HS in List)
            {
                Console.WriteLine(HS.ID + "." + HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh);
            }



            Console.ReadKey();
        }
    }
}
