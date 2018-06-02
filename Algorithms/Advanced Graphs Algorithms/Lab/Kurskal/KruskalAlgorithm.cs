namespace Kurskal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KruskalAlgorithm
    {

        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            var result = new List<Edge>();
            var nodes = edges
                .Select(x => x.StartNode)
                .Union(edges.Select(x => x.EndNode))
                .Distinct()
                .ToList();
            int[] parent = new int[nodes.Max()+1];

            foreach (var node in nodes)
            {
                parent[node] = node;
            }

            var sortedEdges = edges.OrderBy(x => x.Weight);

            foreach (var edge in sortedEdges)
            {
                var rootStart = FindRoot(edge.StartNode, parent);
                var rootEnd = FindRoot(edge.EndNode, parent);
                if (rootStart != rootEnd)
                {
                    result.Add(edge);
                    parent[rootStart] = rootEnd;
                }
            }
            return result;
        }

        public static int FindRoot(int node, int[] parent)
        {
            while(parent[node] != node)
            {
                node = parent[node];
            }
            return node;
        }
    }
}
