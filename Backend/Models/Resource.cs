using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unirea_UI.Models
{
    public class Resource
    {
        public int Id { get; private set; }
        public int Amount { get; private set; }
        public ResourceType ResourceType { get; private set; }
        public Town Town { get; private set; }
    }
}
