using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortest_Path
{
    class Program
    {
        static int count;
        static List<string> forPrinting = new List<string>();
       // static StringBuilder sb = new StringBuilder();
        static string input;      
        static char[] newArr;
        static char[] allPossibleDirections = new char[] { 'L', 'R', 'S' };
        static void Main(string[] args)
        {
            input = Console.ReadLine();
            newArr = new char[input.Length];
            count = 0;
            GetAllPossibleMaps(0);
            
            Console.WriteLine(count);
            foreach (var item in forPrinting.OrderBy(x=>x))
            {
                Console.WriteLine(item);
            }
            //Console.Write(sb);

        }

        private static void GetAllPossibleMaps(int index)
        {
            if (index >= input.Length)
            {
                //sb.AppendLine(string.Join("",newArr));
                forPrinting.Add(string.Join("", newArr));
                count++;
                return;
            }
            else
            {
                if (input[index] == '*')
                {
                    foreach (var direction in allPossibleDirections)
                    {
                        newArr[index] = direction;
                        GetAllPossibleMaps(index + 1);
                    }
                }
                else
                {
                    newArr[index] = input[index];
                    GetAllPossibleMaps(index + 1);
                }
            }
        }
    }
}
