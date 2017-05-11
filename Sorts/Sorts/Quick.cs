using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public static class Quick
    {
        public static List<T> quickSort<T>(this List<T> items) where T : System.IComparable<T>
        {
            return quickSort(items, 0, items.Count-1);
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
