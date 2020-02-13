﻿using System;
using System.Linq;

namespace SumMatrixElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = ParseInput();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[] colsSum = new int[cols];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = ParseInput();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    colsSum[col] += matrix[row, col];
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, colsSum));
        }

        private static int[] ParseInput()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
