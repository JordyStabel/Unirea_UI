using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unirea_UI.Models;


namespace Unirea_UI
{
    public class UserManagement
    {
        public async Task Login(Player player)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://145.93.173.52:8090");

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
            }
        }

        public async Task Register(Player player)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://145.93.173.52:8090");

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
                Console.WriteLine(resultContent);
            }
        }
    }
}
