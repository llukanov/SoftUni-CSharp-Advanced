using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var text = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                text.Push(input[i]);
            }

            while (text.Any())
            {
                Console.Write(text.Pop());
            }
        }
    }
}
