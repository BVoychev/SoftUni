using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(number));
        }

        static long Factorial(int n)
        {
            if(n == 0 )
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }
    }
}
