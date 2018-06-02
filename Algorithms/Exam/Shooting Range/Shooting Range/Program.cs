using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting_Range
{
    class Program
    {
        static int score;
        static int[] targets;
        static bool[] marked;      

        static void Main(string[] args)
        {
            targets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            score = int.Parse(Console.ReadLine());
            marked = new bool[targets.Length];
            Gen(0);
        }

        private static void Gen(int index)
        {
            int tempScore = GetScore();
            if (tempScore == score)
            {
                var result = new List<int>();
                for (int i = 0; i < marked.Length; i++)
                {
                    if (marked[i])
                    {
                        result.Add(targets[i]);
                    }
                }
                Console.WriteLine(string.Join(" ",result));
            }

            if (index >= targets.Length)
            {
                return;
            }
            else
            {
                HashSet<int> set = new HashSet<int>();
                for (int i = index; i < targets.Length; i++)
                {
                    if (!set.Contains(targets[i]))
                    {
                        Swap(index, i);
                        marked[index] = true;

                        Gen(index + 1);

                        marked[index] = false;
                        Swap(index, i);

                        set.Add(targets[i]);
                    }
                }
            }
        }

       
        private static int GetScore()
        {
            int sum = 0;
            int multiplier = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (marked[i])
                {
                    sum += targets[i] * ++multiplier;
                }
            }

            return sum;
        }

        private static void Swap(int first, int second)
        {
            var temp = targets[first];
            targets[first] = targets[second];
            targets[second] = temp;
        }
    }
}
