using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuuensPuzzle
{
    class Program
    {
        private const int Size = 8;
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedColumns = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        static int[,] board = new int[Size, Size];

        static void Solve(int row)
        {
            if (row == Size)
            {
                PrintSolution();
                return;
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAttackedFields(row, col);
                        Solve(row + 1);
                        UnmarkAttackedFields(row, col);
                    }
                }
            }
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (board[row, col] == 1)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void UnmarkAttackedFields(int row, int col)
        {
            board[row, col] = 0;
            attackedColumns.Remove(col);
            attackedRows.Remove(row);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(col + row);
        }

        private static void MarkAttackedFields(int row, int col)
        {
            board[row, col] = 1;
            attackedColumns.Add(col);
            attackedRows.Add(row);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(col + row);
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            if (attackedColumns.Contains(col)
                || attackedRows.Contains(row)
                || attackedLeftDiagonals.Contains(col - row)
                || attackedRightDiagonals.Contains(col + row))
            {
                return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Solve(0);
        }
    }
}
