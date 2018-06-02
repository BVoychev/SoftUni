using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence
{
    class Program
    {
        static int[] arr;

        static int[] newArr;

        static int n;

        static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            arr = new int[n];

            Gen(0, 0, n, arr);
            Console.Write(sb);
        }

        private static void Gen(int index, int currSum, int targetSum, int[] variations)
        {
            if(currSum <= targetSum && currSum != 0)
            {
                sb.AppendLine(string.Join(" ", variations.TakeWhile(x => x != 0)));
            }
            if (currSum >= targetSum)
            {
                return;
            }

            for (int i = 1; i <= targetSum; i++)
            {
                variations[index] = i;

                Gen(index + 1,currSum+i,targetSum,variations);
            }
            variations[index] = 0;

        }

    }
}
