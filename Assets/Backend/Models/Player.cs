using Unirea_UI.Models;

namespace Assets.Backend.Models
{
    public class Player
    {
        public string AuthenticationToken { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Clan Clan { get; private set; }

        public Player(string authenticationToken, string username, string email, string password)
        {
            AuthenticationToken = authenticationToken;
            Username = username;
            Email = email;
            Password = password;
            Clan = null;
        }

        public Player(string authenticationToken, string username, string password)
        {
            AuthenticationToken = authenticationToken;
            Username = username;
            Email = null;
            Password = password;
            Clan = null;
        }
    }
}
