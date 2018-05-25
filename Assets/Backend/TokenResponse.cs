using System;

namespace Assets.Backend
{
    public class Token
    {
        public string AccessToken  { get; private set; }
        public int ExpiresIn { get; private set; }
        public string Username { get; private set; }
        public DateTime Issued { get; private set; }
        public DateTime Expires { get; private set; }

        public Token(string accessToken, int expiresIn, string username, DateTime issued, DateTime expires)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
            Username = username;
            Issued = issued;
            Expires = expires;
        }
    }
}
