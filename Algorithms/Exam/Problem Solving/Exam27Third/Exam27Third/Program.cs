using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam27Third
{
    class Program
    {
        static string[] arrComb;
        static string[] newArrComb;
        static List<string> allPossibleCombinationsOfGirls = new List<string>();
        static List<string> allPossibleCombinationsOfA = new List<string>();        

        static string[] arr;
        static string[] newArr;

        static string[] elements;
        static string[] variation;

        static HashSet<string> visited = new HashSet<string>();

        static List<string> result = new List<string>();

        static void Main(string[] args)
        {
            int girlsCount = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            //arr = new string[input.Length];
            //for (int i = 0; i < input.Length; i++)
            //{
            //arr[i] = input[i]+"";
            //}

            int k = 2;
            // newArr = new string[k];

            //variations
            elements = new string[input.Length];
            variation = new string[k];
            for (int i = 0; i < input.Length; i++)
            {
                elements[i] = input[i] + "";
            }
            elements = elements.Distinct().ToArray();

            //Comb
            arrComb = new string[girlsCount];
            for (int i = 0; i < girlsCount; i++)
            {
                arrComb[i] = $"{i}";
            }
            int kComb = 2;
            newArrComb = new string[kComb];
            GenComb(0, 0);

            foreach (var item in allPossibleCombinationsOfGirls.OrderBy(x => x))
            {
                char[] currentItem = item.ToCharArray();
                //GenCombA(0, 0);               
                Var(0);
                foreach (var x in allPossibleCombinationsOfA.Distinct().OrderBy(x => x))
                {
                    result.Add($"{currentItem[0]}{x[0]}-{currentItem[2]}{x[2]}");
                }
                allPossibleCombinationsOfA.Clear();
            }
            Console.WriteLine(result.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void GenComb(int index, int start)
        {
            if (index >= newArrComb.Length)
            {

                allPossibleCombinationsOfGirls.Add(string.Join(" ", newArrComb));
            }
            else
            {
                for (int i = start; i < arrComb.Length; i++)
                {
                    newArrComb[index] = arrComb[i];
                    GenComb(index + 1, i + 1);
                }
            }
        }

        private static void GenCombA(int index, int start)
        {
            if (index >= newArr.Length)
            {

                allPossibleCombinationsOfA.Add(string.Join(" ", newArr));
            }
            else
            {
                for (int i = start; i < arr.Length; i++)
                {
                    newArr[index] = arr[i];
                    GenCombA(index + 1, i + 1);
                }
            }
        }

        //variations

        public static void Var(int index)
        {
            if (index >= variation.Length)
                allPossibleCombinationsOfA.Add(string.Join(" ", variation));
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!visited.Contains(elements[i]))
                    {
                        visited.Add(elements[i]);
                        variation[index] = elements[i];
                        Var(index + 1);
                        visited.Remove(elements[i]);
                    }
                   
                }
            }
        }


    }
}
