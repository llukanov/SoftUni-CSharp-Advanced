using System;

namespace example
{
    class Program
    {
        static char[][] matrix;
        static int heroRow;
        static int heroCol;
        static char symbol = '-';
        // other

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            ReadMatrix(rows);
            FindPosition();
        }

        private static void ReadMatrix(int rows)
        {
            matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                char[] rowInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                matrix[row] = rowInput;
            }


        }

        private static void FindPosition(char letter)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == letter)
                    {
                        heroRow = row;
                        heroCol = col;
                    }
                }
            }
        }
    }
}
