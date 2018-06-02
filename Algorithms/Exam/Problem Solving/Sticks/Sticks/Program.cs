using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticks
{
    class Program
    {
        static Dictionary<int,HashSet<int>> graph;
        static Dictionary<int, HashSet<int>> parents;

        static void Main(string[] args)
        {
            int sticksCount = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            parents = new Dictionary<int, HashSet<int>>();
            graph = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < sticksCount; i++)
            {
                graph[i] = new HashSet<int>();
                parents[i] = new HashSet<int>();
            }


            for (int i = 0; i < n; i++)
            {
                int[] inputInfo = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();
                int from = inputInfo[0];
                int to = inputInfo[1];
                graph[from].Add(to);
                parents[to].Add(from);
            }
            List<int> result = new List<int>();
            while (true)
            {
                var node = parents
                    .Where(x => parents[x.Key].Count==0)
                    .OrderByDescending(x => x.Key)
                    .FirstOrDefault();

                if (node.Value == null)
                {
                    break;
                }


                result.Add(node.Key);
                parents.Remove(node.Key);
                foreach (var child in graph[node.Key])
                {
                    parents[child].Remove(node.Key);
                }
                  
            }

            if (parents.Count > 0)
            {
                Console.WriteLine("Cannot lift all sticks");   
            }
            Console.WriteLine(string.Join(" ", result));

        }

    }
}
