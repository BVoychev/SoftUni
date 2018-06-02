using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitar
{
    class Program
    {
        static bool[,] matrix;

        static int initialValue;

        static int maxVolume;

        static int[] nums;

        static void Main(string[] args)
        {
            nums = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            initialValue = int.Parse(Console.ReadLine());
            maxVolume = int.Parse(Console.ReadLine());
            matrix = new bool[nums.Length + 1, maxVolume+1];
            FillMatrix();
            int maxVolumeGet = int.MinValue;
            bool isFoundMaxVolume = false;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[matrix.GetLength(0) - 1, i] == true)
                {
                    isFoundMaxVolume = true;
                    if (i > maxVolumeGet)
                    {
                        maxVolumeGet = i;
                    }
                }
            }
            if (!isFoundMaxVolume)
            {
                Console.WriteLine("-1");
            }
            else
            {
                Console.WriteLine(maxVolumeGet);
            }

        }

        private static void FillMatrix()
        {
            matrix[0, initialValue] = true;

            for (int rows = 1; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if(matrix[rows-1,cols]==true && cols + nums[rows-1] <= maxVolume)
                    {
                        matrix[rows, cols + nums[rows-1]] = true;
                    }
                    if (matrix[rows-1, cols]==true && cols - nums[rows-1] >= 0)
                    {
                        matrix[rows, cols - nums[rows-1]] = true;
                    }
                }
            }         
        }
    }
}
