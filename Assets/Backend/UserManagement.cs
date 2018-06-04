using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Assets.Backend.Exceptions;
using Assets.Backend.Models;
using Assets.Backend.Models.Buildings;
using Assets.Backend.RestModels;
using Newtonsoft.Json;

namespace Assets.Backend
{
    public class UserManagement
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
                        return player;
                    case HttpStatusCode.NotFound:
                        throw new NotFoundException("The specified player was not found.");
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

        public async Task<Town> GetTown(string authenticationToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var queries = new Dictionary<string, string>
                {
                    {"token", authenticationToken}

                };

                var json = JsonConvert.SerializeObject(queries);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/town/get", data);
                var resultContent = await result.Content.ReadAsStringAsync();
                var town = JsonConvert.DeserializeObject<Town>(resultContent);

                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return town;
                    case HttpStatusCode.Forbidden:
                        throw new SessionExpiredException("The player's login session has expired.");
                    case HttpStatusCode.NotFound:
                        throw new NotFoundException("The town of the specified player was not found.");
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }

        public async Task<Town> CreateTown(string authenticationToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var queries = new Dictionary<string, string>
                {
                    {"token", authenticationToken}

                };

                var json = JsonConvert.SerializeObject(queries);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/town/create", data);
                var resultContent = await result.Content.ReadAsStringAsync();

                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var town = JsonConvert.DeserializeObject<Town>(resultContent);
                        return town;
                    case HttpStatusCode.Forbidden:
                        throw new SessionExpiredException("The player's login session has expired.");
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }

        //TODO: New class for specific town class of server
        public async Task<List<RestTown>> GetAllTowns(string authenticationToken)
        {
            List<RestTown> towns = new List<RestTown>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var queries = new Dictionary<string, string>
                {
                    {"token", authenticationToken}
                };

                var json = JsonConvert.SerializeObject(queries);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/map/all", data);
                var resultContent = await result.Content.ReadAsStringAsync();

                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        towns = JsonConvert.DeserializeObject<List<RestTown>>(resultContent);
                        return towns;
                    case HttpStatusCode.Forbidden:
                        throw new SessionExpiredException("The player's login session has expired.");
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }

        public async Task<List<Town>> GetAllTownsFromPlayer(string authenticationToken, int playerId)
        {
            List<Town> towns = new List<Town>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(RestConstants.Url);

                var queries = new Dictionary<string, string>
                {
                    {"token", authenticationToken},
                    {"playerId", playerId.ToString()}
                };

                var json = JsonConvert.SerializeObject(queries);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/town/all", data);
                var resultContent = await result.Content.ReadAsStringAsync();

                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        towns = JsonConvert.DeserializeObject<List<Town>>(resultContent);
                        return towns;
                    case HttpStatusCode.NotFound:
                        throw new NotFoundException("Could not find towns of specified player.");
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }
    }
}
