using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiMa
{
    class Program
    {
        static void Main(string[] args)
        {
            string Data = "00020101021226280010A00000077501100106913377520450455303704540115802VN5906POS3656005HANOI62410112ND03427/06180312POS365 Hanoi0705POS01630493CE";
            //tao list char
            List<char> data = strtolist(Data);

            //Payload Format Indicator           
            if (chartostr(data, 2) == "00")
            {
                Console.Write("Payload Format Indicator: ");
                data.RemoveRange(0, 2);
                int lenght = Convert.ToInt32(chartostr(data, 2));
                data.RemoveRange(0, 2);
                int a = Convert.ToInt32(chartostr(data, lenght));
                data.RemoveRange(0, lenght);
                if (a == 1)
                {
                    Console.WriteLine("Version 01.");
                }
                else Console.WriteLine("RFU");
            }
            else Console.WriteLine("Error!!! Payload Format Indicator !!!");

            //Point of Initiation Method
            if (chartostr(data, 2) == "01")
            {
                Console.Write("\nPoint of Initiation Method:");
                data.RemoveRange(0, 2);
                int lenght = Convert.ToInt32(chartostr(data, 2));
                data.RemoveRange(0, 2);
                string a = chartostr(data, lenght);
                data.RemoveRange(0, lenght);
                if (a == "11")
                {
                    Console.WriteLine(" Used when the same QR Code is shown for more than one transaction");
                }
                if (a == "12")
                {
                    Console.WriteLine(" Used when a new QR Code is shown for each transaction data");
                }
                else Console.WriteLine("Error!!! Point of Initiation Method!!!");
            }
            else Console.WriteLine("Error!!! Point of Initiation Method !!!");

            //Merchant Account Information Template
            if (chartostr(data, 2) == "26")
            {
                Console.WriteLine("\nMerchant Account Information Template: ");
                data.RemoveRange(0, 2);
                int lenght = Convert.ToInt32(chartostr(data, 2));
                data.RemoveRange(0, 2);
                string a = chartostr(data, lenght);
                data.RemoveRange(0, lenght);

                List<char> MAIT = strtolist(a);

                if (chartostr(MAIT, 2) == "00")
                {
                    Console.Write("+)Globally Unique Identifier(MasterMerCode): ");
                    MAIT.RemoveRange(0, 2);
                    int lenght2 = Convert.ToInt32(chartostr(MAIT, 2));
                    MAIT.RemoveRange(0, 2);
                    string m_a = chartostr(MAIT, lenght2);
                    Console.WriteLine(m_a);
                    MAIT.RemoveRange(0, lenght2);
                }
                else Console.WriteLine("Error!!! Globally Unique Identifier(MasterMerCode) !!!");

                if (chartostr(MAIT, 2) == "01")
                {
                    Console.Write("+)mMediboxOption_ThanhToanDienTu_VNPAY.merchantCode: ");
                    MAIT.RemoveRange(0, 2);
                    int mlenght = Convert.ToInt32(chartostr(MAIT, 2));
                    MAIT.RemoveRange(0, 2);
                    string m_a = chartostr(MAIT, mlenght);
                    Console.WriteLine(m_a);
                    MAIT.RemoveRange(0, mlenght);
                }
                else Console.WriteLine("Error!!! mMediboxOption_ThanhToanDienTu_VNPAY.merchantCode !!!");
            }
            else Console.WriteLine("Error!!! Merchant Account Information Template !!!");

            //Merchant Category Code
            if (chartostr(data, 2) == "52")
            {
                Console.Write("\nMerchant Category Code:");
                data.RemoveRange(0, 2);
                int lenght = Convert.ToInt32(chartostr(data, 2));
                data.RemoveRange(0, 2);
                string a = chartostr(data, lenght);
                data.RemoveRange(0, lenght);
                Console.WriteLine(a);
            }
            else Console.WriteLine("Error!!! Merchant Category Code !!!");

            //Transaction Currency
            if (chartostr(data, 2) == "53")
            {
                Console.Write("\nTransaction Currency:");
                data.RemoveRange(0, 2);
                int lenght = Convert.ToInt32(chartostr(data, 2));
                data.RemoveRange(0, 2);
                string a = chartostr(data, lenght);
                data.RemoveRange(0, lenght);
                Console.WriteLine(a);
            }
            else Console.WriteLine("Error!!! Transaction Currency !!!");

            //Transaction Amount
            if (chartostr(data, 2) == "54")
            {
                Console.Write("\nTransaction Amount:");
                data.RemoveRange(0, 2);
                int lenght = Convert.ToInt32(chartostr(data, 2));
                data.RemoveRange(0, 2);
                string a = chartostr(data, lenght);
                data.RemoveRange(0, lenght);
                Console.WriteLine(a);
            }
            else Console.WriteLine("Error!!! Transaction Amount !!!");

            //Country Code
            if (chartostr(data, 2) == "58")
            {
                Console.Write("\nCountry Code:");
                data.RemoveRange(0, 2);
                int lenght = Convert.ToInt32(chartostr(data, 2));
                data.RemoveRange(0, 2);
                string a = chartostr(data, lenght);
                data.RemoveRange(0, lenght);
                Console.WriteLine(a);
            }
            else Console.WriteLine("Error!!! Country Code !!!");

            //Merchant Name
            if (chartostr(data, 2) == "59")
            {
                Console.Write("\nmMediboxOption_ThanhToanDienTu_VNPAY.merchantName: ");
                data.RemoveRange(0, 2);
                int lenght = Convert.ToInt32(chartostr(data, 2));
                data.RemoveRange(0, 2);
                string a = chartostr(data, lenght);
                data.RemoveRange(0, lenght);
                Console.WriteLine(a);
            }
            else Console.WriteLine("Error!!! Merchant Name !!!");

            //Merchant City
            if (chartostr(data, 2) == "60")
            {
                Console.Write("\nMerchant City: ");
                data.RemoveRange(0, 2);
                int lenght = Convert.ToInt32(chartostr(data, 2));
                data.RemoveRange(0, 2);
                string a = chartostr(data, lenght);
                data.RemoveRange(0, lenght);
                Console.WriteLine(a);
            }
            else Console.WriteLine("Error!!! Merchant City !!!");

            //Additional Data Field Template
            if (chartostr(data, 2) == "62")
            {
                Console.WriteLine("\nAdditional Data Field Template: ");
                data.RemoveRange(0, 2);
                int lenght = Convert.ToInt32(chartostr(data, 2));
                data.RemoveRange(0, 2);
                string a = chartostr(data, lenght);
                data.RemoveRange(0, lenght);

                List<char> MAIT = strtolist(a);


                //Bill number
                if (chartostr(MAIT, 2) == "01")
                {
                    Console.Write("+)Bill number : ");
                    MAIT.RemoveRange(0, 2);
                    int lenght2 = Convert.ToInt32(chartostr(MAIT, 2));
                    MAIT.RemoveRange(0, 2);
                    string m_a = chartostr(MAIT, lenght2);
                    Console.WriteLine(m_a);
                    MAIT.RemoveRange(0, lenght2);
                }
                else Console.WriteLine("Error!!! Bill number !!!");

                //Store Label
                if (chartostr(MAIT, 2) == "03")
                {
                    Console.Write("+)Store Label : ");
                    MAIT.RemoveRange(0, 2);
                    int mlenght = Convert.ToInt32(chartostr(MAIT, 2));
                    MAIT.RemoveRange(0, 2);
                    string m_a = chartostr(MAIT, mlenght);
                    Console.WriteLine(m_a);
                    MAIT.RemoveRange(0, mlenght);
                }
                else Console.WriteLine("Error!!! Store Label !!!");

                //Terminal Label
                if (chartostr(MAIT, 2) == "07")
                {
                    Console.Write("+)Terminal Label : ");
                    MAIT.RemoveRange(0, 2);
                    int mlenght = Convert.ToInt32(chartostr(MAIT, 2));
                    MAIT.RemoveRange(0, 2);
                    string m_a = chartostr(MAIT, mlenght);
                    Console.WriteLine(m_a);
                    MAIT.RemoveRange(0, mlenght);
                }
                else Console.WriteLine("Error!!! Terminal Label !!!");

            }

            //CRC
            if (chartostr(data, 2) == "63")
            {
                Console.Write("\nCRC : ");
                data.RemoveRange(0, 2);
                int lenght = Convert.ToInt32(chartostr(data, 2));
                data.RemoveRange(0, 2);
                string a = chartostr(data, lenght);
                data.RemoveRange(0, lenght);
                Console.WriteLine(a);
            }
            else Console.WriteLine("Error!!! CRC !!!");
            Console.ReadKey();
        }

        // chuyen doi list<char> thanh chuoi
        public static string chartostr(List<char> input, int v)
        {
            List<char> list = new List<char>();
            for (int i = 0; i < v; i++)
            {
                list.Add(input[i]);
            }
            string a = string.Join("", list);
            return a;
        }

        // chuyen doi chuoi thanh list<char>
        public static List<char> strtolist(string input)
        {
            List<char> data = new List<char>();
            foreach (char i in input)
            {
                data.Add(i);
            }
            return data;
        }       
    }
}
