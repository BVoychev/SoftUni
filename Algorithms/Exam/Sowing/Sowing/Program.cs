using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sowing
{
    class Program
    {
        static int[] fields;
        static int seeds;
        static bool[] marked;

        static void Main(string[] args)
        {

            seeds = int.Parse(Console.ReadLine());
            
            fields = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            marked = new bool[fields.Length];
            for (int i = 0; i < fields.Length; i++)
            {
                int[] newArr = new int[fields.Length];
                Array.Copy(fields, newArr, fields.Length);
                Gen(i, seeds, false, newArr);
                for (int j = 0; j < marked.Length; j++)
                {
                    marked[j] = false;
                }
            }
        }

        private static void Gen(int index, int seedsLeft, bool lastIndexPlanted, int[] newArray)
        {

            if (seedsLeft == 0)
            {

                foreach (var item in newArray)
                {
                    if (item == 5)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write(item);
                    }
                }
                Array.Copy(fields, newArray, fields.Length);
                seedsLeft = seeds;
                Console.WriteLine();
                lastIndexPlanted = false;
                return;

            }
            if (index >= newArray.Length)
            {
                Array.Copy(fields, newArray, fields.Length);
                seedsLeft = seeds;
                lastIndexPlanted = false;
                return;
            }

            for (int i = index; i < newArray.Length; i++)
            {
                if (!marked[index])
                {
                    if (newArray[index] != 0 && lastIndexPlanted != true)
                    {
                        marked[index] = true;
                        newArray[index] = 5;
                        lastIndexPlanted = true;
                        seedsLeft--;
                    }
                    else
                    {
                        lastIndexPlanted = false;
                    }
                    Gen(index + 1, seedsLeft, lastIndexPlanted, newArray);
                }
            }
            
        }
    }
}
