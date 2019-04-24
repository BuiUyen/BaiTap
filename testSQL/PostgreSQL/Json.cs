using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgSql
{
    public class Json
    {
        public static List<HocSinh> ReadJson()
        {
            String json_data = File.ReadAllText(@"C:\Users\ADMIN\Desktop\DanhSachHocSinh.json");
            LopHS List = JsonConvert.DeserializeObject<LopHS>(json_data);
            List<HocSinh> DanhSach = List.DanhSachHocSinh;
            return DanhSach;
        }

        public static List<string> ReadJsonStr()
        {
            List<HocSinh> DanhSach = ReadJson();
            List<string> Lstr;
            foreach(HocSinh Hs in DanhSach)
            {
                Lstr.Add(Hs.ID.ToString + "  /  " + Hs.HoTen.ToString + "  /  " + Hs.Tuoi.ToString + "  /  " + Hs.GioiTinh.ToString + "\r\n");
            }
        }
        *
    }
}
