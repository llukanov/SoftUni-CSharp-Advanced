using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read and to Stack
            string[] input = Console.ReadLine().Split();
            Stack<string> expression = new Stack<string>(input.Reverse());

            // Calculation
            while (expression.Count > 1)
            {
                int firstNumber = int.Parse(expression.Pop());
                string operatoration = expression.Pop();
                int secondNumber = int.Parse(expression.Pop());
                int sum = 0;

                switch (operatoration)
                {
                    case "+":
                        sum = firstNumber + secondNumber;
                        break;
                    case "-":
                        sum = firstNumber - secondNumber;
                        break;
                    default:
                        break;
                }

                expression.Push(sum.ToString());
            }

            // Print result
            Console.WriteLine(expression.Pop());
        }
    }
}
