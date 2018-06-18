using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Assets.Backend.RestModels
{
    public class Map
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
    }

    public class RootObject
    {
        public List<Map> maps { get; set; }
    }
}
