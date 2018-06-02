using System;
using System.Collections.Generic;
using System.Linq;

public class ArticulationPointsMain
{
    static bool[] visited;
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int partsAfterExplosion = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];
        visited = new bool[graph.Length];
        for (int i = 0; i < n; i++)
        {
            int[] rowInput = Console.ReadLine()
                   .Split(' ')
                   .Select(x => int.Parse(x))
                   .Select(x=>x=x-1)
                   .ToArray();
            graph[i] = new List<int>(rowInput);                   
        }
        var articulationPoints = ArticulationPoints.FindArticulationPoints(graph);
        if (articulationPoints.Count==0)
        {
            Console.WriteLine("-2");
        }
        else
        {
            
            foreach (var node in articulationPoints)
            {
               
            }
        }
        
    }
}
public class ArticulationPoints
{
    private static List<int>[] graph;
    private static bool[] visited;
    private static int?[] parents;
    private static int[] depths;
    private static int[] lowpoints;
    private static List<int> articulationPoints;

    public static List<int> FindArticulationPoints(List<int>[] targetGraph)
    {
        graph = targetGraph;
        visited = new bool[targetGraph.Length];
        parents = new int?[visited.Length];
        depths = new int[visited.Length];
        lowpoints = new int[visited.Length];
        articulationPoints = new List<int>();

        FindArticulationPoints(0, 0);
        return articulationPoints;
    }

    private static void FindArticulationPoints(int node, int depth)
    {
        visited[node] = true;
        depths[node] = depth;
        lowpoints[node] = depth;
        int childCount = 0;
        bool isArticulation = false;
        foreach (var child in graph[node])
        {
            if (!visited[child])
            {
                parents[child] = node;
                FindArticulationPoints(child, depth + 1);
                childCount++;
                if (lowpoints[child] >= depths[node]) 
                {                                       
                    isArticulation = true; 
                }
                lowpoints[node] = Math.Min(lowpoints[node], lowpoints[child]);
            }
            else if (child != parents[node])
            {
                lowpoints[node] = Math.Min(lowpoints[node], depths[child]);
            }
        }
        if ((parents[node] != null && isArticulation) ||
            (parents[node] == null && childCount > 1))
        {
            articulationPoints.Add(node);
        }
    }
}