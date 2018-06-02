using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _27ExamTable
{
    class Program
    {
        static Dictionary<BigInteger, BigInteger> factorialMemo = new Dictionary<BigInteger, BigInteger>();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger handsheaks = GetHeandshakes(n);
            Console.WriteLine(handsheaks);
        }

        private static BigInteger GetHeandshakes(int n)
        {
            if (n % 2 == 1)
            {
                return 0;
            }
            factorialMemo[0] = 1;
            Memoize(n*2);
            return Catlan(n / 2);
            
        }

        private static void Memoize(int n)
        {
            BigInteger result = 1;
            for (int i = 1; i <= n; i++)
            {
                result = i * factorialMemo[i - 1];
                factorialMemo[i] = result;
            }
        }

        private static BigInteger Catlan(int n)
        {
            return factorialMemo[2*n] / factorialMemo[n + 1] / factorialMemo[n];
        }

        private static int Fac(int n)
        {
            if (n < 2)
            {
                return 1;
            }
            return n * Fac(n - 1);
        }
    }
}
