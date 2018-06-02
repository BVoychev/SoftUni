using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nested_Loops_To_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SimulateNestedLoops(new int[n]);
        }

        private static void SimulateNestedLoops(int[] arr, int currentIndex = 0)
        {
            if (currentIndex == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = 1; i <= arr.Length; i++)
                {
                    arr[currentIndex] = i;
                    SimulateNestedLoops(arr, currentIndex + 1);
                }
            }

        }
    }
}
