using System;

namespace SecondProblem
{
    class StartUp
    {
        static int rows;
        static char[][] matrix;
        static int heroRow;
        static int heroCol;
        static char symbol = '-';
        static char heroSymbol = 'f';
        static int commandsNumber;
        static char finalMark = 'F';
        static char bonusMark = 'B';
        static char trapMark = 'T';
        static int finalMarkRow;
        static int finalMarkCol;
        static bool isOut = false;
        static bool isWin = false;
        static string command;
        static void Main(string[] args)
        {
            rows = int.Parse(Console.ReadLine());
            commandsNumber = int.Parse(Console.ReadLine());

            ReadMatrix(rows);
            FindPosition(heroSymbol);



            while (commandsNumber > 0 && !isWin)
            {
                if (commandsNumber <= 0)
                {
                    break;
                }
                if (isWin = true)
                {
                    break;
                }

                command = Console.ReadLine();

                if (isOut == true)
                {
                    heroRow = matrix.GetLength(0) - 1;
                    isOut = false;
                }


                if (command == "up")
                {
                    if (heroRow - 1 >= 0)
                    {
                        heroRow--;
                        char symbol = matrix[heroRow][heroCol];

                        if (symbol == bonusMark)
                        {
                            if (heroRow - 1 >= 0)
                            {
                                heroRow--;
                                char symbolNew = matrix[heroRow][heroCol];

                                if (symbolNew == finalMark)
                                {
                                    isWin = true;
                                }
                                commandsNumber--;
                            }
                            else
                            {
                                isOut = true;
                                commandsNumber--;
                            }
                        }
                        else if (symbol == trapMark)
                        {
                            heroRow+=1;
                        }
                        else if (symbol == finalMark)
                        {
                            isWin = true;
                        }
                    }
                    else
                    {
                        isOut = true;
                    }
                    commandsNumber--;
                }
                else if (command == "down")
                {
                    if (heroRow + 1 < rows)
                    {
                        heroRow++;
                        char symbol = matrix[heroRow][heroCol];

                        if (symbol == bonusMark)
                        {
                            if (heroRow + 1 < rows)
                            {
                                heroRow++;
                                char symbolNew = matrix[heroRow][heroCol];

                                if (symbolNew == finalMark)
                                {
                                    isWin = true;
                                }
                                commandsNumber--;
                            }
                            else
                            {
                                isOut = true;
                                commandsNumber--;
                            }
                        }
                        else if (symbol == trapMark)
                        {
                            heroRow -= 1;
                        }
                        else if (symbol == finalMark)
                        {
                            isWin = true;
                        }
                    }
                    else
                    {
                        isOut = true;
                    }
                    commandsNumber--;
                }
                else if (command == "left")
                {


                    if (heroCol - 1 >= 0)
                    {
                        heroCol--;
                        char symbol = matrix[heroRow][heroCol];

                        if (symbol == bonusMark)
                        {
                            if (heroCol - 1 >= 0)
                            {
                                heroCol--;
                                char symbolNew = matrix[heroRow][heroCol];

                                if (symbolNew == finalMark)
                                {
                                    isWin = true;
                                }
                                commandsNumber--;
                            }
                            else
                            {
                                isOut = true;
                                commandsNumber--;
                            }
                        }
                        else if (symbol == trapMark)
                        {
                            heroCol += 1;
                        }
                        else if (symbol == finalMark)
                        {
                            isWin = true;
                        }
                    }
                    else
                    {
                        isOut = true;
                    }
                    commandsNumber--;
                }
                else if (command == "right")
                {
                    if (heroCol + 1 < rows)
                    {
                        heroRow++;
                        char symbol = matrix[heroRow][heroCol];

                        if (symbol == bonusMark)
                        {
                            if (heroCol + 1 < rows)
                            {
                                heroCol++;
                                char symbolNew = matrix[heroRow][heroCol];

                                if (symbolNew == finalMark)
                                {
                                    isWin = true;
                                }
                                commandsNumber--;
                            }
                            else
                            {
                                isOut = true;
                                commandsNumber--;
                            }
                        }
                        else if (symbol == trapMark)
                        {
                            heroCol -= 1;
                        }
                        else if (symbol == finalMark)
                        {
                            isWin = true;
                        }
                    }
                    else
                    {
                        isOut = true;
                    }
                    commandsNumber--;
                }
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
            if (isOut == true)
            {
                heroRow = matrix.GetLength(0) - 1;
                isOut = false;
            }
            matrix[heroRow][heroCol] = heroSymbol;

            if (isWin)
            {
                Console.WriteLine("Player won!");
            }
            else if (isWin == false)
            {
                Console.WriteLine("Player lost!");
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
            matrix[heroRow][heroCol] = symbol;
        }

        private static void FindFinalMark(char letter)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == finalMark)
                    {
                        finalMarkRow = row;
                        finalMarkCol = col;
                    }
                }
            }

        }
    }
}
