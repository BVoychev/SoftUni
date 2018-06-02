using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    static List<int>[] graph = new List<int>[]
    {
        new List<int>() { 3, 6 },
        new List<int>() { 3, 4, 5, 6 },
        new List<int>() { 8 },
        new List<int>() { 0, 1, 5 },
        new List<int>() { 1, 6 },
        new List<int>() { 1, 3 },
        new List<int>() { 0, 1, 4 },
        new List<int>() { },
        new List<int>() { 2 }
    };

    static bool[] visited;

    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    private static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
        }
        return graph;
    }

    static int components = 0;

    static List<int> list = new List<int>();

    private static void FindGraphConnectedComponents()
    {
       
        visited = new bool[graph.Length];
        for (int i = 0; i < graph.Length; i++)
        {           
            if (!visited[i])
            {
                components++;
                Console.Write($"Connected component: ");
                Dfs(i);
                Console.Write(string.Join(" ",list));
                Console.WriteLine();
                list.Clear();
            }
        }
    }

    private static void Dfs(int n)
    {
        if (!visited[n])
        {
            visited[n] = true;
            foreach (var child in graph[n])
            {
                Dfs(child);
            }
            list.Add(n);
        }
    }
}
