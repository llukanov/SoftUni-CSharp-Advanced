using System;
using System.Collections.Generic;

namespace PresentDelivery
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char[] initialWord = Console.ReadLine()
                .ToCharArray();
            Stack<char> word = new Stack<char>(initialWord);

            int santaRow = -1;
            int santaCol = -1;
            bool santaPositionFound = false;
            int kidsWithPresents = 0;
            int kidsWithoutPresents = 0;

            // the count of presents
            int presentsCount = int.Parse(Console.ReadLine());
            // size of the neighbourhood
            int n = int.Parse(Console.ReadLine());
            char[][] field = new char[n][];

            InitialiseField(n, field, ref santaRow, ref santaCol, ref santaPositionFound);

            string command = Console.ReadLine();
            while (command != "Christmas morning")
            {
                if (command == "up")
                {
                    if (santaRow - 1 >= 0)
                    {
                        santaRow--;
                        char symbol = field[santaRow][santaCol];

                        if (symbol == 'V')
                        {
                            GivePresents(ref kidsWithPresents, ref kidsWithoutPresents, ref presentsCount);
                            field[santaRow][santaCol] = 'S';
                            field[santaRow + 1][santaCol] = '-';
                        }
                        else if (symbol == 'C')
                        {
                            field[santaRow - 1][santaCol] = '-';
                            field[santaRow + 1][santaCol] = '-';
                            field[santaRow][santaCol - 1] = '-';
                            field[santaRow][santaCol + 1] = '-';
                            presentsCount -= 4;
                        }
                        else if (symbol == 'X')
                        {
                            field[santaRow][santaCol] = 'S';
                            field[santaRow + 1][santaCol] = '-';
                        }
                    }
                }
                else if (command == "down")
                {
                    if (santaRow + 1 >= 0)
                    {
                        santaRow++;
                        char symbol = field[santaRow][santaCol];

                        if (symbol == 'V')
                        {
                            GivePresents(ref kidsWithPresents, ref kidsWithoutPresents, ref presentsCount);
                            field[santaRow][santaCol] = 'S';
                            field[santaRow - 1][santaCol] = '-';
                        }
                        else if (symbol == 'C')
                        {
                            field[santaRow - 1][santaCol] = '-';
                            field[santaRow + 1][santaCol] = '-';
                            field[santaRow][santaCol - 1] = '-';
                            field[santaRow][santaCol + 1] = '-';
                            presentsCount -= 4;
                        }
                        else if (symbol == 'X')
                        {
                            field[santaRow][santaCol] = 'S';
                            field[santaRow - 1][santaCol] = '-';
                        }
                    }
                }
                else if (command == "left")
                {
                    if (santaCol - 1 >= 0)
                    {
                        santaCol--;
                        char symbol = field[santaRow][santaCol];

                        if (symbol == 'V')
                        {
                            GivePresents(ref kidsWithPresents, ref kidsWithoutPresents, ref presentsCount);
                            field[santaRow][santaCol] = 'S';
                            field[santaRow][santaCol - 1] = '-';
                        }
                        else if (symbol == 'C')
                        {
                            field[santaRow - 1][santaCol] = '-';
                            field[santaRow + 1][santaCol] = '-';
                            field[santaRow][santaCol - 1] = '-';
                            field[santaRow][santaCol + 1] = '-';
                            presentsCount -= 4;
                        }
                        else if (symbol == 'X')
                        {
                            field[santaRow][santaCol] = 'S';
                            field[santaRow][santaCol - 1] = '-';
                        }
                    }
                }
                else if (command == "right")
                {
                    if (santaCol + 1 >= 0)
                    {
                        santaCol++;
                        char symbol = field[santaRow][santaCol];

                        if (symbol == 'V')
                        {
                            GivePresents(ref kidsWithPresents, ref kidsWithoutPresents, ref presentsCount);
                            field[santaRow][santaCol] = 'S';
                            field[santaRow][santaCol + 1] = '-';
                        }
                        else if (symbol == 'C')
                        {
                            field[santaRow - 1][santaCol] = '-';
                            field[santaRow + 1][santaCol] = '-';
                            field[santaRow][santaCol - 1] = '-';
                            field[santaRow][santaCol + 1] = '-';
                            presentsCount -= 4;
                        }
                        else if (symbol == 'X')
                        {
                            field[santaRow][santaCol] = 'S';
                            field[santaRow][santaCol + 1] = '-';
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (presentsCount <= 0)
            {
                Console.WriteLine("Santa ran out of presents.");
            }

            PrintField(field);

            if (kidsWithoutPresents == 0)
            {
                Console.WriteLine($"Good job, Santa! {kidsWithPresents} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {kidsWithoutPresents} nice kid/s.");
            }
        }

        private static void GivePresents(ref int kidsWithPresents, ref int kidsWithoutPresents, ref int presentsCount)
        {
            if (presentsCount > 0)
            {
                presentsCount--;
                kidsWithPresents++;
            }
            else
            {
                kidsWithoutPresents++;
            }
        }

        private static void InitialiseField(int n, char[][] field, ref int playerRow, ref int playerCol, ref bool playerPositionFound)
        {
            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();

                if (!playerPositionFound)
                {
                    for (int col = 0; col < currentRow.Length; col++)
                    {
                        if (currentRow[col] == 'P')
                        {
                            playerRow = row;
                            playerCol = col;
                            playerPositionFound = true;
                        }
                    }
                }
                field[row] = currentRow;
            }
        }

        private static void PrintField(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
