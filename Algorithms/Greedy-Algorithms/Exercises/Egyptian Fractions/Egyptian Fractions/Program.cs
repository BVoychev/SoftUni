using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptian_Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] input = Console.ReadLine().Split('/').Select(x => long.Parse(x)).ToArray();

            var numerator = input[0]; //43
            var denominator = input[1];//48

            if (denominator < numerator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }
            Console.Write($"{numerator}/{denominator} = ");

            var index = 2;
            var result = new List<int>();
            while (numerator != 0)
            {
                var nextNumerator = numerator * index;
                var indexNumerator = denominator;

                var remaining = nextNumerator - indexNumerator;

                if (remaining < 0)
                {
                    index++;
                    continue;
                }
                result.Add(index);
                
                numerator = remaining;
                denominator = denominator * index;
                index++;

            }

            Console.WriteLine(
                string.Join(" + ",result.Select(r=>$"1/{r}")));
        }
    }
}
