using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private readonly List<Astronaut> data;

        private SpaceStation()
        {
            this.data = new List<Astronaut>();
        }

        public SpaceStation(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }
        public void Add(Astronaut astronaut)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            Astronaut astronaut = this.data
                .FirstOrDefault(r => r.Name == name);

            if (astronaut != null)
            {
                this.data.Remove(astronaut);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Astronaut GetOldestAstronaut()
        {
            int oldest = int.MinValue;
            Astronaut oldestAstronaut = null;

            foreach (var astronaut in data)
            {
                if (astronaut.Age > oldest)
                {
                    oldestAstronaut = astronaut;
                }
            }

            return oldestAstronaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut astronaut = this.data
                .FirstOrDefault(r => r.Name == name);

            return astronaut;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in data)
            {
                sb.AppendLine($"{astronaut.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
