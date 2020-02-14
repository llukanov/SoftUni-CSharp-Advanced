using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> clients = new Queue<string>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "Paid")
                {
                    while (clients.Any())
                    {
                        string clientName = clients.Dequeue();
                        Console.WriteLine(clientName);
                    }
                }
                else
                {
                    clients.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{clients.Count} people remaining.");
        }
    }
}
