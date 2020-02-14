using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read expression
            string input = Console.ReadLine();
            var stack = new Stack<int>();

            // Extract each sub-expression
            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (symbol == '(')
                {
                    stack.Push(i);
                }
                else if (symbol == ')')
                {
                    int start = stack.Pop();
                    int lenght = i - start + 1;
                    string expression = input.Substring(start, lenght);

                    Console.WriteLine(expression);
                }
            }
        }
    }
}
