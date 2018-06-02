using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generating_01_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] vec = new int[n];
            Vector(0,vec);
        }

        private static void Vector(int index, int[] vector)
        {
            if(index >= vector.Length)
            {
                Console.WriteLine(string.Join("",vector));
                return;
            }
            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Vector(index + 1, vector);
            }
        }
    }
}
