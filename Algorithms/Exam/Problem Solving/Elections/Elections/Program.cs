using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Elections
{
    class Program
    {
         
        static void Main(string[] args)
        {
            int[] arr;
            int targetVotes;
            BigInteger count = 0;
            BigInteger[] sums;
            targetVotes = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            sums = new BigInteger[arr.Sum()+1];
            sums[0] = 1;

            foreach (var number in arr)
            {
                for (int i = sums.Length-1; i >=0; i--)
                {
                    if (sums[i] != 0)
                    {
                        sums[i + number] += sums[i];
                    }
                }
            }

            for (int i = targetVotes; i < sums.Length; i++)
            {
                count += sums[i];
            }
            Console.WriteLine(count);
        }

    }
}