using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connected_Areas_in_a_Matrix
{
    class Program
    {
        const char WALL = '*';
        const char VISITED = 'v';
        static char[,] matrix;
        static List<Area> areas = new List<Area>();

        class Area : IComparable<Area>
        {

            public int row { get; set; }
            public int col { get; set; }
            public int size { get; set; }
            public Area(int row, int col)
            {
                this.row = row;
                this.col = col;
                this.size = 0;
            }

            public int CompareTo(Area other)
            {
                int cmp = other.size.CompareTo(this.size);
                if (cmp == 0)
                {
                    cmp = this.row.CompareTo(other.row);
                }
                if (cmp == 0)
                {
                    cmp = this.col.CompareTo(other.col);
                }
                return cmp;
            }
        }

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            matrix = ReadMatrix(rows, cols);



            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    FindConnectedArea(row, col);
                }
            }

            areas.Sort();
            PrintAllAreas();
        }

        private static void PrintAllAreas()
        {
            int counter = 1;
            Console.WriteLine($"Total areas found: {areas.Count}");
            foreach (var area in areas)
            {
                Console.WriteLine($"Area #{counter} at ({area.row}, {area.col}), size: {area.size}");
                counter++;
            }
        }

        private static void FindConnectedArea(int row, int col)
        {
            if (matrix[row, col] == WALL || matrix[row, col] == VISITED)
            {
                return;
            }
            Area area = new Area(row, col);         
            FillArea(row, col,area);
            areas.Add(area);
        }

        private static void FillArea(int row, int col,Area area)
        {
            if(IsOutBound(row,col) || IsVisited(row, col))
            {
                return;
            }
            matrix[row, col] = VISITED;
            area.size++; 
            FillArea(row + 1, col,area );
            FillArea(row, col + 1, area);
            FillArea(row - 1, col, area);
            FillArea(row, col - 1, area);
        }

        private static bool IsVisited(int row, int col)
        {
            if(matrix[row,col]==VISITED || matrix[row, col] == WALL)
            {
                return true;
            }
            return false;
        }

        private static bool IsOutBound(int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            return matrix;
        }
    }
}
