using System.Collections.Generic;
using Assets.Backend.Models.Buildings;
using Newtonsoft.Json;
using Unirea_UI.Models;

namespace Assets.Backend.Models
{
    public class Town
    {
        public int Id { get; private set; }
        public Player Player { get; private set; }
        public string Name { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        [JsonConstructor]
        public Town(int id, Player player, string name, int x, int y)
        {
            Id = id;
            Player = player;
            Name = name;
            X = x;
            Y = y;
        }
    }
}
