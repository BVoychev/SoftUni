using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance_Between_Vertices
{
    class Program
    {
       
        static void Main(string[] args)
        {
            int numberOfVertices = int.Parse(Console.ReadLine());
            int numberOfPairs = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> graph = ReadGraph(numberOfVertices);
            string[,] pairs = ReadPairs(numberOfPairs);

            for (int i = 0; i < numberOfPairs; i++)
            {
                int pathLength = FindShortestPath(graph, pairs[i, 0], pairs[i, 1]);
                Console.WriteLine($"{{{pairs[i, 0]}, {pairs[i, 1]}}} -> {pathLength}");
            }
        }

        private static int FindShortestPath(Dictionary<string, List<string>> graph, string a, string b)
        {
            Queue<string[]> queue = new Queue<string[]>();
            queue.Enqueue(new string[] { a, "0" });
            HashSet<string> visited = new HashSet<string>();
            visited.Add(a);

            while (queue.Count > 0)
            {
                string[] currVertex = queue.Dequeue();
                string vertex = currVertex[0];
                int currLength = int.Parse(currVertex[1]);

                if (vertex == b)
                {
                    return currLength;
                }

                for (int i = 0; i < graph[vertex].Count; i++)
                {
                    if (!visited.Contains(graph[vertex][i]))
                    {
                        queue.Enqueue(new string[] { graph[vertex][i], (currLength + 1).ToString() });
                        visited.Add(graph[vertex][i]);
                    }
                }
            }

            return -1;
        }

        private static Dictionary<string, List<string>> ReadGraph(int numberOfVertices)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            for (int i = 0; i < numberOfVertices; i++)
            {
                string[] args = Console.ReadLine()
                    .Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                string vertex = args[0];
                graph.Add(vertex, new List<string>());
                for (int j = 1; j < args.Length; j++)
                {
                    graph[vertex].Add(args[j]);
                }
            }

            return graph;
        }

        private static string[,] ReadPairs(int numberOfPairs)
        {
            string[,] pairs = new string[numberOfPairs, 2];
            for (int i = 0; i < numberOfPairs; i++)
            {
                string[] args = Console.ReadLine().Split('-');
                pairs[i, 0] = args[0];
                pairs[i, 1] = args[1];
            }

            return pairs;
        }
    }
}

