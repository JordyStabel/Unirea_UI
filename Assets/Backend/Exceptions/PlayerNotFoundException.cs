using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Backend.Exceptions
{
    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException()
        {
            
        }

        public PlayerNotFoundException(string message) : base(message)
        {
            
        }
    }
}
