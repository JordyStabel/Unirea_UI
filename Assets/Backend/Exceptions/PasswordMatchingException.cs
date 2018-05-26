using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Backend.Exceptions
{
    class PasswordMatchingException : Exception
    {
        public PasswordMatchingException()
        {
            
        }

        public PasswordMatchingException(string message) : base(message)
        {
            
        }
    }
}
