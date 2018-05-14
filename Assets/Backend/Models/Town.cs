using System.Collections.Generic;
using Assets.Backend.Models.Buildings;
using Unirea_UI.Models;

namespace Assets.Backend.Models
{
    public class Town
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Building> Buildings { get; private set; }
    }
}
