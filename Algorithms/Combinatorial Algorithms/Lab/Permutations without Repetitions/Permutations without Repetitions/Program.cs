using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations_without_Repetitions
{
    class Program
    {
        static string[] arr;
        static void Main(string[] args)
        {
            arr = Console.ReadLine().Split(' ').ToArray();
            Gen(0);
        }

        private static void Gen(int index)
        {
            if(index>= arr.Length)
            {
                Console.WriteLine(string.Join(" ",arr));
            }
            else
            {
                for (int i = index; i < arr.Length; i++)
                {
                    Swap(index, i);
                    Gen(index + 1);
                    Swap(index, i);
                }
            }
        }

        private static void Swap(int index, int i)
        {
            var temp = arr[index];
            arr[index] = arr[i];
            arr[i] = temp;
        }
    }
}
