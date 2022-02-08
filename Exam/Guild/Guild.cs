using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    class Guild
    {
        private readonly List<Player> roster;

        private Guild()
        {
            this.roster = new List<Player>();
        }

        public Guild(string name, int capacity)
            :this()
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
                return this.roster.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            if (this.roster.Count + 1 <= this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = this.roster
                .FirstOrDefault(r => r.Name == name);

            if (player != null)
            {
                this.roster.Remove(player);
                return true;
            }
            else
            {
                return false;
            }
        }


        public void PromotePlayer(string name)
        {
            Player player = this.roster
                .FirstOrDefault(r => r.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = this.roster
                .FirstOrDefault(r => r.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string myclass)
        {
            Player[] players = this.roster
                .Where(r => r.Class == myclass)
                .ToArray();

            foreach (var player in players)
            {
                this.roster.Remove(player);
            }

            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in roster)
            {
                sb.AppendLine($"{player.ToString()}");
            }


            return sb.ToString().TrimEnd();
        }
    }
}
