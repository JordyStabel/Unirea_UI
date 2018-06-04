using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Assets.Backend.Exceptions;
using Assets.Backend.RestModels;
using Newtonsoft.Json;

namespace Assets.Backend.Rest
{
    class MapRest
    {
        public async Task<List<RestTown>> GetAllTowns(string authenticationToken)
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
                var result = await client.PostAsync("/map/all", data);
                var resultContent = await result.Content.ReadAsStringAsync();

                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        List<RestTown> towns = JsonConvert.DeserializeObject<List<RestTown>>(resultContent);
                        return towns;
                    case HttpStatusCode.Forbidden:
                        throw new SessionExpiredException("The player's login session has expired.");
                }
            }

            throw new InvalidOperationException("Reached invalid state.");
        }


    }
}
}
