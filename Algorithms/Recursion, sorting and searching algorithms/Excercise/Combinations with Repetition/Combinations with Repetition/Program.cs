using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations_with_Repetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            SimulatingNastedLoop(new int[k], n);
        }

        private static void SimulatingNastedLoop(int[] arr, int n, int currentIndex = 0, int s = 1)
        {
            if(currentIndex == arr.Length)
            {
                Console.WriteLine(string.Join(" ",arr));
            }
            else
            {
                for (int i = s; i <= n; i++)
                {
                    arr[currentIndex] = i;                   
                    SimulatingNastedLoop(arr, n, currentIndex + 1,i);
                }
            }
        }
    }
}
