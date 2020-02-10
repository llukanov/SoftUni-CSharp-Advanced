using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            string commandCurent = Console.ReadLine().ToLower();

            while (true)
            {
                string[] commands = Console.ReadLine().ToLower().Split();

                if (commands[0] == "add")
                {
                    stack.Push(int.Parse(commands[1]));
                    stack.Push(int.Parse(commands[2]));
                }
                else if (commands[0] == "remove")
                {
                    int n = int.Parse(commands[1]);

                    if (n >= stack.Count)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
