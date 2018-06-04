using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Assets.Backend.RestModels
{
    public class RestTown
    {
        public int Id { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        [JsonConstructor]
        public RestTown(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
    }
}
