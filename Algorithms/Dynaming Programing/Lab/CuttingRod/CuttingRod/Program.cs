using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuttingRod
{
    class Program
    {
        static int[] prices;
        static int[] bestPrice;
        static int[] bestPrev;


        static void Main(string[] args)
        {
            prices = new int[] {0,1,5,8,9,10,17,17,20,24,30 };
            bestPrice = new int[prices.Length];
            bestPrev = new int[prices.Length];
            int n = int.Parse(Console.ReadLine());
            int totalBest = CutRod(n);

            List<int> result = new List<int>();

            while (n > 0)
            {
                int next = bestPrev[n];
                result.Add(next);
                n -= next;
            }

            Console.WriteLine(totalBest);
            Console.WriteLine(String.Join(" ", result));
        }

        private static int CutRod(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                int currentBest = bestPrice[i];
                for (int j = 1; j <= i; j++)
                {
                    currentBest = Math.Max(bestPrice[i], prices[j] + bestPrice[i - j]);
                    if (currentBest > bestPrice[i])
                    {
                        bestPrice[i] = currentBest;
                        bestPrev[i] = j;
                    }
                }
            }
            return bestPrice[n];
        }
    }
}
