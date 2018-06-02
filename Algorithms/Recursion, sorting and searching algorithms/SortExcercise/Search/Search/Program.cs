using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(y => int.Parse(y)).ToArray();
            int x = int.Parse(Console.ReadLine());
            int index = BinarySearch(arr, x, 0, arr.Length - 1);
            Console.WriteLine(index);
        }

        private static int BinarySearch(int[] arr, int x, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }     
            int midIndex = start + (end - start) / 2;
            if (arr[midIndex] == x)
            {
                return midIndex;
            }
            else
            {
                if (arr[midIndex] > x)
                {
                   return BinarySearch(arr, x, start, midIndex);
                }
                else
                {
                   return BinarySearch(arr, x, midIndex + 1, end);
                }
            }
        }
    }
}
