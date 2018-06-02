using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestIncreasingSubSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var seq = new int[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };
            int[] lis = FindLIS(seq);
            Console.WriteLine(string.Join(" ",lis));
        }

        private static int[] FindLIS(int[] seq)
        {
            int count = seq.Length;
            int[] len = new int[count];
            int[] prev = new int[count];
            int maxLen = 0;
            int lastIndex = -1;

            for (int i = 0; i < count; i++)
            {
                len[i] = 1;
                prev[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if((seq[j]<seq[i])
                        && (len[j] + 1 > len[i]))
                    {
                        len[i] = len[j] + 1;
                        prev[i] = j;
                    }
                }

                if (len[i] > maxLen)
                {
                    maxLen = len[i];
                    lastIndex = i;
                }
            }

            var result = new Stack<int>();

            while (lastIndex >= 0)
            {
                result.Push(seq[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            return result.ToArray();
        }
    }
}
