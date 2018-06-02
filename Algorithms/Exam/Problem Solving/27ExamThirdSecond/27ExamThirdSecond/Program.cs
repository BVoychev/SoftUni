using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27ExamThirdSecond
{
    class Program
    {
        static string[] arrNum;
        static string[] arrAlpha;
        static string[] newArrComb;
        static List<string> allPossibleCombinationsOfGirls = new List<string>();
        static List<string> numA = new List<string>();
        static Dictionary<char, int> dict = new Dictionary<char, int>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[] input = Console.ReadLine().ToCharArray();
            int numbersOfGirls = int.Parse(Console.ReadLine());
            newArrComb = new string[numbersOfGirls];
            arrNum = new string[n];
            arrAlpha = new string[input.Length];
            for (int i = 0; i < n; i++)
            {
                arrNum[i] = i + "";
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!dict.ContainsKey(input[i]))
                {
                    dict[input[i]] = 1;
                }
                else
                {
                    dict[input[i]] += 1;
                }
                arrAlpha[i] = input[i] + "";
            }
           
            for (int i = 0; i < n; i++)
            {
                foreach (var item in arrAlpha.Distinct().OrderBy(x=>x))
                {                  
                    numA.Add($"{i}{item}");
                }
            }
            
            GenCombNum(0, 0);
            Console.WriteLine(allPossibleCombinationsOfGirls.Count());
            foreach (var item in allPossibleCombinationsOfGirls)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private static void GenCombNum(int index, int start)
        {
            if (index >= newArrComb.Length)
            {
                char aShirt = newArrComb[0][0];
                char bShirt = newArrComb[1][0];
                string aSkirt = newArrComb[0].Substring(1);
                string bSkirt = newArrComb[1].Substring(1);
                if ( aShirt!=bShirt)
                {
                    if(aSkirt==bSkirt && dict[aSkirt.ToCharArray()[0]] <= 1)
                    {

                    }
                    else
                    {
                        allPossibleCombinationsOfGirls.Add(string.Join("-", newArrComb));
                    }
                   
                }
                
            }
            else
            {
                for (int i = start; i < numA.Count; i++)
                {                    
                    newArrComb[index] = numA[i];
                    GenCombNum(index + 1, i + 1);
                }
            }
        }
    }
}
