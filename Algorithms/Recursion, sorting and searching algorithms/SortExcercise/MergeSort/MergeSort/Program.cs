using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] {3,7,8,5,2,1,9,5,4 };

            Quick.Sort(arr);
            Console.WriteLine(String.Join(" ",arr));
        }
    }


}
