using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    class Bag
    {
        private readonly List<Present> data;

        private Bag()
        {
            this.data = new List<Present>();
        }
        public Bag(string color, int capacity)
            :this()
        {
            this.Color = color;
            this.Capacity = capacity;
        }

        public string Color { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Present present)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            Present present = this.data
                .FirstOrDefault(r => r.Name == name);

            if (present != null)
            {
                this.data.Remove(present);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Present GetHeaviestPresent()
        {
            int maxWeight = int.MinValue;
            Present heaviestPresent = null;

            foreach (var present in data)
            {
                if (present.Weight > maxWeight)
                {
                    heaviestPresent = present;
                }
            }

            return heaviestPresent;
        }

        public Present GetPresent(string name)
        {
            Present present = this.data
                .FirstOrDefault(r => r.Name == name);

            return present;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");

            foreach (var present in data)
            {
                sb.AppendLine($"{present.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
