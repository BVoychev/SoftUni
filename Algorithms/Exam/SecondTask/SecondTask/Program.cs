using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    class Program
    {
        static List<int>[] graph;
        static Dictionary<int, int> dict = new Dictionary<int, int>();
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }
                }
            }
            visited = new bool[graph.Length];
            count = 0;
            for (int i = 0; i < graph.Length; i++)
            {

                //visited = new bool[graph.Length];
                isConnected = false;
                Bfs(i);
                if (isConnected == true)
                {
                    count++;
                }

            }


            Console.WriteLine(count);
        }

        static bool[] visited;
        static bool isConnected = false;
        static int count = 0;
        private static void Bfs(int node)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node);
            visited[node] = true;
            while (queue.Count > 0)
            {
                var currnetNode = queue.Dequeue();               
                                     
                foreach (var child in graph[node])
                {

                    if (!visited[child])
                    {
                        if (graph[child].Contains(currnetNode))
                        {
                            count++;
                        }                      
                        queue.Enqueue(child);
                    }
                }

            }

        }
    }
}
