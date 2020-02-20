using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationEstablishment
{
    class StartUp
    {
        static char[][] matrix;
        static int spaceshipRow;
        static int spaceshipCol;
        static char symbol = '-';
        static int rows;

        static bool isLost = false;
        static bool isWin = false;
        static int energy;

        static void Main(string[] args)
        {
            rows = int.Parse(Console.ReadLine());
            ReadMatrix(rows);
            FindPosition('S');

            while (true)
            {
                if (energy < 50 && isLost == false)
                {
                    string command = Console.ReadLine();
                    Move(command);
                }
                else
                {
                    break;
                }
                
            }

            PrintReport();
            PrintMatrix();
        }

        private static void FindPosition(char letter)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == letter)
                    {
                        spaceshipRow = row;
                        spaceshipCol = col;
                    }
                }
            }
        }

        private static void ReadMatrix(int rows)
        {
            matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();
                matrix[row] = rowInput;
            }
        }

        private static void PrintReport()
        {
            if (isWin)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }
            else if (isLost)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            Console.WriteLine($"Star power collected: {energy}");
        }

        private static void PrintMatrix()
        {
            if (energy >= 50)
            {
                matrix[spaceshipRow][spaceshipCol] = 'S';
            }
            
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]}");
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
            if (IsValidPostion(spaceshipRow + row, spaceshipCol + col))
            {
                ReplaceSymbol(spaceshipRow, spaceshipCol);
                spaceshipRow += row;
                spaceshipCol += col;

                if (char.IsDigit(matrix[spaceshipRow][spaceshipCol]))
                {
                    energy += int.Parse(matrix[spaceshipRow][spaceshipCol].ToString());
                    ReplaceSymbol(spaceshipRow, spaceshipCol);
                    IsCollectEnoughPower();
                }
                else if (matrix[spaceshipRow][spaceshipCol] == 'O')
                {
                    ReplaceSymbol(spaceshipRow, spaceshipCol);
                    FindPosition('O');
                    ReplaceSymbol(spaceshipRow, spaceshipCol);
                }
            }
            else
            {
                isLost = true;
            }
        }

        private static void IsCollectEnoughPower()
        {
            if (energy >= 50)
            {
                isWin = true;
            }
        }
    }
}