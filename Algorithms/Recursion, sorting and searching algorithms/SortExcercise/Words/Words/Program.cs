using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words
{
    class Program
    {
        private static int Count;
        static char[] symbols;
        static void Main(string[] args)
        {
            symbols = Console.ReadLine().ToCharArray();

            if (Optimization())
            {
                return;
            }
            GeneratePermutation(0);
            Console.WriteLine(Count);
        }

        private static bool Optimization()
        {
            var uniqueElements = new HashSet<char>();
            foreach (var c in symbols)
            {
                uniqueElements.Add(c);
            }

            if (uniqueElements.Count == symbols.Length)
            {
                Console.WriteLine(Factorial(uniqueElements.Count));
                return true;
            }
            return false;
        }

        private static int Factorial(int n)
        {
            if (n < 2)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }

        private static void GeneratePermutation(int index)
        {
            if (index == symbols.Length)
            {
                bool isValid = true;
                for (int i = 0; i < symbols.Length - 1; i++)
                {
                    if (symbols[i] == symbols[i + 1])
                    {
                        isValid = false;
                        break;
                    }
                    
                }
                if (isValid)
                {
                    Count++;
                }
                return;
            }

            var swapped = new HashSet<char>();
            for (int i = index; i < symbols.Length; i++)
            {
                if (!swapped.Contains(symbols[i]))
                {
                    char currentSymbol = symbols[index];
                    symbols[index] = symbols[i];
                    symbols[i] = currentSymbol;

                    GeneratePermutation(index + 1);

                    swapped.Add(symbols[index]);
                    symbols[i] = symbols[index];
                    symbols[index] = currentSymbol;
                }
            }
        }
    }
}
