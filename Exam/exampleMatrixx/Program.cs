using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm
{
    public class StartUP
    {
        static int rows;
        static char[][] matrix;
        static int heroRow;
        static int heroCol;
        static char symbol = '-';
        static char heroSymbol = 'P';

        static string initialString;
        static Stack<char> word;


        static void Main(string[] args)
        {
            initialString = Console.ReadLine();
            word = new Stack<char>(initialString);

            rows = int.Parse(Console.ReadLine());

            ReadMatrix(rows);
            FindPosition('P');

            string command = Console.ReadLine();
            while (command != "end")
            {
                Move(command);

                command = Console.ReadLine();
            }

            PrintReport();
            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]}");
                }
                Console.WriteLine();
            }
        }

        private static void PrintReport()
        {
            string wordNew = string.Join(string.Empty, word.Reverse());
            Console.WriteLine(wordNew);
        }

        private static bool IsValidPostion(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static void MoveOn(int row, int col)
        {
            if (IsValidPostion(heroRow + row, heroCol + col))
            {
                heroRow += row;
                heroCol += col;

                char currentSymbol = matrix[heroRow][heroCol];
                if (char.IsLetter(currentSymbol))
                {
                    word.Push(currentSymbol);
                }

                matrix[heroRow][heroCol] = heroSymbol;
                matrix[heroRow - row][heroCol - col] = symbol;
            }
            else
            {
                if (word.Any())
                {
                    word.Pop();
                }
            }
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

        private static void FindPosition(char letter)
        {
            for (int row = 0; row < rows; row++)
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

        private static void FindFinalMark(char letter)
        {
            for (int row = 0; row < rows; row++)
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

        private static void ReadMatrix(int rows)
        {
            matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();
                matrix[row] = currentRow;
            }
        }
    }
}
