using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variations_without_Repetition
{
    class Program
    {
        static string[] arr;
        static string[] newArr;
        static bool[] used;
        
        static void Main(string[] args)
        {
            arr = Console.ReadLine().Split(' ').ToArray();
            int k = int.Parse(Console.ReadLine());
            newArr = new string[k];
            used = new bool[arr.Length];
            Gen(0);
        }

        private static void Gen(int index)
        {
            if (index >= newArr.Length)
            {
                Console.WriteLine(string.Join(" ",newArr));
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        newArr[index] = arr[i];
                        Gen(index + 1);
                        used[i] = false;
                    }

                }
            }
        }
    }
}
