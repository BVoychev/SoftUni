using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    static class Quick
    {
        public static void Sort<T>(T[] arr) where T : IComparable
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort<T>(T[] arr, int left, int right) where T : IComparable
        {
            if (right <= left)
            {
                return;
            }
            //if (right - left < 10)
            //{
                //InsertionSort.Sort<T>(arr);
                //return;
            //}

            int partitionIndex = Partition(arr, left, right);
            Sort(arr, left, partitionIndex - 1);
            Sort(arr, partitionIndex + 1, right);
        }

        private static int Partition<T>(T[] arr, int left, int right) where T : IComparable
        {
            int leftScanInd = left;
            int rightScanInd = right + 1;
            T partitionElement = arr[left];

            while (true)
            {
                while (Helper.IsLess(arr[++leftScanInd], partitionElement))
                {
                    if (leftScanInd == right)
                    {
                        break;
                    }
                }
                while (Helper.IsLess(partitionElement, arr[--rightScanInd]))
                {
                    if (rightScanInd == left)
                    {
                        break;
                    }
                }

                if (leftScanInd >= rightScanInd)
                {
                    break;
                }

                Helper.Swap(arr, leftScanInd, rightScanInd);
            }

            Helper.Swap(arr, left, rightScanInd);
            return rightScanInd;
        }
    }
}
