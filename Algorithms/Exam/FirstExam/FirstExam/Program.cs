using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FirstExam
{
    class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }

    class Program
    {
        static BigInteger[,] matrix;
        static int[,] marked;
        static Position basePosition;
        static long count = 0;

        static void Main(string[] args)
        {
            int[] sizeOftheMatrix = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int[] homeInfo = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            matrix = new BigInteger[sizeOftheMatrix[0], sizeOftheMatrix[1]];
            marked = new int[sizeOftheMatrix[0], sizeOftheMatrix[1]];

            Position zergPosition = new Position { Row = 0, Col = 0 };
            basePosition = new Position { Row = homeInfo[0], Col = homeInfo[1] };
            matrix[zergPosition.Row, zergPosition.Col] = 1;            
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                int enemisValue = int.MinValue;
                int[] enemisInfo = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                matrix[enemisInfo[0], enemisInfo[1]] = enemisValue;
            }

            bool cancelTheRoot = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if(matrix[row,0] == int.MinValue)
                {
                    cancelTheRoot = true;
                    continue;
                }
                if(matrix[row,0] != int.MinValue && cancelTheRoot == false)
                {
                    matrix[row, 0] = 1;
                }
                else
                {
                    matrix[row, 0] = 0;
                }
                
            }

            cancelTheRoot = false;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
               
                if (matrix[0, col] == int.MinValue)
                {
                    cancelTheRoot = true;
                }
                if ( matrix[0, col] != int.MinValue && cancelTheRoot == false)
                {
                    matrix[0, col] = 1;
                }
                else
                {
                    matrix[0,col] = 0;
                }

            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                   
                    if(matrix[row,col] != int.MinValue)
                    {
                        BigInteger d1 = 0;
                        BigInteger d2 = 0;
                        if (matrix[row, col-1] != int.MinValue)
                        {
                            d1 = matrix[row, col - 1];
                        }
                        if (matrix[row-1, col] != int.MinValue)
                        {
                            d2 = matrix[row-1, col];
                        }
                       matrix[row, col] = d1 + d2;
                    }

                }
            }

            Console.WriteLine(matrix[basePosition.Row,basePosition.Col]);
            //Backtracking(0,0);           
            //Console.WriteLine(count);

        }

      

        static void Backtracking(int row,int col)
        {
            if (row == basePosition.Row && col== basePosition.Col)
            {
                count++;
            }

            else
            {
                if (row+1<matrix.GetLength(0) && matrix[row + 1, col] != int.MinValue && marked[row + 1, col] != 1)
                {
                    marked[row + 1, col] = 1;
                    Backtracking(row + 1, col);
                    marked[row + 1, col] = 0;
                }
                if (col+1<matrix.GetLength(1) && matrix[row, col+1] != int.MinValue && marked[row, col+1] != 1)
                {
                    marked[row, col+1] = 1;
                    Backtracking(row, col+1);
                    marked[row, col+1] = 0;
                }
            }                  
                
        }

    }
}
