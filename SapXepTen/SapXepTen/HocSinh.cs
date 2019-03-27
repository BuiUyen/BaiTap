using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapXepTen
{
    public class HocSinh:IComparable<HocSinh>
    {
        public string Ten{ get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string GioiTinh { get; set; }

        public int CompareTo(HocSinh other)
        {
            return this.Tuoi.CompareTo(other.Tuoi);
        }

        public class PersonNameComparer : IComparer<HocSinh>
        {
            public int Compare(HocSinh x, HocSinh y)
            {
                return x.HoTen.CompareTo(y.HoTen);
            }
        }

        public HocSinh(string hoten, int tuoi, string gioitinh)
        {
            this.HoTen = hoten;
            this.Tuoi = tuoi;
            this.GioiTinh = gioitinh;
            string[] Cut = hoten.Split(' ');
            this.Ten = Cut[Cut.Count() - 1];            
        }
    }
}
