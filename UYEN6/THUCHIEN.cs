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
            //Sapxep N = new Sapxep();
            String Text = File.ReadAllText(@"C:\Users\ADMIN\Desktop\List.txt");
            List<int> Input = new List<int>();
            String[] Cut = Text.Split(';');
            for (int x = 0; x < Cut.Count() - 1; x++)
            {
                Input.Add(Convert.ToInt32(Cut[x]));
            }
            Stopwatch mStopwatch = new Stopwatch();
            List<int> A1 = new List<int>();
            foreach (int x in Input)
            {
                A1.Add(x);
            }            
            // dem thoi gian BubbleSort
            
            mStopwatch.Start();            
            Sapxep.BubbleSort(A1);
            mStopwatch.Stop();
            Console.WriteLine("\nThoi gian thuc hien Bubble Sort: {0} ms", mStopwatch.ElapsedMilliseconds);
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
            mStopwatch.Reset();
            // dem thoi gian SelectionSort            
            mStopwatch.Start();            
            Sapxep.SelectionSort(A2);
            mStopwatch.Stop();
            Console.WriteLine("\nThoi gian thuc hien SelectionSort: {0} ms", mStopwatch.ElapsedMilliseconds);
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
            mStopwatch.Reset();
            //dem thoi gian MergeSort            
            mStopwatch.Start();
            Sapxep.SelectionSort(A3);
            mStopwatch.Stop();
            Console.WriteLine("\nThoi gian thuc hien MergeSort: {0} ms", mStopwatch.ElapsedMilliseconds);
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
            mStopwatch.Reset();
            //dem thoi gian MergeSort            
            mStopwatch.Start();
            Sapxep.QuickSort(A4);
            mStopwatch.Stop();
            Console.WriteLine("\nThoi gian thuc hien Quick Sort: {0} ms", mStopwatch.ElapsedMilliseconds);
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
            mStopwatch.Reset();
            mStopwatch.Start();
            Sapxep.SapXepList(A5);
            mStopwatch.Stop();
            Console.WriteLine("\nThoi gian thuc hien cach sap xep qua List moi: {0} ms", mStopwatch.ElapsedMilliseconds);
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
            mStopwatch.Reset();
            mStopwatch.Start();
            A6.Sort();
            mStopwatch.Stop();
            Console.WriteLine("\nThoi gian thuc hien SortList: {0} ms", mStopwatch.ElapsedMilliseconds);
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
