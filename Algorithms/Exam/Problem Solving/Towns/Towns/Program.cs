using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towns
{
    class Program
    {       
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] townsPopulation = new long[n];
            //long[] townsPopulation = new long[] { 0, 1, 5, 4, 3 };
           
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
                long population = long.Parse(input[0]);
                townsPopulation[i] = population;
            }
            long[] townsPopulationRev = townsPopulation.Reverse().ToArray();
            int[] lIS = new int[townsPopulation.Length];
            lIS = FindLongestIncreasingSequence(lIS,townsPopulation);

            int[] lDS = new int[townsPopulation.Length];
            lDS = FindLongestIncreasingSequence(lDS,townsPopulationRev).Reverse().ToArray();

            int sum = 0;
           
            for (int i = 0; i < lDS.Length; i++)
            {           
                int currentSum = lDS[i] + lIS[i];
                if (currentSum > sum)
                {
                    sum = currentSum;
                }
               
            }                     

            Console.WriteLine(sum-1);
        }

        private static int[] FindLongestIncreasingSequence(int[] len,long[] townsPopulation)
        {
            int count = townsPopulation.Length;                   
            int maxLen = 0;
            

            for (int i = 0; i < count; i++)
            {
                len[i] = 1;               
                for (int j = 0; j < i; j++)
                {
                    if ((townsPopulation[j] < townsPopulation[i])
                        && (len[j] + 1 > len[i]))
                    {
                        len[i] = len[j] + 1;
                        
                    }
                }

                if (len[i] > maxLen)
                {
                    maxLen = len[i];
                    
                }
            }

            return len;
        }

    }
}
