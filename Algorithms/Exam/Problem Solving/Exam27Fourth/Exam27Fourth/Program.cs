using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam27Fourth
{
    class Program
    {
        static List<int>[] graph;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int partsAfterExplosion = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                int[] rowInput = Console.ReadLine()
                       .Split(' ')
                       .Select(x => int.Parse(x))
                       .Select(x => x = x - 1)
                       .ToArray();
                graph[i] = new List<int>(rowInput);
            }
            bool isPrinted = false;

            var firstResult = StronglyConnectedComponents.FindStronglyConnectedComponents(graph);
            if (firstResult.Count > 1)
            {
                Console.WriteLine("-2");
                isPrinted = true;
                return;
            }
            
         
            for (int i = 0; i < n; i++)
            {
                int currentNode = i;
                List<int> currentList = graph[i];
                graph[i] = new List<int>();
                

                var result = StronglyConnectedComponents.FindStronglyConnectedComponents(graph);
                if (result.Count  == 1 || result.Count - 1 > partsAfterExplosion)
                {
                    Console.WriteLine("0");
                    isPrinted = true;
                    return;
                }               
                else if (result.Count - 1 == partsAfterExplosion)
                {
                    Console.WriteLine(i + 1);
                    isPrinted = true;
                    return;
                }

                graph[i] = currentList;
            }
            if (isPrinted == false)
            {
                Console.WriteLine("-1");
            }
        }

    }
    public class StronglyConnectedComponents
    {
        private static Stack<int> nodes;
        private static bool[] visited;
        private static List<int>[] graph;
        private static List<int>[] reverseGraph;

        public static List<List<int>> FindStronglyConnectedComponents(List<int>[] targetGraph)
        {
            nodes = new Stack<int>();
            graph = targetGraph;
            reverseGraph = new List<int>[graph.Length];
            visited = new bool[graph.Length];
            for (int node = 0; node < targetGraph.Length; node++)
            {
                DFS(node);
            }
            for (int i = 0; i < reverseGraph.Length; i++)
            {
                reverseGraph[i] = new List<int>();
            }
            for (int node = 0; node < graph.Length; node++)
            {
                foreach (var child in graph[node])
                {
                    reverseGraph[child].Add(node);
                }
            }
            visited = new bool[graph.Length];
            var connectedComponents = new List<List<int>>();
            foreach (var node in nodes)
            {
                if (!visited[node])
                {
                    List<int> connectedNodes = new List<int>();
                    ReverseDFS(node, connectedNodes);
                    connectedComponents.Add(connectedNodes);
                }
            }
            return connectedComponents;
        }

        private static void ReverseDFS(int node, List<int> connectedNodes)
        {
            if (!visited[node])
            {
                visited[node] = true;
                connectedNodes.Add(node);
                foreach (var child in reverseGraph[node])
                {
                    ReverseDFS(child, connectedNodes);
                }
            }
        }

        private static void DFS(int node)
        {
            if (!visited[node])
            {
                visited[node] = true;
                foreach (var child in graph[node])
                {
                    DFS(child);
                }
                nodes.Push(node); }
        }
    }
}
