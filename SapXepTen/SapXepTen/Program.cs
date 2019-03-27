using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapXepTen
{
    public class Program
    {
        public static void Main()
        {
            IList<HocSinh> mHocSinh = new List<HocSinh>();           

            mHocSinh.Add(new HocSinh("nguyen hoang nam", 18, "nam"));
            mHocSinh.Add(new HocSinh("le tuan anh", 5, "nam"));
            mHocSinh.Add(new HocSinh("nguyen thi huyen", 10, "nu"));
            mHocSinh.Add(new HocSinh("vu binh duong", 16, "nam"));
            mHocSinh.Add(new HocSinh("pham thi hue", 20, "nu"));
            mHocSinh.Add(new HocSinh("nguyen thi chinh", 11, "nu"));
            mHocSinh.Add(new HocSinh("le thi hoai", 10, "nu"));
            mHocSinh.Add(new HocSinh("phan thi hong hao", 18, "nu"));
            mHocSinh.Add(new HocSinh("pham duc huy", 5, "nam"));
            mHocSinh.Add(new HocSinh("nguyen thi huyen", 22,"nu"));
            mHocSinh.Add(new HocSinh("pham thi chinh", 22, "nu"));

            Console.WriteLine("\nDanh sach hoc sinh: ");
            //mHocSinh.Sort();
            //mHocSinh.Sort(new HocSinh.PersonNameComparer());
            //mHocSinh.OrderBy(x => x.Tuoi);
            
            foreach (HocSinh HS in mHocSinh)
            {
                Console.WriteLine(HS.HoTen+" ; "+HS.Tuoi+" ; "+HS.GioiTinh);
            }
            Console.ReadKey();
        }
    }    
}
