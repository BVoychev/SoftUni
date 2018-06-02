using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_de_Sofia
{
    class Program
    {
        static List<int>[] graph;
        static int count = 0;
        static void Main(string[] args)
        {
            int numbersOfNode = int.Parse(Console.ReadLine());
            int numbersOfStreets = int.Parse(Console.ReadLine());

           
            visited = new bool[numbersOfNode];
            graph = new List<int>[numbersOfNode];
            for (int i = 0; i < numbersOfNode; i++)
            {
                graph[i] = new List<int>();
            }
            int startOfTheRoad = int.Parse(Console.ReadLine());


            for (int i = 0; i < numbersOfStreets; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                int from = int.Parse(inputArgs[0]);
                int to = int.Parse(inputArgs[1]);
                graph[from].Add(to);
            }

            Bfs(startOfTheRoad);
            bool printresult = false;
            
            foreach (var pair in result.OrderBy(x=>x.Value))
            {
                if (graph[pair.Key].Contains(startOfTheRoad))
                {
                    Console.WriteLine(pair.Value+1);
                    printresult = true;
                    return;
                }
               
            }

            if (printresult == false)
            {
                Console.WriteLine(result.Count);
            }
        }

        static bool[] visited;
        static Dictionary<int, int> result = new Dictionary<int, int>();

        private static void Bfs(int node)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node);
           
            visited[node] = true;
            result.Add(node, count);
            bool isAdd = true;
            while (queue.Count > 0)
            {
               
                var newNode = queue.Dequeue();
                if (isAdd)
                {
                    count++;
                }
                isAdd = false;
                foreach (var child in graph[newNode])
                {
                    if (!visited[child])
                    {
                        queue.Enqueue(child);              
                        result.Add(child, count);
                        isAdd = true;
                        visited[child] = true;                        
                    }
                }
            }
        }
    }
}
