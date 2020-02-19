using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaPresentFactory
{
    class StartUO
    {
        static void Main(string[] args)
        {
            // Input
            int[] boxesWithMaterialsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] magicLevelsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> boxesWithMaterials = new Stack<int>(boxesWithMaterialsInput);
            Queue<int> magicLevels = new Queue<int>(magicLevelsInput);
            Dictionary<string, int> presents = new Dictionary<string, int>()
            {
                { "Doll", 0 },
                { "Wooden train", 0 },
                { "Teddy bear", 0},
                { "Bicycle", 0},
            };

            // Crafting Presents
            while (boxesWithMaterials.Any() && magicLevels.Any())
            {
                int currentBox = boxesWithMaterials.Peek();
                int currentMagicLevel = magicLevels.Peek();

                if (currentBox == 0 || currentMagicLevel == 0)
                {
                    if (currentBox == 0)
                    {
                        boxesWithMaterials.Pop();
                    }

                    if (currentMagicLevel == 0)
                    {
                        magicLevels.Dequeue();
                    }

                    continue;
                }

                int totalMagicLevels = currentBox * currentMagicLevel;

                if (totalMagicLevels == 150 || totalMagicLevels == 250 || totalMagicLevels == 300 || totalMagicLevels == 400)
                {
                    switch (totalMagicLevels)
                    {
                        case 150:
                            presents["Doll"]++;
                            boxesWithMaterials.Pop();
                            magicLevels.Dequeue();
                            break;
                        case 250:
                            presents["Wooden train"]++;
                            boxesWithMaterials.Pop();
                            magicLevels.Dequeue();
                            break;
                        case 300:
                            presents["Teddy bear"]++;
                            boxesWithMaterials.Pop();
                            magicLevels.Dequeue();
                            break;
                        case 400:
                            presents["Bicycle"]++;
                            boxesWithMaterials.Pop();
                            magicLevels.Dequeue();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (totalMagicLevels < 0)
                    {
                        boxesWithMaterials.Pop();
                        magicLevels.Dequeue();
                        boxesWithMaterials.Push(currentBox + currentMagicLevel);
                    }

                    if (totalMagicLevels > 0)
                    {
                        magicLevels.Dequeue();
                        boxesWithMaterials.Pop();
                        boxesWithMaterials.Push(currentBox + 15);
                    }
                }
            }

            // Output
            if ((presents["Doll"] > 0 && presents["Wooden train"] > 0) || (presents["Bicycle"] > 0 && presents["Teddy bear"] > 0))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
                PrintMaterials(boxesWithMaterials);
                PrintMagicLevels(magicLevels);
                PrintPresents(presents);
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
                PrintMaterials(boxesWithMaterials);
                PrintMagicLevels(magicLevels);
                PrintPresents(presents);
            }

        }

        private static void PrintPresents(Dictionary<string, int> presents)
        {
            foreach (var item in presents.OrderBy(x => x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }

        private static void PrintMagicLevels(Queue<int> magicLevels)
        {
            if (magicLevels.Count > 0)
            {
                string magicLevelsString = String.Join(", ", magicLevels);
                Console.WriteLine($"Magic left: {magicLevelsString}");
            }
        }

        private static void PrintMaterials(Stack<int> boxesWithMaterials)
        {
            if (boxesWithMaterials.Count > 0)
            {
                string materialsString = String.Join(", ", boxesWithMaterials);
                Console.WriteLine($"Materials left: {materialsString}");
            }
        }
    }
}
