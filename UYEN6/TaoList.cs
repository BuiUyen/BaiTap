using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaiTap
{
    class TaoList
    {
        static void TL()
        {
            List<int> List = new List<int>();
            Random RD = new Random();
            while ( List.Count<10000)
            {
                int a = RD.Next(0, 10000);
                if (!List.Contains(a))
                {
                    List.Add(a);
                }
            }
            //Console.Write(String.Join(";", List));
            using (StreamWriter Text = new StreamWriter("Text.txt"))
            {
                foreach (int i in List)
                    Text.Write(i + ";");
            }
            Console.ReadKey();
        }
    }
}
