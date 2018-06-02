using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Card_Shuffle
{
    class Program
    {
        static int[] arr;

        static void Main(string[] args)
        {
            arr = new int[] { 2, 10, 20, 12, 14, 7, 3, 1, 0, 5, 19 };
            Console.WriteLine(String.Join(" ", arr));
           
            for (int i = 0; i < 5; i++)
            {
                Shuffle();
                Console.WriteLine(String.Join(" ", arr));
            }           
        }

        static void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                int index = random.Next(i, arr.Length);
                var temp = arr[i];
                arr[i] = arr[index];
                arr[index] = temp;
            }
        }
    }
}
