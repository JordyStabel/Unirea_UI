using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Backend.Exceptions
{
    class NotEnoughResourcesException : Exception
    {
        public NotEnoughResourcesException()
        {

        }

        public NotEnoughResourcesException(string message) : base(message)
        {

        }
    }
}
