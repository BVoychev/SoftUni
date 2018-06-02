using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumber
{
    class Log
    {
        public int Id { get; set; }

        public int X1 { get; set; }

        public int Y1 { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }

        public Log(int id, int x1, int y1, int x2, int y2)
        {
            this.Id = id;
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }
        public bool Intersect(Log other)
        {
            bool horizontalIntersection = this.X1 <= other.X2 && this.X2 >= other.X1;
            bool verticalIntersection = this.Y1 >= other.Y2 && this.Y2 <= other.Y1;
            return horizontalIntersection && verticalIntersection;
        }

        public override string ToString()
        {
            return this.Id.ToString();
        }
    }
    class Program
    {
        static List<int>[] graph;
        static int count;

        static void Main(string[] args)
        {

            int[] inputArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int logCount = inputArgs[0];
            int queriesCount = inputArgs[1];

            List<Log> logs = new List<Log>();
            graph = new List<int>[logCount + 1];

            for (int i = 1; i <= logCount; i++)
            {
                inputArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
                int x1 = inputArgs[0];
                int y1 = inputArgs[1];
                int x2 = inputArgs[2];
                int y2 = inputArgs[3];
                Log log = new Log(i, x1, y1, x2, y2);
                graph[i] = new List<int>();
                foreach (var element in logs)
                {
                    if (element.Intersect(log))
                    {
                        graph[element.Id].Add(i);
                        graph[i].Add(element.Id);
                    }
                }
                logs.Add(log);
            }

            bool[] visited = new bool[logCount + 1];
            int[] id = new int[logCount + 1];


            for (int i = 1; i < logCount+1; i++)
            {

                if (!visited[i])
                {
                    Dfs(i, id, visited);
                    count++;
                }
            }

            for (int i = 0; i < queriesCount; i++)
            {

                inputArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(x => int.Parse(x))
                   .ToArray();
                int startLog = inputArgs[0];
                int endLog = inputArgs[1];
                if (id[startLog] == id[endLog])
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }

            }



        }

        private static void Dfs(int vertex, int[] id, bool[] visited)
        {

            visited[vertex] = true;
            id[vertex] = count;
            foreach (var child in graph[vertex])
            {
                if (!visited[child])
                {
                    Dfs(child, id, visited);
                }

            }
        }
    }

}

