using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int sum = Sum(arr, 0);
            Console.WriteLine(sum);
        }

        private static int Sum(int[] array,int index)
        {
            if(array.Length == index)
            {
                return 0;
            }
            return array[index] + Sum(array, index + 1);
        }
    }
}
