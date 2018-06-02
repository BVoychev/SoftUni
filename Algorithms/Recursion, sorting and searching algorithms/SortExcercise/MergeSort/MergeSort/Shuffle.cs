using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    static class Shuffle
    {
        public static void ShuffleAlgortihm<T>(T[] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length-1; i++)
            {
                var randomIndex = random.Next(i + 1, arr.Length);
                Helper.Swap(arr, i,randomIndex ); 
            }
        }
    }
}
