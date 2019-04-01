using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapXepTen_OK
{
    public class HocSinh
    {
        public string ID { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public string Ten { get; set; }
        public string VAR { get; set; }

        public HocSinh()
        {

        }
        public HocSinh(string id, string hoten, int tuoi, string gioitinh)
        {
            HoTen = hoten;
            Tuoi = tuoi;
            GioiTinh = gioitinh;
            id = ID;
        }
    }
}
