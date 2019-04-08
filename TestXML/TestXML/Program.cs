using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
        public int Tuoi { get; set; }
        public string Ten { get; set; }
    }

    public class Program
    {
        static void Main()
        {
            String xmlData = File.ReadAllText(@"C:\Users\ADMIN\Desktop\DanhSachHocSinh.xml");
            XmlSerializer DanhsachHocSinh = new XmlSerializer(typeof(LopHS));
            LopHS XmlKetQua = new LopHS();

            using (TextReader reader = new StringReader(xmlData))
            {
                XmlKetQua = (LopHS)DanhsachHocSinh.Deserialize(reader);
            }

            List<HocSinh> a = new List<HocSinh>();

            a = XmlKetQua.DanhSachHocSinh;
            Console.WriteLine("\n\n-------------------Danh sach hoc sinh----------------------------------------");
            foreach (HocSinh HS in a)
            {
                Console.WriteLine(HS.HoTen + " ....... " + HS.Tuoi + " ....... " + HS.GioiTinh);
            }

            // xuat xml
            // cach 1:
            string Kqxml = "<?xml version='1.0'?>" + "\n<DanhSachHocSinh>";
            int i = 0;
            foreach (HocSinh HS in a)
            {
                Kqxml += "\n    <HocSinh>" + "\n         <HoTen>" + a[i].HoTen + "</HoTen>" + "\n         <Tuoi>" + a[i].Tuoi + "</Tuoi>" + "\n         <GioiTinh>" + a[i].HoTen + "</GioiTinh>" + "\n    </HocSinh>";
                i++;
            }
            Kqxml += "\n</DanhSachHocSinh>";
            Console.WriteLine(Kqxml);
            File.WriteAllText(@"C:\Users\ADMIN\Desktop\DanhSach.xml", Kqxml);

            // cach 2:
            XmlSerializer serializer = new XmlSerializer(typeof(LopHS));
            using (TextWriter textWriter = new StreamWriter(@"C:\Users\ADMIN\Desktop\DanhSach2.xml"))
            {
                serializer.Serialize(textWriter, XmlKetQua);
                textWriter.Close();
            }

            Console.ReadKey();
        }


    }

}