using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;

namespace Sorts
{
    class Program
    {
        public static Random rand = new Random();
        public static List<int> masterList;
        public const int _SIZE = 10000;
        public enum Sort { Default, Insertion, Merge, Quick }

        static void Main(string[] args)
        {
            masterList = generateList(_SIZE);

            doSort(0);
            doSort(Sort.Insertion);
            doSort(Sort.Merge);
            doSort(Sort.Quick);

            //masterList.ForEach(o => Console.Write(o + " "));
            //Console.WriteLine();

            Console.ReadKey();
        }

        private static void doSort(Sort type)
        {
            Stopwatch stopwatch = new Stopwatch();
            List<int> toSort = new List<int>(masterList);

            stopwatch.Start();

            if (type == Sort.Default)
            {
                toSort.Sort();
            }
            else if (type == Sort.Insertion)
            {
                toSort.insertionSort();
            }
            else if (type == Sort.Merge)
                toSort.mergeSort();
            else if (type == Sort.Quick)
                toSort.quickSort();

            stopwatch.Stop();
            Console.WriteLine(type);

            //toSort.ForEach(o => Console.Write(o + " "));
            //Console.WriteLine();

            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine(ts);
        }

        private static List<int> generateList(int size)
        {
            List<int> ints = new List<int>();

            for (int i = 0; i < size; i++)
            {
                ints.Add(rand.Next(0, 5000));
            }

            return ints;
        }

        //private static List<T> quickSort<T>(List<T> items, int low, int high) where T : System.IComparable<T>
        //{
        //    int p;
        //    if (low < high)
        //    {
        //        p = partition(items, low, high);
        //        quickSort(items, low, p - 1);
        //        quickSort(items, p + 1, high);
        //    }
        //    return items;
        //}

        //private static int partition<T>(List<T> items, int low, int high) where T : System.IComparable<T>
        //{
        //    T pivot = items[high];
        //    int i = low - 1;
        //    for (int j = low; j < high; j++)
        //    {
        //        if (items[j].CompareTo(pivot) < 0)
        //        {
        //            i = i + 1;
        //            T temp = items[i];
        //            items[i] = items[j];
        //            items[j] = temp;
        //        }
        //    }
        //    T temp2 = items[i + 1];
        //    items[i + 1] = items[high];
        //    items[high] = temp2;
        //    return i + 1;
        //}
    }
}
