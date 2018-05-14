using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unirea_UI.Models
{
    public class Player
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Clan Clan { get; private set; }

        public Player(int id, string username, string email, string password)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
            Clan = null;
        }
    }
}
