using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiMa_2
{
    class Program
    {
        public class PhanTu
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
            public PhanTu()
            {
            }
            public PhanTu(string _a, string _b, string _c)
            {
                A = _a;
                B = _b;
                C = _c;
            }
        }

        static void Main(string[] args)
        {
            string Data = "00020101021226280010A00000077501100106913377520450455303704540115802VN5906POS3656005HANOI62410112ND03427/06180312POS365 Hanoi0705POS01630493CE";
            List<PhanTu> KQ = new List<PhanTu>();
            thuattoan(Data);
            void thuattoan(string input)
            {
                while (true)
                {
                    if (input.Length > 4)
                    {
                        string Group_code = input.Substring(0, 2);
                        string strlenght = input.Substring(2, 2);
                        Int32.TryParse(strlenght, out int lenght);
                        string data = input.Substring(4, lenght);
                        KQ.Add(new PhanTu(Group_code, strlenght, data));
                        Console.WriteLine("{0}-{1}-{2}", Group_code, strlenght, data);
                        input = input.Remove(0, 4 + lenght);
                        if (Group_code == "26" || Group_code == "62")
                        {
                            Console.WriteLine("-----------------------");
                            thuattoan(data);
                            Console.WriteLine("-----------------------");
                        }
                    }
                    else break;
                }
            }
            Console.WriteLine("\n\n\n------------------------------------");
            Console.WriteLine("\nPayload Format Indicator: " + KQ[0].C);
            Console.WriteLine("\nPoint of Initiation Method: " + KQ[1].C);
            Console.WriteLine("\nMerchant Account Information Template: " + KQ[2].C);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Globally Unique Identifier (masterMerCode): " + KQ[3].C);
            Console.WriteLine("\nMerchant Code: " + KQ[4].C);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Merchant Category Code: " + KQ[5].C);
            Console.WriteLine("\nTransaction Currencyr: " + KQ[6].C);
            Console.WriteLine("\nTransaction Amount: " + KQ[7].C);
            Console.WriteLine("\nCountry Code: " + KQ[8].C);
            Console.WriteLine("\nMerchant Name: " + KQ[9].C);
            Console.WriteLine("\nMerchant City: " + KQ[10].C);
            Console.WriteLine("\nAdditional Data Field Template: " + KQ[11].C);
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Bill number: " + KQ[12].C);
            Console.WriteLine("\nStore Label: " + KQ[13].C);
            Console.WriteLine("\nTerminal Label: " + KQ[14].C);
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("CRC: " + KQ[15].C);
            Console.ReadKey();
        }
    }
}