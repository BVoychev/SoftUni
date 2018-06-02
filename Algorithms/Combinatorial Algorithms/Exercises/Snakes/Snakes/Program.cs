using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes
{
    class Program
    {
        static char[] currentSnake;
        static HashSet<string> visitedCell = new HashSet<string>();
        static HashSet<string> result = new HashSet<string>();
        static HashSet<string> allPossibleSnakes = new HashSet<string>();

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            currentSnake = new char[n];
            Gen(0, 0, 0, 'S');
            foreach (var snake in result)
            {
                Console.WriteLine(snake);
            }
            Console.WriteLine($"Snakes count = " + result.Count);
        }

        private static void Gen(int index, int row, int col, char direction)
        {

            if (index >= currentSnake.Length)
            {
                MarkSnake();
            }
            else
            {
                var cell = $"{row} {col}";


                if (!visitedCell.Contains(cell))
                {
                    currentSnake[index] = direction;

                    visitedCell.Add(cell);

                    Gen(index + 1, row, col + 1, 'R');
                    Gen(index + 1, row + 1, col, 'D');
                    Gen(index + 1, row, col - 1, 'L');
                    Gen(index + 1, row - 1, col, 'U');

                    visitedCell.Remove(cell);
                }

            }
        }

        private static void MarkSnake()
        {
            var snake = new string(currentSnake);
            if (allPossibleSnakes.Contains(snake))
            {
                return;
            }
            result.Add(snake);

            var flippedSnake = Flip(snake);
            var reversedSnake = Reverse(snake   );
            var reversedFlippedSnake = Flip(reversedSnake);

            for (int i = 0; i < 4; i++)
            {
                allPossibleSnakes.Add(snake);
                snake = Rotate(snake);

                allPossibleSnakes.Add(flippedSnake);
                flippedSnake = Rotate(flippedSnake);

                allPossibleSnakes.Add(reversedSnake);
                reversedSnake = Rotate(reversedSnake);

                allPossibleSnakes.Add(reversedFlippedSnake);
                reversedFlippedSnake = Rotate(reversedFlippedSnake);
            }

        }

        private static string Rotate(string snake)
        {
            var newSnake = new char[snake.Length];
            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'R':
                        newSnake[i] = 'D';
                        break;
                    case 'D':
                        newSnake[i] = 'L';
                        break;
                    case 'L':
                        newSnake[i] = 'U';
                        break;
                    case 'U':
                        newSnake[i] = 'R';
                        break;
                    default:
                        newSnake[i] = snake[i];                        
                        break;
                }
            }
            return new string(newSnake);
        }

        private static string Reverse(string snake)
        {
            var newSnake = new char[snake.Length];
            newSnake[0] = snake[0];
            for (int i = 1; i < snake.Length; i++)
            {
                newSnake[snake.Length - i] = snake[i];
            }
            return new string(newSnake);
        }

        private static string Flip(string snake)
        {
            var newSnake = new char[snake.Length];
            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'U':
                        newSnake[i] = 'D';
                        break;
                    case 'D':
                        newSnake[i] = 'U';
                        break;
                    default:
                        newSnake[i] = snake[i];
                        break;
                }
            }
            return new string(newSnake);
        }
    }
}
