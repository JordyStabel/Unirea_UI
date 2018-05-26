using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Assets.Backend.Models;
using Newtonsoft.Json;
using Unirea_UI.Models;

namespace Assets.Backend
{
    public class UserManagement
    {
        public async Task<string> Login(Player player)
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
                Console.WriteLine(resultContent);
                return resultContent == "Player does not exist" ? null : resultContent;
            }
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
                string resultContent = await result.Content.ReadAsStringAsync();
                return resultContent == "Successfully registered";
            }
        }
    }
}