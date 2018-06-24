using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Backend.Exceptions
{
    class PlayerAlreadyHasTownException : Exception
    {
        public PlayerAlreadyHasTownException()
        {

        }

        public PlayerAlreadyHasTownException(string message) : base(message)
        {

        }
    }
}
