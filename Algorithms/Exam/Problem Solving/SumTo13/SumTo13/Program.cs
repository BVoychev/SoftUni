using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumTo13
{
    class Program
    {
        static int[] arr;
        static int[] newArr;
        static bool[] used;
        static bool isPrinted = false;
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            arr = new int[numbers.Length * 2];
            for (int i = 0; i < numbers.Length; i++)
            {
                arr[i] = numbers[i];
                int reversedNumber = numbers[i] * (-1);
                arr[i+3]=reversedNumber;
            }
           
            newArr = new int[3];
            used = new bool[arr.Length];
            Gen(0);
            if (!isPrinted)
            {
                Console.WriteLine("No");
            }
        }

        private static void Gen(int index)
        {
            if (index >= newArr.Length)
            {
                if (newArr.Sum() == 13)
                {
                    Console.WriteLine("Yes");
                    isPrinted = true;
                    return;
                }
                return;
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
                        if (isPrinted)
                        {
                            return;
                        }
                        used[i] = false;
                    }

                }
            }
        }
    }
}
