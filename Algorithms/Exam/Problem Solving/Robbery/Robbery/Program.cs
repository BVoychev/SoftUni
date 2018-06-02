using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robbery
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
        static Dictionary<int, List<Edge>> nodeToEdges = new Dictionary<int, List<Edge>>();
        

        static void Main(string[] args)
        {
            string[] nodesInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int energy = int.Parse(Console.ReadLine());
            int waitingTime = int.Parse(Console.ReadLine());
            int startingNode = int.Parse(Console.ReadLine());
            int endingNode = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string[] colors = new string[nodesInfo.Length];
            string[] startingColors = new string[nodesInfo.Length];
            int steps = 1;
            for (int i = 0; i < nodesInfo.Length; i++)
            {
                string color = nodesInfo[i].Substring(nodesInfo[i].Length - 1);
                colors[i] = color;
                startingColors[i] = colors[i] == "w" ? "b" : "w";
            }
            var graph = new List<Edge>();
            for (int i = 0; i < n; i++)
            {
                int[] edgeInfo = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();
                Edge currentEdge = new Edge(edgeInfo[0], edgeInfo[1], edgeInfo[2]);
                graph.Add(currentEdge);
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

            var distance = new int[nodes.Max() + 1];

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = int.MaxValue;
            }

            distance[nodes.First()] = 0;

            var queue = new SortedSet<int>(
                Comparer<int>.Create((f, s) => distance[f] - distance[s]));

            queue.Add(nodes.First());

            while (queue.Count != 0)
            {
                var min = queue.Min;
                queue.Remove(min);
               
                foreach (var edge in nodeToEdges[min])
                {
                    var otherNode = edge.First == min
                        ? edge.Second
                        : edge.First;
                    if (distance[otherNode] == int.MaxValue)
                    {
                        queue.Add(otherNode);
                    }
                    var newDistance = 0;
                    if (steps % 2 != 0)
                    {
                        newDistance = distance[min] + edge.Weight + waitingTime;
                        if (colors[min] == "w")
                        {
                            newDistance = distance[min] + edge.Weight;

                        }
                        steps++;
                    }
                    else
                    {
                        newDistance = distance[min] + edge.Weight + waitingTime;
                        if (startingColors[min] == "w")
                        {
                            newDistance = distance[min] + edge.Weight;

                        }
                        steps++;
                    }                  
                  
                    if (newDistance < distance[otherNode])
                    {
                        distance[otherNode] = newDistance;
                        queue.Remove(otherNode);
                        queue.Add(otherNode);
                    }
                    
                }
              
            }
            Console.WriteLine(energy-distance[nodes.Count-1]);
        }

    }
}
