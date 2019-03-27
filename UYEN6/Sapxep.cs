using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace BaiTap
{
    public static class Sapxep
    {
        public static IList<int> BubbleSort(IList<int> List)
        {            
            int i, v;
            for (i = 0; i < List.Count; i++)
            {
                for (v = 0; v < List.Count - 1; v++)
                {
                    if (List[v] > List[v + 1])
                    {
                        int tgian = List[v];
                        List[v] = List[v + 1];
                        List[v + 1] = tgian;
                    }
                }
            }
            //Console.WriteLine(String.Join(" -> ", List)); 
            return List;
        }

        public static IList<int> SelectionSort(IList<int> List)
        {
            int i, j, min, tg;
            for (i = 0; i < List.Count; i++)
            {
                min = i;
                for (j = i + 1; j < List.Count; j++)
                {
                    if (List[min] > List[j])
                    {
                        min = j;
                    }
                }
                tg = List[min];
                List[min] = List[i];
                List[i] = tg;
            }
            //Console.WriteLine(String.Join(" -> ", List));
            return List;
        }

        public static List<int> MergeSort(List<int> CSX)
        {

            if (CSX.Count <= 1)
                return CSX;
            List<int> T = new List<int>();
            List<int> P = new List<int>();
            int giua = CSX.Count / 2;
            for (int i = 0; i < giua; i++)
            {
                T.Add(CSX[i]);
            }
            for (int i = giua; i < CSX.Count; i++)
            {
                P.Add(CSX[i]);
            }

            T = MergeSort(T);
            P = MergeSort(P);
            return Merge(T, P);
        }

        private static List<int> Merge(List<int> T, List<int> P)
        {
            List<int> KQ = new List<int>();
            while (T.Count > 0 || P.Count > 0)
            {
                if (T.Count > 0 && P.Count > 0)
                    if (T.First() <= P.First())
                    {
                        KQ.Add(T.First());
                        T.Remove(T.First());
                    }
                    else
                    {
                        KQ.Add(P.First());
                        P.Remove(P.First());
                    }
                else if (T.Count>0)
                {
                    KQ.Add(T.First());
                    T.Remove(T.First());
                }
                else if(P.Count>0)
                {
                    KQ.Add(P.First());
                    P.Remove(P.First());
                }
            }
            return KQ;
        }

        public static IList<int> QuickSort(List<int> List)
        {
            Quick(List, 0, List.Count-1);
            return List;
        }

        private static void Quick(List<int> List, int T, int P)
        {
            if (T<P)
            {
                int X = Partition(List, T, P);
                if (X>1)
                {
                    Quick(List, T, X - 1);
                }
                if(X+1<P)
                {
                    Quick(List, X + 1, P);
                }
            }
        }

        private static int Partition(List<int>List,int T,int P)
        {
            int X = List[T];
            while (true)
            {
                while ( List[T] < X )
                {
                    T++;
                }
                while ( List[P] > X ) 
                {
                    P--;
                }
                if (T<P)
                {
                    if (List[T] == List[P]) return P;
                    int tg = List[T];
                    List[T] = List[P];
                    List[P] = tg;
                }
                else
                {
                    return P;
                }
            }
        }

        public static IList<int> SapXepList(IList<int> List)
        {
            int dem, i;
            IList<int> Output = new List<int>();
            for (i = 0; i < List.Count; i++)
            {
                dem = -1;
                for (int j = 0; j < Output.Count; j++)
                {
                    if (List[i] < Output[j])
                    {
                        dem = j;
                        break;
                    }
                }
                if (dem >= 0)
                {
                    Output.Insert(dem,List[i]);
                }
                else
                {
                    Output.Add(List[i]);
                }
            }
            List.Clear();
            foreach (int y in Output)
            {
                List.Add(y);
            }
            return List;
        }        
    }
}
