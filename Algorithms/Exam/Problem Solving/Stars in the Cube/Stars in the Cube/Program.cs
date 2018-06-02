using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stars_in_the_Cube
{
    class Program
    {
        static char[,,] cube;
        static Dictionary<char, int> result = new Dictionary<char, int>();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            cube = new char[n,n,n];
            FillCube(n, cube);
            int starsCount = BruteForce(n);

            Console.WriteLine(starsCount);
            foreach (var item in result.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }

        private static int BruteForce(int size)
        {
            int count = 0;
            for (int row = 1; row < size-1; row++)
            {
                for (int col = 1; col < size-1; col++)
                {
                    for (int height = 1; height < size-1; height++)
                    {
                        char currentLetter = cube[row, col, height];
                        if (CheckTheNeighbours(currentLetter,row,col,height))
                        {
                            if (!result.ContainsKey(currentLetter))
                            {
                                result[currentLetter] = 1;
                            }
                            else
                            {
                                result[currentLetter] += 1;
                            }
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        private static bool CheckTheNeighbours(char currentLetter,int row,int col,int height)
        {
            bool starExist = true;
            if (cube[row, col, height+1] != currentLetter)
            {
                starExist = false;
            }
            if (cube[row, col, height - 1] != currentLetter)
            {
                starExist = false;
            }
            if (cube[row, col+1, height] != currentLetter)
            {
                starExist = false;
            }
            if (cube[row, col-1, height] != currentLetter)
            {
                starExist = false;
            }
            if (cube[row+1, col, height] != currentLetter)
            {
                starExist = false;
            }
            if (cube[row-1, col, height] != currentLetter)
            {
                starExist = false;
            }
            return starExist;
        }

        private static void FillCube(int n, char[,,] cube)
        {
            for (int i = 0; i < n; i++)
            {
                string[] layers = Console.ReadLine()
                    .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < layers.Length; j++)
                {
                    string[] rowInfo = layers[j]
                         .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int k = 0; k < rowInfo.Length; k++)
                    {
                        cube[i, j, k] = rowInfo[k][0];
                    }
                }
            }
        }
    }
}
