using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Areas_in_Matrix
{
    class Program
    {
        private static SortedDictionary<char, int> areas = new SortedDictionary<char, int>();
        private static bool[][] visited;

        public static void Main()
        {
            char[][] matrix = ReadMatrix();
            visited = new bool[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                visited[i] = new bool[matrix[i].Length];
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (!visited[i][j])
                    {
                        VisitArea(matrix, i, j);
                    }
                }
            }

            Console.WriteLine($"Areas: {areas.Values.Sum()}");
            foreach (var letter in areas.Keys)
            {
                Console.WriteLine($"Letter '{letter}' -> {areas[letter]}");
            }
        }

        private static void VisitArea(char[][] matrix, int startRow = 0, int startCol = 0)
        {
            if (!areas.ContainsKey(matrix[startRow][startCol]))
            {
                areas.Add(matrix[startRow][startCol], 0);
            }

            areas[matrix[startRow][startCol]]++;

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { startRow, startCol });
            while (queue.Count > 0)
            {
                int[] coordinattes = queue.Dequeue();
                int row = coordinattes[0];
                int col = coordinattes[1];

                if (IsInBounds(matrix, row, col) && matrix[row][col] == matrix[startRow][startCol] && !visited[row][col])
                {
                    visited[row][col] = true;
                    queue.Enqueue(new int[] { row - 1, col });
                    queue.Enqueue(new int[] { row, col + 1 });
                    queue.Enqueue(new int[] { row + 1, col });
                    queue.Enqueue(new int[] { row, col - 1 });
                }
            }
        }

        private static bool IsInBounds(char[][] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }

        private static char[][] ReadMatrix()
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            return matrix;
        }
    }
}
