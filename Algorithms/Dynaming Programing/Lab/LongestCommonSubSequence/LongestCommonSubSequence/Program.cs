using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubSequence
{
    class Program
    {
        static int[,] lcs;
        static string firstStr;
        static string secondStr;

        static void Main(string[] args)
        {
            firstStr = Console.ReadLine();
            secondStr = Console.ReadLine();
            lcs = new int[firstStr.Length, secondStr.Length];

            CalcLCS(firstStr.Length - 1, secondStr.Length - 1);
            Console.WriteLine(lcs[lcs.GetLength(0) - 1, lcs.GetLength(1) - 1]);
            var x = lcs.GetLength(0) - 1;
            var y = lcs.GetLength(1) - 1;
            var result = PrintLCS(x, y);
            Console.WriteLine(result);
        }

        private static string PrintLCS(int x, int y)
        {
            var lcsLetter = new List<char>();
            while(x>=0 && y >= 0)
            {
                if (firstStr[x] == secondStr[y] &&
               (CalcLCS(x - 1, y - 1) + 1 == lcs[x, y]))
                {
                    lcsLetter.Add(firstStr[x]);
                    x--;
                    y--;
                }
                else if (CalcLCS(x - 1, y) == lcs[x, y])
                {
                    x--;
                }
                else
                {
                    y--;
                }

            }

            lcsLetter.Reverse();
            return string.Join("", lcsLetter);
        }

        private static int CalcLCS(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return 0;
            }
            if (lcs[x, y] == 0)
            {
                int lcsFirstMinusOne = CalcLCS(x - 1, y);
                int lcsSecondMinusOne = CalcLCS(x, y - 1);
                lcs[x, y] = Math.Max(lcsFirstMinusOne, lcsSecondMinusOne);
                if (firstStr[x] == secondStr[y])
                {
                    int lcsBothMinusOne = 1 + CalcLCS(x - 1, y - 1);
                    lcs[x, y] = Math.Max(lcsBothMinusOne, lcs[x, y]);
                }
            }
            return lcs[x, y];
        }
    }
}
