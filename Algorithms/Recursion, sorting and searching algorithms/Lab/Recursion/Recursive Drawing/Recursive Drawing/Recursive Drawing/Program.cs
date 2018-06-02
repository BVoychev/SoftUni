using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Drawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Draw(number);
        }

        private static void Draw(int n)
        {
            if (n == 0)
            {
                return;
            }
            Console.WriteLine(new string('*',n));
            Draw(n - 1);
            Console.WriteLine(new string('#',n));
        }
    }
}
