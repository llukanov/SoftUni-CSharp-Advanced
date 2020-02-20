using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquariumAdventure
{
    class Aquarium
    {
        private readonly List<Fish> fishInPool;

        private Aquarium()
        {
            this.fishInPool = new List<Fish>();
        }

        public Aquarium(string name, int capacity, int size)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Size { get; set; }

        public void Add(Fish fish)
        {
            if (this.fishInPool.Count + 1 <= this.Capacity
                && this.fishInPool.FirstOrDefault(r => r == fish) == null)
            {
                this.fishInPool.Add(fish);
            }
        }

        public bool Remove(string name)
        {
            Fish fish = this.fishInPool
                .FirstOrDefault(r => r.Name == name);

            if (fish != null)
            {
                this.fishInPool.Remove(fish);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Fish FindFish(string name)
        {
            Fish fish = this.fishInPool
                .FirstOrDefault(r => r.Name == name);

            if (fish != null)
            {
                return fish;
            }
            else
            {
                return null;
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");

            foreach (var fish in fishInPool)
            {
                sb.AppendLine($"{fish.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
