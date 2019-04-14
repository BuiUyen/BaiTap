using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiMa_2
{
    public class PhanTu
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public List<PhanTu> mPhantuCon = new List<PhanTu>();
        public PhanTu()
        {
            List<PhanTu> mPhanTu = new List<PhanTu>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string Data = "00020101021226280010A00000077501100106913377520450455303704540115802VN5906POS3656005HANOI62410112ND03427/06180312POS365 Hanoi0705POS01630493CE";
            List<PhanTu> mPT = new List<PhanTu>();
            PhanTu a = new PhanTu();
            mPT = thuattoan(Data, mPT, null);
            InDS(mPT);
           
            //Console.WriteLine("\n\n\n------------------------------------");
            //Console.WriteLine("\nPayload Format Indicator: " + KQ[0].C);
            //Console.WriteLine("\nPoint of Initiation Method: " + KQ[1].C);
            //Console.WriteLine("\nMerchant Account Information Template: " + KQ[2].C);
            //Console.WriteLine("-------------------------------------------");
            //Console.WriteLine("Globally Unique Identifier (masterMerCode): " + KQ[3].C);
            //Console.WriteLine("\nMerchant Code: " + KQ[4].C);
            //Console.WriteLine("-------------------------------------------");
            //Console.WriteLine("Merchant Category Code: " + KQ[5].C);
            //Console.WriteLine("\nTransaction Currencyr: " + KQ[6].C);
            //Console.WriteLine("\nTransaction Amount: " + KQ[7].C);
            //Console.WriteLine("\nCountry Code: " + KQ[8].C);
            //Console.WriteLine("\nMerchant Name: " + KQ[9].C);
            //Console.WriteLine("\nMerchant City: " + KQ[10].C);
            //Console.WriteLine("\nAdditional Data Field Template: " + KQ[11].C);
            //Console.WriteLine("-----------------------------------------");
            //Console.WriteLine("Bill number: " + KQ[12].C);
            //Console.WriteLine("\nStore Label: " + KQ[13].C);
            //Console.WriteLine("\nTerminal Label: " + KQ[14].C);
            //Console.WriteLine("-----------------------------------------");
            //Console.WriteLine("CRC: " + KQ[15].C);
            Console.ReadKey();
        }

        public static List<PhanTu> thuattoan(string input, List<PhanTu> List, PhanTu PhantuCha)
        {
            while (true)
            {
                if (input.Length > 4)
                {
                    PhanTu _PhanTu = new PhanTu();
                    _PhanTu.A = input.Substring(0, 2);
                    _PhanTu.B = input.Substring(2, 2);
                    Int32.TryParse(_PhanTu.B, out int lenght);
                    _PhanTu.C = input.Substring(4, lenght);

                    if (PhantuCha == null)
                    {
                        List.Add(_PhanTu);
                    }
                    else
                    {
                        PhantuCha.mPhantuCon.Add(_PhanTu);
                    }

                    if (_PhanTu.A == "26")
                    {
                        thuattoan(_PhanTu.C, List, _PhanTu);
                    }

                    if (_PhanTu.A == "62")
                    {
                        thuattoan(_PhanTu.C, List, _PhanTu);
                    }

                    input = input.Remove(0, 4 + lenght);
                }
                else break;
            }
            return List;
        }

        static void InDS(List<PhanTu> Input)
        {
            foreach ( PhanTu i in Input)
            {
                Console.WriteLine(i.A + " " + i.B + " " + i.C);
                if (i.mPhantuCon!=null)
                {
                    foreach( PhanTu x in i.mPhantuCon)
                    {
                        Console.WriteLine("+ " + x.A +" "+ x.B + " " + x.C);
                    }
                }
            }
        }
    }
}