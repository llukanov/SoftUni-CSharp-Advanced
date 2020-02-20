using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SpaceshipCrafting
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] liquidsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] itemsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Dictionary<string, int> advancedMaterials = new Dictionary<string, int>()
            {
                { "Glass", 0},
                { "Aluminium", 0},
                { "Lithium", 0},
                { "Carbon fiber", 0},
            };

            Queue<int> liquids = new Queue<int>(liquidsInput);
            Stack<int> items = new Stack<int>(itemsInput);

            while (liquids.Any() && items.Any())
            {
                int liquidCurrent = liquids.Peek();
                int itemCurrent = items.Peek();

                switch (liquidCurrent + itemCurrent)
                {
                    case 25:
                        advancedMaterials["Glass"]++;
                        liquids.Dequeue();
                        items.Pop();
                        break;
                    case 50:
                        advancedMaterials["Aluminium"]++;
                        liquids.Dequeue();
                        items.Pop();
                        break;
                    case 75:
                        advancedMaterials["Lithium"]++;
                        liquids.Dequeue();
                        items.Pop();
                        break;
                    case 100:
                        advancedMaterials["Carbon fiber"]++;
                        liquids.Dequeue();
                        items.Pop();
                        break;
                    default:
                        liquids.Dequeue();
                        items.Pop();
                        items.Push(itemCurrent + 3);
                        break;
                }
            }

            PrintMessage(advancedMaterials);
            PrintLiquids(liquids);
            PrintItems(items);
            PrintMaterials(advancedMaterials);
        }

        private static void PrintLiquids(Queue<int> liquids)
        {
            string liquidsString = liquids.Count > 0 ? String.Join(", ", liquids) : "none";
            Console.WriteLine($"Liquids left: {liquidsString}");
        }

        private static void PrintItems(Stack<int> items)
        {
            string itemsString = items.Count > 0 ? String.Join(", ", items) : "none";
            Console.WriteLine($"Physical items left: {itemsString}");
        }

        private static void PrintMessage(Dictionary<string, int> advancedMaterials)
        {
            if (advancedMaterials["Glass"] >= 1
                            && advancedMaterials["Aluminium"] >= 1
                            && advancedMaterials["Lithium"] >= 1
                            && advancedMaterials["Carbon fiber"] >= 1)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }
        }

        private static void PrintMaterials(Dictionary<string, int> advancedMaterials)
        {
            foreach (var material in advancedMaterials.OrderBy(r => r.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
