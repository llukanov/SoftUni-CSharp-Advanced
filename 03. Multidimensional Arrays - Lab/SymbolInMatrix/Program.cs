using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read N (row and col)
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            // Read Matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = (int)currentRow[col];
                }
            }

            // Read symbol
            char symbol = char.Parse(Console.ReadLine());
            int symbolASCII = (int)symbol;

            // Find first occurrence, if has
            string occurrence = string.Empty;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbolASCII)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
