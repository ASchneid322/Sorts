using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public static class Merge
    {
        public static List<T> mergeSort<T>(this List<T> items) where T : System.IComparable<T>
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
    }
}
