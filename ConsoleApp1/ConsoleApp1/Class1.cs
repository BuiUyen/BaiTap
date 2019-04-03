using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
namespace MySpace
{
    class PrormaSC
    {

        public static void Main(string[] args)
        {
            LoadJson();

            Console.ReadLine();
        }

        public class SchemaInfo
        {
            public string AuthenticateCmdlets { get; set; }
            public string GetPowerState { get; set; }
            public string PowerOff { get; set; }
            public string PowerOn { get; set; }
        }

        public static void LoadJson()
        {
            using (StreamReader r = new StreamReader("DanhSachHocSinh.json"))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<SchemaInfo>>(json);
                foreach (var item in items)
                {
                    // Console.WriteLine("{0} {1}", item.temp, item.vcc);
                }
            }`
        }
    }
}