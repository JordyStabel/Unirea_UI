using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Backend.Exceptions
{
    class SessionExpiredException : Exception
    {
        public SessionExpiredException()
        {
            
        }

        public SessionExpiredException(string message) : base(message)
        {
            
        }
    }
}
