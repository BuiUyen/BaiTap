using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiMa_2
{
    public class PhanTu
    {
        public string GrCode { get; set; }
        public string Lenght { get; set; }
        public string Data { get; set; }
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
            mPT = thuattoan(Data, mPT, null);
            InDS(mPT);

            //Console.WriteLine("\n\n\n------------------------------------");
            //Console.WriteLine("\nPayload Format Indicator: " + mPT[0].C);
            //Console.WriteLine("\nPoint of Initiation Method: " + mPT[1].C);
            //Console.WriteLine("\nMerchant Account Information Template: " + mPT[2].C);
            //Console.WriteLine("-------------------------------------------");
            //Console.WriteLine("Globally Unique Identifier (masterMerCode): " + mPT[2].mPhantuCon[0].C);
            //Console.WriteLine("\nMerchant Code: " + mPT[2].mPhantuCon[1].C);
            //Console.WriteLine("-------------------------------------------");
            //Console.WriteLine("Merchant Category Code: " + mPT[3].C);
            //Console.WriteLine("\nTransaction Currencyr: " + mPT[4].C);
            //Console.WriteLine("\nTransaction Amount: " + mPT[5].C);
            //Console.WriteLine("\nCountry Code: " + mPT[6].C);
            //Console.WriteLine("\nMerchant Name: " + mPT[7].C);
            //Console.WriteLine("\nMerchant City: " + mPT[8].C);
            //Console.WriteLine("\nAdditional Data Field Template: " + mPT[9].C);
            //Console.WriteLine("-----------------------------------------");
            //Console.WriteLine("Bill number: " + mPT[9].mPhantuCon[0].C);
            //Console.WriteLine("\nStore Label: " + mPT[9].mPhantuCon[1].C);
            //Console.WriteLine("\nTerminal Label: " + mPT[9].mPhantuCon[2].C);
            //Console.WriteLine("-----------------------------------------");
            //Console.WriteLine("CRC: " + mPT[10].C);
            //Console.ReadKey();
        }

        public static List<PhanTu> thuattoan(string input, List<PhanTu> List, PhanTu PhantuCha)
        {
            while (true)
            {
                if (input.Length > 4)
                {
                    PhanTu _PhanTu = new PhanTu();
                    _PhanTu.GrCode = input.Substring(0, 2);
                    _PhanTu.Lenght = input.Substring(2, 2);
                    Int32.TryParse(_PhanTu.Lenght, out int lenght);
                    _PhanTu.Data = input.Substring(4, lenght);

                    if (PhantuCha == null)
                    {
                        List.Add(_PhanTu);
                    }
                    else
                    {
                        PhantuCha.mPhantuCon.Add(_PhanTu);
                    }

                    if (_PhanTu.GrCode == "26")
                    {
                        thuattoan(_PhanTu.Data, List, _PhanTu);
                    }

                    if (_PhanTu.GrCode == "62")
                    {
                        thuattoan(_PhanTu.Data, List, _PhanTu);
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
                Console.WriteLine(i.GrCode + " " + i.Lenght + " " + i.Data);
                if (i.mPhantuCon!=null)
                {
                    foreach( PhanTu x in i.mPhantuCon)
                    {
                        Console.WriteLine("+ " + x.GrCode +" "+ x.Lenght + " " + x.Data);
                    }
                }
            }
        }
    }
}