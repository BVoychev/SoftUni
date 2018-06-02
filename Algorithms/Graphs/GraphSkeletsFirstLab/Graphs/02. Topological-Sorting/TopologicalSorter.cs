using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;
    private Dictionary<string, int> predecessorCount;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSort()
    {
        this.GetPredecessorCount();
        List<string> sortedNodes = new List<string>();

        while (true)
        {
            string nodeToRemove = predecessorCount.Keys
                .Where(n => predecessorCount[n] == 0)
                .FirstOrDefault();

            if (nodeToRemove == null)
            {
                break;
            }

            foreach (var child in graph[nodeToRemove])
            {
                predecessorCount[child]--;
            }

            predecessorCount.Remove(nodeToRemove);
            sortedNodes.Add(nodeToRemove);
        }

        if (predecessorCount.Count > 0)
        {
            throw new InvalidOperationException();
        }

        return sortedNodes;
    }

    private void GetPredecessorCount()
    {
        predecessorCount = new Dictionary<string, int>();
        foreach (var node in graph)
        {
            if (!predecessorCount.ContainsKey(node.Key))
            {
                predecessorCount.Add(node.Key, 0);
            }

            foreach (var child in node.Value)
            {
                if (!predecessorCount.ContainsKey(child))
                {
                    predecessorCount.Add(child, 0);
                }

                predecessorCount[child]++;
            }
        }
    }
}
