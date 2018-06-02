using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topological_Sorting
{
    class Program
    {
        static List<int>[] graph;

        static HashSet<int> GetNodesWithIncomingEdges()
        {
            var nodeWithIncomingEdges = new HashSet<int>();

            for (int i = 0; i < graph.Length; i++)
            {
                foreach (var node in graph[i])
                {
                    if (!nodeWithIncomingEdges.Contains(node))
                    {
                        nodeWithIncomingEdges.Add(node);
                    }
                }
            }

            return nodeWithIncomingEdges;
        }

        static void Main(string[] args)
        {
            graph = new List<int>[]
            {
                new List<int> {1,2},
                new List<int> {3,4},
                new List<int> {5},
                new List<int> {2,5},
                new List<int> {3},
                new List<int> {}
            };

            visited = new bool[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                DFS(i);
            }
            Console.WriteLine(string.Join(" ", sortedNodes));
            //var result = new List<int>();
            //var nodesWithoutIncomingEges = new HashSet<int>();
            //var nodeWithIncomingEdges = GetNodesWithIncomingEdges();

            //for (int i = 0; i < graph.Length; i++)
            //{
            //    if (!nodeWithIncomingEdges.Contains(i))
            //    {
            //        nodesWithoutIncomingEges.Add(i);
            //    }
            //}

            //while (nodesWithoutIncomingEges.Count != 0)
            //{
            //    var currentNode = nodesWithoutIncomingEges.First();
            //    nodesWithoutIncomingEges.Remove(currentNode);

            //    result.Add(currentNode);
            //    var children = graph[currentNode].ToList();
            //    graph[currentNode] = new List<int>();

            //    var leftNodesWithIncommingEdges = GetNodesWithIncomingEdges();

            //    foreach (var child in children)
            //    {
            //        if (!leftNodesWithIncommingEdges.Contains(child))
            //        {
            //            nodesWithoutIncomingEges.Add(child);
            //        }
            //    }
            //}

            //if (graph.SelectMany(s => s).Any())
            //{
            //    Console.WriteLine("Sorry!");
            //}
            //else
            //{
            //    Console.WriteLine(string.Join(" ", result));
            //}
        }
        //0 1 4 3 2 5 

        static bool[] visited;
        static HashSet<int> cycleNodes = new HashSet<int>();
        static LinkedList<int> sortedNodes = new LinkedList<int>();

        static void DFS(int node)
        {
            if (cycleNodes.Contains(node))
            {
                Console.WriteLine("Error Cycle detected!");
                return;
            }
            if (!visited[node])
            {
                visited[node] = true;
                cycleNodes.Add(node);
                foreach (var child in graph[node])
                {
                    DFS(child);

                }
                cycleNodes.Remove(node);
                sortedNodes.AddFirst(node);

            }
        }
    }
}
