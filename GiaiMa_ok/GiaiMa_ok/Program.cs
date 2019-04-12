using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiMa_ok
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
                    Console.WriteLine(" Used when the same QR Code is shown for more than one transaction.");
                }
                if (a == "12")
                {
                    Console.WriteLine(" Used when a new QR Code is shown for each transaction data.");
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
                Console.WriteLine("-----------------");
                thuchien("00", MAIT, "Payload Format Indicator");
                thuchien("01", MAIT, "mMediboxOption_ThanhToanDienTu_VNPAY.merchantCode");
                Console.WriteLine("-----------------");
            }
            else Console.WriteLine("Error!!! Merchant Account Information Template !!!");

            //Merchant Category Code
            thuchien("52", data, "Merchant Category Code");

            //Transaction Currency
            thuchien("53", data, "Transaction Currency");

            //Transaction Amount
            thuchien("54", data, "Transaction Amount");

            //Country Code
            thuchien("58", data, "Country Code");

            //Merchant Name
            thuchien("59", data, "Merchant Name");
            
            //Merchant City
            thuchien("60", data, "Merchant City");

            //Additional Data Field Template
            if (chartostr(data, 2) == "62")
            {
                Console.WriteLine("\nAdditional Data Field Template: ");
                data.RemoveRange(0, 2);
                int lenght = Convert.ToInt32(chartostr(data, 2));
                data.RemoveRange(0, 2);
                string a = chartostr(data, lenght);
                data.RemoveRange(0, lenght);
                List<char> ADFT = strtolist(a);

                Console.WriteLine("-----------------");
                //Bill number
                thuchien("01", ADFT, "Bill number");
                
                //Store Label
                thuchien("03", ADFT, "Store Label");

                //Terminal Label
                thuchien("07", ADFT, "Terminal Label");

                Console.WriteLine("-----------------");
            }

            //CRC
            thuchien("63", data, "CRC");            
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

        //thuat toan chinh
        public static void thuchien(string madauvao, List<char> input, string ten)
        {
            if (chartostr(input, 2) == madauvao)
            {                
                input.RemoveRange(0, 2);
                string strlenght = chartostr(input, 2);
                int lenght = Convert.ToInt32(strlenght);
                input.RemoveRange(0, 2);
                string a = chartostr(input, lenght);
                //Console.WriteLine("\n {0} {1} {2}", madauvao, strlenght, a); 
                input.RemoveRange(0, lenght);
                Console.Write("{0} : ", ten);
                Console.WriteLine(a);
            }
            else Console.WriteLine("Error!!! {0} !!!", ten);

        }
    }
}