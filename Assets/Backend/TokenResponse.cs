using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unirea_UI
{
    public class TokenResponse
    {
        public string AccessToken  { get; private set; }
        public int ExpiresIn { get; private set; }
        public string Username { get; private set; }
        public string Issued { get; private set; }
        public string Expires { get; private set; }
    }
}
