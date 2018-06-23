using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Backend.RestModels
{
    public class TownResources
    {
    }

    public class TownBuildings
    {
    }

    public class PlayerTown
    {
        public int id { get; set; }
        public TownResources townResources { get; set; }
        public TownBuildings townBuildings { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public int townId { get; set; }
    }
}
