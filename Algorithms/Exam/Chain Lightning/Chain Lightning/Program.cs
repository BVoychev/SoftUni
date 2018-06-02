using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Chain_Lightning
{
    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    class Program
    {

        static HashSet<int> spanningTree = new HashSet<int>();
        static Dictionary<int, List<Edge>> nodeToEdges = new Dictionary<int, List<Edge>>();
        static List<int>[] msp;
        static bool[] visited;
        static Dictionary<int, int> result = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            int numbersOfNeightbours = int.Parse(Console.ReadLine());
            int numbersOfDistance = int.Parse(Console.ReadLine());
            int numbersOfLightnings = int.Parse(Console.ReadLine());
            var graph = new List<Edge>();
            visited = new bool[numbersOfNeightbours];
            msp = new List<int>[numbersOfNeightbours];
            for (int i = 0; i < numbersOfNeightbours; i++)
            {
                msp[i] = new List<int>();
                result[i] = 0;
            }

           
            for (int i = 0; i < numbersOfDistance; i++)
            {
                string[] edgeArgs = Console.ReadLine().Split().ToArray();
                int from = int.Parse(edgeArgs[0]);
                int to = int.Parse(edgeArgs[1]);
                int distance = int.Parse(edgeArgs[2]);
                graph.Add(new Edge { First = from, Second = to, Weight = distance });
            }

            var nodes = graph
                 .Select(e => e.First)
                 .Union(graph.Select(e => e.Second))
                 .Distinct()
                 .OrderBy(e => e)
                 .ToList();

            foreach (var edge in graph)
            {
                if (!nodeToEdges.ContainsKey(edge.First))
                {
                    nodeToEdges[edge.First] = new List<Edge>();
                }
                if (!nodeToEdges.ContainsKey(edge.Second))
                {
                    nodeToEdges[edge.Second] = new List<Edge>();
                }

                nodeToEdges[edge.First].Add(edge);
                nodeToEdges[edge.Second].Add(edge);
            }


            foreach (var node in nodes)
            {
                if (!spanningTree.Contains(node))
                {
                    Prime(node);
                }
            }

            for (int i = 0; i < numbersOfLightnings; i++)
            {
                string[] largs = Console.ReadLine().Split();
                int start = int.Parse(largs[0]);
                int damage = int.Parse(largs[1]);
                Dfs(start,damage);
            }

            Console.WriteLine(result.OrderByDescending(x=>x.Value).First().Value);
           
        }

        private static void Dfs(int start, int damage)
        {
            visited[start] = true;
            result[start] += damage;

            foreach (var child in msp[start])
            {
                if (!visited[child])
                {
                    Dfs(child, damage / 2);
                    visited[child] = false;
                }
                
            }
            visited[start] = false;

        }

        static void Prime(int startingNode)
        {
            spanningTree.Add(startingNode);

            var priorityQueue = new OrderedBag<Edge>(
                Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            priorityQueue.AddMany(nodeToEdges[startingNode]);

            while (priorityQueue.Count != 0)
            {
                var minEdge = priorityQueue.GetFirst();
                priorityQueue.Remove(minEdge);

                var firstNode = minEdge.First;
                var secondeNode = minEdge.Second;
                var nonTreeNode = -1;

                if (spanningTree.Contains(firstNode) &&
                    !spanningTree.Contains(secondeNode))
                {
                    nonTreeNode = secondeNode;
                }

                if (spanningTree.Contains(secondeNode) &&
                    !spanningTree.Contains(firstNode))
                {
                    nonTreeNode = firstNode;
                }

                if (nonTreeNode == -1)
                {
                    continue;
                }

                spanningTree.Add(nonTreeNode);
                //Console.WriteLine($"{minEdge.First} - {minEdge.Second}");
                msp[minEdge.First].Add(minEdge.Second);
                msp[minEdge.Second].Add(minEdge.First);
                priorityQueue.AddMany(nodeToEdges[nonTreeNode]);
            }

        }

    }
}
