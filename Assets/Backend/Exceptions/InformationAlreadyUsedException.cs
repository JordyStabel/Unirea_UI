using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Backend.Exceptions
{
    class InformationAlreadyUsedException : Exception
    {
        public InformationAlreadyUsedException()
        {
            
        }

        public InformationAlreadyUsedException(string message) : base(message)
        {
            
        }
    }
}
