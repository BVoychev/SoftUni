using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubSet_Sum
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] arr = new int[] { 8,3,2,1,12,1};
            int targetSum = 16;
            var possibleSums = CalcPossibleSum(arr, targetSum);
            var result = FindSubset(arr, targetSum, possibleSums);
            Console.WriteLine(string.Join(" ",result));
        }

        static List<int> FindSubset(int[] arr,int targestSum,IDictionary<int,int> possibleSums)
        {
            var subset = new List<int>();

            while (targestSum > 0)
            {
                var lastNum = possibleSums[targestSum];
                subset.Add(lastNum);
                targestSum -= lastNum;
            }

            subset.Reverse();
            return subset;
        }

        static IDictionary<int,int> CalcPossibleSum(int[] nums,int targetSum)
        {
            var possibleSums = new Dictionary<int,int>();
            possibleSums.Add(0, 0);

            for (int i = 0; i < nums.Length; i++)
            {
                var newSums = new Dictionary<int,int>();
                foreach (var sum in possibleSums.Keys)
                {
                    int newSum = sum + nums[i];
                    if (!possibleSums.ContainsKey(newSum))
                    {
                        newSums.Add(newSum,nums[i]);
                    }
                }
                foreach (var sum in newSums)
                {
                    possibleSums.Add(sum.Key, sum.Value);
                }
            }

            return possibleSums;
        }
    }
}
