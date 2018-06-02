using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations_without_Repetition
{
    class Program
    {
        static string[] arr;
        static string[] newArr;
       
        static void Main(string[] args)
        {
            arr = Console.ReadLine().Split(' ').ToArray();
            int k = int.Parse(Console.ReadLine());
            newArr = new string[k];
            Gen(0, 0);
        }

        private static void Gen(int index, int start)
        {
            if (index >= newArr.Length)
            {
                Console.WriteLine(string.Join(" ", newArr));
            }
            else
            {
                for (int i = start; i < arr.Length; i++)
                {
                    newArr[index] = arr[i];
                    Gen(index + 1, i);
                }
            }
        }
    }
}
