using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Array
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            PrintReversedArray(arr,arr.Length);
        }

        private static void PrintReversedArray(int[] arr, int length)
        {
            if (length == 0)
            {
                return;
            }
            Console.Write(arr[length-1]+" ");
            PrintReversedArray(arr, length - 1);
        }
    }
}
