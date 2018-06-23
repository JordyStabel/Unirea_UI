using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Backend.Models.Buildings;

namespace Assets.Backend.RestModels
{
    public class TownResources
    {
        public int wood;
        public int oil;
        public int iron;
    }

    public class TownBuildings
    {
        public int oilRefinery { get; set; }
        public int ironMine { get; set; }
        public int forestry { get; set; }
        public int headquarters { get; set; }
        public int warehouse { get; set; }
        public int barracks { get; set; }
        public int trainingGrounds { get; set; }
        public int foundry { get; set; }
        public int ammunitionDepot { get; set; }
        public int wall { get; set; }
    }

    public class PlayerTown
    {
        public TownResources townResources { get; set; }
        public TownBuildings townBuildings { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public int townId { get; set; }
    }
}
