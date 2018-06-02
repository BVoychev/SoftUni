using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _27ExamFirst
{
    class Program
    {
        static Dictionary<int,List<int>> graph;
        static Dictionary<int, List<int>> graphCount;
        static Dictionary<int, List<int>> parent;
        static BigInteger[] result;

        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            graph = new Dictionary<int, List<int>>();
            graphCount = new Dictionary<int, List<int>>();
            parent = new Dictionary<int, List<int>>();
            result = new BigInteger[peopleCount];
            for (int i = 0; i < peopleCount; i++)
            {
                graphCount[i] = new List<int>();
                graph[i] = new List<int>();
                parent[i] = new List<int>();
            }
            for (int i = 0; i < peopleCount; i++)
            {
                      
                string rowInput = Console.ReadLine();
                int from = i;
                int to = int.MinValue;
                for (int j = 0; j < rowInput.Length; j++)
                {
                    if (rowInput[j] == 'R')
                    {
                        to = j;
                        graph[from].Add(to);
                        graphCount[from].Add(to);
                        parent[to].Add(from);
                    }
                }                
            }

            while (graph.Count>0)
            {
                int currentItem = graph.OrderBy(x => x.Value.Count).First().Key;
              
                var refCount = graphCount[currentItem].Count();


                if (refCount == 0 && result[currentItem]==0)
                {
                    result[currentItem] = 1;
                }
               
                foreach (var item in parent[currentItem])
                {
                    if (result[item] == 0)
                    {
                        result[item] = result[currentItem] * graphCount[item].Count();
                    }
                    else
                    {
                        result[item] += result[currentItem] * graphCount[item].Count();
                    }
                    graph[item].Remove(currentItem);
                }
                graph.Remove(currentItem);
            }

            BigInteger totalSum = 0;
            for (int i = 0; i < result.Length; i++)
            {
                totalSum += result[i];
            }
            Console.WriteLine($"${totalSum:F2}");
            
        }
    }
}
