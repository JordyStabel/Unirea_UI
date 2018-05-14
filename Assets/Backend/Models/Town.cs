using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unirea_UI.Models
{
    public class Town
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Building> Buildings { get; private set; }
    }
}
