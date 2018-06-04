using Unirea_UI.Models;

namespace Assets.Backend.Models
{
    public class Player
    {
        public string AuthenticationToken { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Constructor for the json that is sent to the server
        public Player(string username, string email, string password)
        {
            Id = 0;
            AuthenticationToken = null;
            Username = username;
            Email = email;
            Password = password;
        }

        // Constructor for the json that is received from the server
        public Player(int id, string authenticationToken, string username, string email)
        {
            Id = id;
            AuthenticationToken = authenticationToken;
            Username = username;
            Email = email;
        }
    }
}
