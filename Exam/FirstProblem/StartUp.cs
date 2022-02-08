using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstProblem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] firstBoxInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondBoxInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> claimedItems = new List<int>();

            Queue<int> firstBox = new Queue<int>(firstBoxInput);
            Stack<int> secondBox = new Stack<int>(secondBoxInput);

            while (firstBox.Any() && secondBox.Any())
            {
                int firstBoxCurrent = firstBox.Peek();
                int secondBoxCurrent = secondBox.Peek();

                int sum = firstBoxCurrent + secondBoxCurrent;

                if (sum % 2 == 0)
                {
                    claimedItems.Add(firstBoxCurrent + secondBoxCurrent);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    int forMoving = secondBox.Pop();
                    firstBox.Enqueue(forMoving);
                }

                if (firstBox.Count <= 0)
                {
                    Console.WriteLine("First lootbox is empty");
                }

                if (secondBox.Count <= 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                }
            }


            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
