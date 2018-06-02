using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class InsertionSort
    {
        public static void Sort<T>(T[] arr)where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int prev = i - 1;
                int curr = i;
                while (true)
                {
                    if (prev < 0 || Helper.IsLess(arr[prev], arr[curr]))
                    {
                        break;
                    }
                    Helper.Swap(arr, curr, prev);
                    prev--;
                    curr--;
                }
            }
        }
    }
}
