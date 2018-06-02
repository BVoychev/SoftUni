using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_Lightning
{
    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
        public Edge(int first,int second,int weight)
        {
            this.First = first;
            this.Second = second;
            this.Weight = weight;
        }

    }
    class Program
    {
        static List<int>[] graph;
        static Dictionary<int,List<Edge>> edges;
        static bool[] visited;
        static int[] damages;

        static void Main(string[] args)
        {
            int nodesCount = int.Parse(Console.ReadLine());
            graph = new List<int>[nodesCount];
            edges = new Dictionary<int, List<Edge>>();
            
            visited = new bool[nodesCount];
            damages = new int[nodesCount];
            for (int i = 0; i < nodesCount; i++)
            {
                graph[i] = new List<int>();
                edges[i] = new List<Edge>();
            }

            int rowsInput = int.Parse(Console.ReadLine());
            int chainHitsInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < rowsInput; i++)
            {
                int[] edgeInfo = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();
                int first = edgeInfo[0];
                int second = edgeInfo[1];
                int weight = edgeInfo[2];
                Edge edge = new Edge(first, second, weight);
                if (!edges.ContainsKey(first))
                {
                    edges[first] = new List<Edge>();
                    edges[first].Add(edge);
                }
                else
                {
                    edges[first].Add(edge);
                }
                if (!edges.ContainsKey(second))
                {
                    edges[second] = new List<Edge>();
                    edges[second].Add(edge);
                }
                else
                {
                    edges[second].Add(edge);
                }
                graph[first].Add(second);
                graph[second].Add(first);
            }
            
            for (int i = 0; i < chainHitsInput; i++)
            {
                int[] lightningInfo = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();
                int node = lightningInfo[0];
                int damage = lightningInfo[1];
                damages[node] = damage;

                HashSet<Edge> set = new HashSet<Edge>();
                visited[node] = true;
                foreach (var edge in edges[node])
                {
                    set.Add(edge);
                }

                while(set.Count > 0)
                {
                    Edge currentEdge = set.OrderBy(x => x.Weight).First();
                    set.Remove(currentEdge);
                    if (!visited[currentEdge.Second])
                    {
                        damages[currentEdge.Second] += damages[currentEdge.First]/2;
                        visited[currentEdge.Second] = true;
                        foreach (var child in edges[currentEdge.Second])
                        {
                            set.Add(child);
                        }
                    }

                }
            }

            Console.WriteLine();

        }
    }
}
