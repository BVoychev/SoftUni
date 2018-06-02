using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    public static class BubbleSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable
        {
            var border = arr.Length;
            Sort(arr, border);           

        }

        private static void Sort<T>(T[] arr, int border) where T : IComparable
        {
            if (border < 1)
            {
                return;
            }
            for (int i = 1; i < border; i++)
            {
                if (!Helper.IsLess(arr[i-1], arr[i]))
                {
                    Helper.Swap(arr, i-1, i);
                }
            }
            Sort(arr, border - 1);
        }
    }
}
