using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Non_corssing_Bridges
{
    class Line
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Line> lines = new List<Line>();
            int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i+1; j < input.Length; j++)
                {
                    if(input[i] == input[j])
                    {
                        lines.Add(new Line { Start = i, End = j, Value = input[i] });
                    }
                }
            }
            var result = new int[input.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = 'X';
            }
            var sortedLines = lines.OrderBy(x => x.End).ToList() ;
            var queue = new Queue<Line>();
            var item = sortedLines.First();
            result[item.Start] = (char)item.Value;
            result[item.End] = (char)item.Value;
            queue.Enqueue(item);
            var count = 1;
           
            while (sortedLines.Count>0)
            {
                
                sortedLines.RemoveAll(x=>x.Start<item.End);
                if (sortedLines.Count > 0)
                {
                    item = sortedLines.First();
                    result[item.Start] = (char)item.Value;
                    result[item.End] = (char)item.Value;
                    queue.Enqueue(item);
                    count++;
                }
               
            }
            
            Console.WriteLine(count + " bridges found");           
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
