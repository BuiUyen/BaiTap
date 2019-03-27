using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace BaiTap
{
    class THUCHIEN
    {
        static void Main()
        {
            Sapxep N = new Sapxep();
            String Text = File.ReadAllText(@"C:\Users\ADMIN\Desktop\List.txt");
            List<int> Input = new List<int>();
            String[] Cut = Text.Split(';');
            for (int x = 0; x < Cut.Count() - 1; x++)
            {
                Input.Add(Convert.ToInt32(Cut[x]));
            }

            List<int> A1 = new List<int>();
            foreach (int x in Input)
            {
                A1.Add(x);
            }
            // dem thoi gian BubbleSort
            Stopwatch tg1 = new Stopwatch();
            tg1.Start();            
            N.BubbleSort(A1);
            tg1.Stop();
            Console.WriteLine("\nThoi gian thuc hien Bubble Sort: {0} giay", tg1.Elapsed.ToString());
            using (StreamWriter Output1 = new StreamWriter("List1.txt"))
            {
                foreach (int a in A1)
                {
                    Output1.Write(a + ";");
                }
            }

            List<int> A2 = new List<int>();
            foreach (int x in Input)
            {
                A2.Add(x);
            }
            // dem thoi gian SelectionSort
            Stopwatch tg2 = new Stopwatch();
            tg2.Start();            
            N.SelectionSort(A2);
            tg2.Stop();
            Console.WriteLine("\nThoi gian thuc hien SelectionSort: {0} giay", tg2.Elapsed.ToString());
            using (StreamWriter Output2 = new StreamWriter("List2.txt"))
            {
                foreach (int a in A2)
                {
                    Output2.Write(a + ";");
                }
            }

            List<int> A3 = new List<int>();
            foreach (int x in Input)
            {
                A3.Add(x);
            }
            //dem thoi gian MergeSort
            Stopwatch tg3 = new Stopwatch();
            tg3.Start();
            N.SelectionSort(A3);
            tg3.Stop();
            Console.WriteLine("\nThoi gian thuc hien MergeSort: {0} giay", tg3.Elapsed.ToString());
            using (StreamWriter Output3 = new StreamWriter("List3.txt"))
            {
                foreach (int a in A3)
                {
                    Output3.Write(a + ";");
                }
            }

            List<int> A4 = new List<int>();
            foreach (int x in Input)
            {
                A4.Add(x);
            }
            //dem thoi gian MergeSort
            Stopwatch tg4 = new Stopwatch();
            tg4.Start();
            N.QuickSort(A4);
            tg4.Stop();
            Console.WriteLine("\nThoi gian thuc hien Quick Sort: {0} giay", tg4.Elapsed.ToString());
            using (StreamWriter Output4 = new StreamWriter("List4.txt"))
            {
                foreach (int a in A4)
                {
                    Output4.Write(a + ";");
                }
            }

            List<int> A5 = new List<int>();
            foreach (int x in Input)
            {
                A5.Add(x);
            }
            //dem thoi gian MergeSort
            Stopwatch tg5 = new Stopwatch();
            tg5.Start();
            N.SapXepList(A5);
            tg5.Stop();
            Console.WriteLine("\nThoi gian thuc hien cach sap xep qua List moi: {0} giay", tg5.Elapsed.ToString());
            using (StreamWriter Output5 = new StreamWriter("List5.txt"))
            {
                foreach (int a in A5)
                {
                    Output5.Write(a + ";");
                }
            }

            List<int> A6 = new List<int>();
            foreach (int x in Input)
            {
                A6.Add(x);
            }
            Stopwatch tg6 = new Stopwatch();
            tg6.Start();
            A6.Sort();
            tg6.Stop();
            Console.WriteLine("\nThoi gian thuc hien SortList: {0} giay", tg6.Elapsed.ToString());
            using (StreamWriter Output6 = new StreamWriter("List6.txt"))
            {
                foreach (int a in A6)
                {
                    Output6.Write(a + ";");
                }
            }

            //Console.WriteLine(String.Join("->", A5));
            Console.ReadKey();
        }
    }
}
