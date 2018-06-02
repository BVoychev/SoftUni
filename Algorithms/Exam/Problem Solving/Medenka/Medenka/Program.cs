using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medenka
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {

            string[] medenkaInput = Console.ReadLine()
                .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string medenka = string.Join("", medenkaInput);
            List<int> result = new List<int>();

            int start = medenka.IndexOf('1');
            int nuts = GetNutsCount(medenka);
            GenerateCuts(start,0,nuts, medenka, result);
            Console.Write(sb);
            
        }

        private static int GetNutsCount(string medenka)
        {
            int nuts = 0;
            for (int i = 0; i < medenka.Length; i++)
            {
                if (medenka[i] == '1')
                {
                    nuts++;
                }
            }
            return nuts;
        }

        private static void GenerateCuts(int start,int cuts,int nuts, string medenka, List<int> result)
        {
            if (cuts==nuts-1)
            {
                Print(medenka, result);
            }
            else
            {
                int end = medenka.IndexOf('1', start + 1);

                for (int i = start; i <end; i++)
                {
                    result.Add(i);
                    GenerateCuts(end,cuts+1,nuts, medenka, result);
                    result.RemoveAt(result.Count-1);
                }
            }
        }

        private static void Print(string medenka, List<int> result)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < medenka.Length; i++)
            {
                stringBuilder.Append(medenka[i]);
                if ( result.Contains(i)){
                    stringBuilder.Append('|');
                }
                
            }
            sb.AppendLine(stringBuilder.ToString());
        }
    }
}

