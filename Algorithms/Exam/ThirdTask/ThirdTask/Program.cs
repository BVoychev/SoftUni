using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ThirdTask
{

    class Program
    {
        static char[] arr;

        static void Main(string[] args)
        {

            arr = Console.ReadLine().ToCharArray();
            Dictionary<char, int> final = new Dictionary<char, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!final.ContainsKey(arr[i]))
                {
                    final[arr[i]] = 1;
                }
                else
                {
                    final[arr[i]] += 1;
                }
            }
           

            BigInteger finalresult = Fac(arr.Length);
            BigInteger delitel = 1;
            foreach (var item in final)
            {
                delitel *= Fac(item.Value);
            }

            Console.WriteLine(finalresult/delitel);
            // Array.Sort(arr);
            // 
            // PermuteRep(arr, 0, arr.Length - 1);
            // Console.WriteLine(count);
            //}



            //Permutate(0);
            //Console.WriteLine(result.Count);

        }



        private static BigInteger Fac(BigInteger n)
        {
            if (n < 2)
            {
                return 1;
            }
            return n * Fac(n - 1);
        }


        static int count = 0;
        static void PermuteRep(char[] arr, int start, int end)
        {
            //result.Add(string.Join(" ",arr));
            count++;
            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, end);
                    }
                var firstElement = arr[left];
                for (int i = left; i <= end - 1; i++)
                    arr[i] = arr[i + 1];
                arr[end] = firstElement;
            }
        }

        private static void Swap(ref char i, ref char j)
        {
            if (i == j)
            {
                return;
            }

            i ^= j;
            j ^= i;
            i ^= j;
        }
        //private static void Swap(int index, int i)
        //{
        //    var temp = arr[index];
        //    arr[index] = arr[i];
        //    arr[i] = temp;
        //}
    }
}
