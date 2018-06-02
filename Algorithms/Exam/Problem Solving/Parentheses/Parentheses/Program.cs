using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parentheses
{
    class Program
    {
        static string[] arr;
        static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            arr = new string[n * 2];
            for (int i = 0; i < n; i++)
            {
                arr[i] = "(";
            }
            for (int i = n; i < n * 2; i++)
            {
                arr[i] = ")";
            }
            Gen(0);
            Console.Write(sb);
        }

        private static void Gen(int index)
        {
            
            if (index >= arr.Length)
            {
                int aType = 0;
                int bType = 0;
                bool isCorrect = true;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == "(")
                    {
                        aType++;
                    }
                    else
                    {
                        bType++;
                        if (aType - bType < 0)
                        {
                            isCorrect = false;
                            break;
                        }
                    }                    
                }
                if (isCorrect)
                {
                    // Console.WriteLine(string.Join("", arr));
                    sb.AppendLine(string.Join("", arr));
                }

            }
            else
            {
                HashSet<string> set = new HashSet<string>();
                for (int i = index; i < arr.Length; i++)
                {
                    if (!set.Contains(arr[i]))
                    {                       
                        Swap(index, i);
                        Gen(index + 1);
                        Swap(index, i);
                        set.Add(arr[i]);
                    }
                }
            }
        }

        private static void Swap(int index, int i)
        {
            var temp = arr[index];
            arr[index] = arr[i];
            arr[i] = temp;
        }
    }
}
