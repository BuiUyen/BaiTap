using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestXML
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
        [XmlElement(ElementName = "GioiTinh")]
        public string GioiTinh { get; set; }
        [XmlElement(ElementName = "HoTen")]
        public string HoTen { get; set; }
        [XmlElement(ElementName = "Tuoi")]
        public string Tuoi { get; set; }
    }

    public class Program
    {
        static void Main()
        {
            List<HocSinh> DanhSachHocSinh = new List<HocSinh>();

            String xmlData = File.ReadAllText(@"C:\Users\ADMIN\Desktop\DanhSachHocSinh.xml");
            XmlSerializer Danhsach = new XmlSerializer(typeof(LopHS));
            LopHS XmlKetQua = new LopHS();

            using (TextReader reader = new StringReader(xmlData))
            {
                XmlKetQua = (LopHS)Danhsach.Deserialize(reader);               
            }

            DanhSachHocSinh = XmlKetQua.DanhSachHocSinh;

            Console.WriteLine("\n\n-------------------Danh sach hoc sinh----------------------------------------");
            foreach (HocSinh HS in DanhSachHocSinh)
            {
                Console.WriteLine(HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh);
            }

            Console.WriteLine();
            Console.ReadKey();
        }


    }

}