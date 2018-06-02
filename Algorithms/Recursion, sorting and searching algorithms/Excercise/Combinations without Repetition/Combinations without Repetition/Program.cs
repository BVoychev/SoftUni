using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations_without_Repetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            Combinations_without_Repetition(new int[k], n);
        }

        private static void Combinations_without_Repetition(int[] arr, int n,int currentIndex = 0,int border = 1)
        {
            if (currentIndex == arr.Length)
            {
                Console.WriteLine(string.Join(" ",arr));
            }
            else
            {
                for (int i = border; i <= n; i++)
                {
                    arr[currentIndex] = i;
                    Combinations_without_Repetition(arr, n, currentIndex + 1,i+1);
                }
            }
        }
    }
}
