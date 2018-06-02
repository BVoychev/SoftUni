using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paths_in_Labyrinth
{
    class Program
    {
        private static char[,] matrix;
        private static LinkedList<char> path = new LinkedList<char>();
    

        private static void ReadLab()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string currentLine = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }
        }

        private static void Solve(int row, int col, char direction)
        {
            if (!IsInBound(row, col))
            {
                return;
            }
            path.AddLast(direction);
            if (IsExit(row, col))
            {
               
                PrintPath();
            }
            else if(!IsVisited(row,col) && IsFree(row,col))
            {
                Mark(row, col);
                Solve(row, col + 1,'R');
                Solve(row + 1, col,'D');
                Solve(row, col - 1, 'L');
                Solve(row - 1, col, 'U');
                UnMark(row, col);
            }
            if (path.Count != 0)
            {
                path.RemoveLast();
            }
            

        }

        private static void UnMark(int row, int col)
        {
            matrix[row, col] = '-';
        }

        private static void Mark(int row, int col)
        {
            matrix[row, col] = '#';
        }

        private static bool IsFree(int row, int col)
        {
            if (matrix[row, col] != '*')
            {
                return true;
            }
            return false;
        }

        private static bool IsVisited(int row, int col)
        {
            if (matrix[row, col] == '#')
            {
                return true;
            }
            return false;
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("",path.Skip(1)));
        }

        private static bool IsExit(int row, int col)
        {
            if (matrix[row, col] == 'e')
            {
                return true;
            }
            return false;
        }

        private static bool IsInBound(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0))
            {
                return false;
            }
            if(col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            ReadLab();
            Solve(0, 0,'R');
        }

    }
}
