using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class Program
    {
        static bool[] visited;

        static List<int>[] graph;

        static List<int> result = new List<int>();

        static void Main(string[] args)
        {

            graph = new List<int>[]
            {
                new List<int> {3 ,6},
                new List<int> {2,3,4,5,6},
                new List<int> {1,4,5},
                new List<int> {0,1,5},
                new List<int> {1,2,6},
                new List<int> {1,2,3},
                new List<int> {0,1,4}
            };

            visited = new bool[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                BFS(i);
            }

            Console.WriteLine(string.Join(" ", result));
        }

        static void BFS(int n)
        {
            if (visited[n])
            {
                return;
            }
            visited[n] = true;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                result.Add(current);

                foreach (var child in graph[current])
                {
                    if (!visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }
        }
    }
}
