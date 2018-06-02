using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Keeper
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] univers = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(x => int.Parse(x))
                 .ToArray();
            HashSet<int> universSet = new HashSet<int>(univers);
            int[] orders = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(x => int.Parse(x))
                 .ToArray();
            if (!universSet.Contains(orders[0]))
            {
                Console.WriteLine("impossible");
                return;
            }
            int count = 0;
            for (int i = 1; i < orders.Length; i++)
            {
                if (universSet.Contains(orders[i]))
                {
                    continue;
                }
                Stack<int> stack = new Stack<int>();
                for (int j = i; j < orders.Length; j++)
                {
                    if (universSet.Contains(orders[j]) && !stack.Contains(orders[j]))
                    {
                        stack.Push(orders[j]);
                    }
                }
                foreach (var item in universSet)
                {
                    if (!stack.Contains(item))
                    {
                        stack.Push(item);
                    }
                }
                int temp = stack.Pop();
                universSet.Remove(temp);
                universSet.Add(orders[i]);
                count++;
            }

            Console.WriteLine(count);
        }
    }
}
