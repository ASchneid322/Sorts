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
                toSort = insertionSort(toSort);
            }
            else if (type == Sort.Merge)
                toSort = mergeSort(toSort);
            else if (type == Sort.Quick)
                toSort = quickSort(toSort, 0, toSort.Count() - 1);

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
        /*
         * https://en.wikipedia.org/wiki/Insertion_sort
        for i = 1 to length(A)
            j ← i
            while j > 0 and A[j-1] > A[j]
                swap A[j] and A[j-1]
                j ← j - 1
            end while
        end for
        */
        private static List<T> insertionSort<T>(List<T> items) where T : System.IComparable<T>
        {
            int j;
            for (int i = 1; i < items.Count; i++)
            {
                j = i;
                while (j > 0 && items[j - 1].CompareTo(items[j]) > 0)
                {
                    T temp = items[j - 1];
                    items[j - 1] = items[j];
                    items[j] = temp;
                    j--;
                }
            }
            return items;
        }

        private static List<T> mergeSort<T>(List<T> items) where T : System.IComparable<T>
        {
            if (items.Count <= 1)
                return items;

            List<T> left = new List<T>();
            List<T> right = new List<T>();

            for (int i = 0; i < items.Count; i++)
            {
                if (i < items.Count / 2)
                    left.Add(items[i]);
                else
                    right.Add(items[i]);
            }

            left = mergeSort(left);
            right = mergeSort(right);

            return merge(left, right);
        }

        private static List<T> merge<T>(List<T> left, List<T> right) where T : System.IComparable<T>
        {
            List<T> sort = new List<T>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left.First().CompareTo(right.First()) <= 0)
                {
                    sort.Add(left.First());
                    left.RemoveAt(0);
                }
                else
                {
                    sort.Add(right.First());
                    right.RemoveAt(0);
                }
            }

            while (left.Count > 0)
            {
                sort.Add(left.First());
                left.RemoveAt(0);
            }
            while (right.Count > 0)
            {
                sort.Add(right.First());
                right.RemoveAt(0);
            }

            return sort;
        }

        private static List<T> quickSort<T>(List<T> items, int low, int high) where T : System.IComparable<T>
        {
            int p;
            if (low < high)
            {
                p = partition(items, low, high);
                quickSort(items, low, p - 1);
                quickSort(items, p + 1, high);
            }
            return items;
        }

        private static int partition<T>(List<T> items, int low, int high) where T : System.IComparable<T>
        {
            T pivot = items[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (items[j].CompareTo(pivot) < 0)
                {
                    i = i + 1;
                    T temp = items[i];
                    items[i] = items[j];
                    items[j] = temp;
                }
            }
            T temp2 = items[i + 1];
            items[i + 1] = items[high];
            items[high] = temp2;
            return i + 1;
        }
    }
}
