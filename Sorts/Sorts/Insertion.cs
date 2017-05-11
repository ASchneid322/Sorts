using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public static class Insertion
    {
        /*
        https://en.wikipedia.org/wiki/Insertion_sort
        for i = 1 to length(A)
            j ← i
            while j > 0 and A[j-1] > A[j]
                swap A[j] and A[j-1]
                j ← j - 1
            end while
        end for
        */
        public static List<T> insertionSort<T>(this List<T> items) where T : System.IComparable<T>
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
    }
}
