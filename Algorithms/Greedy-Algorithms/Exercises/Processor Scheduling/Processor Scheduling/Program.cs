using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor_Scheduling
{
    class Task
    {
        public int Value { get; set; }
        public int DeadLine { get; set; }
        public int Position { get; set; }

        public Task(int value,int deadline,int position)
        {
            this.Value = value;
            this.DeadLine = deadline;
            this.Position = position;
        }
    }
    class Program
    {
        static HashSet<Task> tasks = new HashSet<Task>();
        static HashSet<Task> result = new HashSet<Task>();
        static int steps;
        static int totalValue = 0;
        static void Main(string[] args)
        {
            var numberOfTasks = int.Parse(Console.ReadLine().Split(' ')[1]);
            for (int i = 1; i <= numberOfTasks; i++)
            {
                var taskArgs = Console.ReadLine().Split(' ').ToArray();
                var value = int.Parse(taskArgs[0]);
                var deadline = int.Parse(taskArgs[2]);
                var task = new Task(value,deadline,i);              
                tasks.Add(task);
            }

            steps = tasks.Max(x=>x.DeadLine);
            Optimizate(0);

            Console.WriteLine("Optimal schedule: "
                + string.Join(" -> ", result
                .OrderBy(x => x.DeadLine)
                .ThenByDescending(x => x.Value)
                .Select(x => x.Position))
                );
            Console.WriteLine("Total value: " + totalValue);
        }

        private static void Optimizate(int step)
        {
            while (step < steps)
            {
                var value = tasks.Select(x => x.Value).OrderByDescending(x => x).First();
                var task = tasks.Where(x => x.Value == value).First();
                result.Add(task);
                tasks.RemoveWhere(x => x.Value == value);
                totalValue += value;
                step++;
            }

        }
    }
}
