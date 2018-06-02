using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generating_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int arrSize = int.Parse(Console.ReadLine());
            int[] newArr = new int[arrSize];
            GeneratingCombinations(arr,newArr);
        }

        private static void GeneratingCombinations(int[] arr,int[] newArr, int currentIndex = 0, int border = 0)
        {
            if (newArr.Length == currentIndex)
            {
                Console.WriteLine(string.Join(" ",newArr));
            }
            else
            {
                for (int i = border; i < arr.Length; i++)
                {
                    newArr[currentIndex] = arr[i];
                    GeneratingCombinations(arr, newArr, currentIndex + 1, i+1);
                }
            }
        }
    }
}
