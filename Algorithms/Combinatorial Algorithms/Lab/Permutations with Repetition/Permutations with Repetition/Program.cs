using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations_with_Repetition
{
    class Program
    {
        static string[] arr;

        static void Main(string[] args)
        {
            arr = Console.ReadLine().Split(' ').ToArray();
            Permutate(0);
        }

        private static void Permutate(int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ",arr));
            }
            else
            {
                HashSet<string> set = new HashSet<string>();
                for (int i = index; i < arr.Length; i++)
                {
                    if (!set.Contains(arr[i]))
                    {
                        Swap(index, i);
                        Permutate(index + 1);
                        Swap(index, i);
                        set.Add(arr[i]);
                    }                               
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
