using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Assets.Backend.Exceptions;
using Assets.Backend.Models;
using Newtonsoft.Json;

namespace Assets.Backend.Rest
{
    class AccountRest
    {
        public async Task<Player> Login(Player player)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var queries = new Dictionary<string, string>
                {
                    {"email", player.Email},
                    {"password", player.Password}
                };

                var json = JsonConvert.SerializeObject(queries);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/account/login", data);
                string resultContent = await result.Content.ReadAsStringAsync();

                switch (result.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new NotFoundException("Unable to find player.");
                    case HttpStatusCode.Forbidden:
                        throw new AuthenticationException("The password was incorrect.");
                    case HttpStatusCode.OK:
                        player = new Player(0, resultContent, player.Username, player.Email);
                        return player;
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }

        public async Task<bool> Register(Player player)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var queries = new Dictionary<string, string>
                {
                    {"email", player.Email},
                    {"username", player.Username},
                    {"password", player.Password}
                };

                var json = JsonConvert.SerializeObject(queries);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/account/register", data);

                switch (result.StatusCode)
                {
                    case HttpStatusCode.Conflict:
                        throw new InformationAlreadyUsedException("Email already in use.");
                    case HttpStatusCode.BadRequest:
                        throw new ArgumentException("One of the required values was not given.");
                    case HttpStatusCode.OK:
                        return true;
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }

        public async Task<Player> GetAccount(string authenticationToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var queries = new Dictionary<string, string>
                {
                    { "token", authenticationToken }
                };

                var json = JsonConvert.SerializeObject(queries);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/account/getaccount", data);
                string resultContent = await result.Content.ReadAsStringAsync();

                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        Player player = JsonConvert.DeserializeObject<Player>(resultContent);
                        player.AuthenticationToken = authenticationToken;
                        return player;
                    case HttpStatusCode.NotFound:
                        throw new NotFoundException("The specified player was not found.");
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }

        public async Task<bool> ChangePassword(string authenticationToken, string username, string newPassword,
            string verifyPassword)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var queries = new Dictionary<string, string>
                {
                    {"token", authenticationToken},
                    {"username", username},
                    {"newPassword", newPassword},
                    {"verifyPassword", verifyPassword}
                };

                var json = JsonConvert.SerializeObject(queries);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/account/changepassword", data);

                switch (result.StatusCode)
                {
                    case HttpStatusCode.Conflict:
                        throw new PasswordMatchingException("The given passwords do not match.");
                    case HttpStatusCode.Forbidden:
                        throw new SessionExpiredException("The player's login session has expired.");
                    case HttpStatusCode.OK:
                        return true;
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }

        public async Task<bool> Logout(string authenticationToken, string username)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var queries = new Dictionary<string, string>
                {
                    {"token", authenticationToken},
                    {"username", username}
                };

                var json = JsonConvert.SerializeObject(queries);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/account/logout", data);

                switch (result.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                        throw new SessionExpiredException("Player is already logged out.");
                    case HttpStatusCode.OK:
                        return true;
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }
    }
}
