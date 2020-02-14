using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read queues
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(numbers);

            // Print even numbers
            Console.WriteLine(string.Join(", ", queue.Where(x => x % 2 == 0)));
        }
    }
}
