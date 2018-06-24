using System.Collections.Generic;
using Assets.Backend.Models;

namespace Assets.Backend.RestModels
{
    public class TownResource
    {
        public ResourceType rescourceType { get; set; }
        public int amount { get; set; }
    }

    public class UpgradeCost
    {
        public ResourceType rescourceType { get; set; }
        public int amount { get; set; }
    }

    public class TownBuilding
    {
        public BuildingType buildingType { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public List<UpgradeCost> upgradeCost { get; set; }
        public int resourceProduction { get; set; }
    }

    public class PlayerTown
    {
        public List<TownResource> townResources { get; set; }
        public List<TownBuilding> townBuildings { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public int townId { get; set; }
        public int playerId { get; set; }
    }
}
