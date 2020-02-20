using System;
using System.Text;

namespace _03.SpaceStationEstablishment
{
    class StartUp
    {
        static char[,] matrix;
        static int spaceshipRow;
        static int spaceshipCol;
        static StringBuilder @string;

        public static void Main()
        {
            int energy = 0;

            @string = new StringBuilder();

            string initialString = Console.ReadLine();

            int matrixSize = int.Parse(Console.ReadLine());
            matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        spaceshipRow = row;
                        spaceshipCol = col;
                    }
                }
            }

            @string.Append(initialString);

            while (true)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        Move(-1, 0, ref energy);
                        break;
                    case "down":
                        Move(1, 0, ref energy);
                        break;
                    case "left":
                        Move(0, -1, ref energy); 
                        break;
                    case "right":
                        Move(0, 1, energy);
                        break;
                }
            }

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            Console.WriteLine(@string.ToString());
            matrix[spaceshipRow, spaceshipCol] = 'P';

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void Move(int row, int col, ref energy)
        {
            if (spaceshipRow + row >= 0
                && spaceshipRow + row < matrix.GetLength(0)
                && spaceshipCol + col >= 0
                && spaceshipCol + col < matrix.GetLength(1))
            {
                if (matrix[spaceshipRow, spaceshipCol] == 'S')
                {
                    matrix[spaceshipRow, spaceshipCol] = '-';
                }

                spaceshipRow += row;
                spaceshipCol += col;

                char cell = matrix[spaceshipRow, spaceshipCol];

                if (char.IsDigit(cell))
                {
                    energy =
                    @string.Append(cell);
                    matrix[spaceshipRow, spaceshipCol] = '-';
                }

                matrix[spaceshipRow, spaceshipCol] = 'P';
            }
            else
            {
                @string.Remove(@string.Length - 1, 1);
            }
        }

        private static bool IsValid(int row, int col)
        {
            return spaceshipRow + row >= 0 && spaceshipRow + row < matrix.GetLength(0) &&
                   spaceshipCol + col >= 0 && spaceshipCol + col < matrix.GetLength(1);
        }
    }
}