using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MergeSort
{
    public static class SelectionSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable
        {
            for (int indx = 0; indx < arr.Length; indx++)
            {
                int min = indx;
                for (int i = indx+1; i < arr.Length; i++)
                {
                    if (Helper.IsLess(arr[i],arr[min]))
                    {
                        min = i;
                    }
                }
                Helper.Swap(arr, min, indx);
            }

        }
    }
}
