using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Choose_K_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());            
            Console.WriteLine(Binom(n,k));
        }

        private static decimal Binom(int n, int k)
        {
            if (k > n)
                return 0;
            if (k == 0 || k == n)
                return 1;
            return Binom(n - 1, k - 1) + Binom(n - 1, k);
        }
    }
}
