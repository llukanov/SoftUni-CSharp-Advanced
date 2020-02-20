using System;
using System.Collections.Generic;
using System.Linq;

namespace SeashellTreasure
{
    class StartUp
    {
        static char[][] matrix;
        static int stolenSeashells;
        static int GullyRow;
        static int GullyCol;
        static char symbol = '-';
        static List<char> collectedSeashells = new List<char>();

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            ReadMatrix(rows);

            while (true)
            {
                string[] commandCurrent = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandCurrent[0] == "Collect")
                {
                    int row = int.Parse(commandCurrent[1]);
                    int col = int.Parse(commandCurrent[2]);

                    if (IsValidPostion(row, col)
                        && char.IsLetter(matrix[row][col]))
                    {
                        collectedSeashells.Add(matrix[row][col]);
                        ReplaceSymbol(row, col);
                    }
                }
                else if (commandCurrent[0] == "Steal")
                {
                    int row = int.Parse(commandCurrent[1]);
                    int col = int.Parse(commandCurrent[2]);
                    string direction = commandCurrent[3];

                    if (IsValidPostion(row, col)
                        && char.IsLetter(matrix[row][col]))
                    {
                        stolenSeashells++;
                        ReplaceSymbol(row, col);

                        GullyRow = row;
                        GullyCol = col;

                        for (int i = 0; i < 3; i++)
                        {
                            Move(direction);
                        }
                    }
                }
                else if (commandCurrent[0] == "Sunset")
                {
                    break;
                }
            }

            PrintMatrix();
            PrintReport();
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

        private static void PrintReport()
        {
            Console.Write($"Collected seashells: {collectedSeashells.Count}");
            if (collectedSeashells.Count > 0)
            {
                Console.WriteLine($" -> {string.Join(", ", collectedSeashells)}");
            }
            else
            {
                Console.WriteLine();
            }

            Console.WriteLine($"Stolen seashells: {stolenSeashells}");
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsValidPostion(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static void ReplaceSymbol(int row, int col)
        {
            matrix[row][col] = symbol;
        }

        private static void Move(string direction)
        {
            switch (direction)
            {
                case "up":
                    MoveOn(-1, 0);
                    break;
                case "down":
                    MoveOn(1, 0);
                    break;
                case "left":
                    MoveOn(0, -1);
                    break;
                case "right":
                    MoveOn(0, 1);
                    break;
                default:
                    break;
            }
        }

        private static void MoveOn(int row, int col)
        {
            if (IsValidPostion(GullyRow + row, GullyCol + col))
            {
                GullyRow += row;
                GullyCol += col;

                if (char.IsLetter(matrix[GullyRow][GullyCol]))
                {
                    stolenSeashells++;
                    ReplaceSymbol(GullyRow, GullyCol);
                }
            }
        }
    }
}
