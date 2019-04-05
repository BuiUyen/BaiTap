using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoJson
{












    class Program
    {
        static void Main(string[] args)
        {

            List<int> myValues = new List<int>(new int[] { 1, 2, 3, 4, 5, 6 });
            var rand = new Random();

            myValues.OrderBy(x => rand.Next()).Take(3);
             foreach( int i in myValues)
            {
                Console.WriteLine(i + "    ");
            }
        }
    }
}
